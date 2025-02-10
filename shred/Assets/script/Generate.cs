using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Switch;

public class Generate : MonoBehaviour
{
    int P_posY;
    int P_posYbf;
    int distance = 25;//Playerとインスタンスする釘の距離
    int StageNumber;


    float time;//経過時間
    float bfTime = 0;//player座標チェック用
    float NailTime = 0.5f;//釘召喚用
    float Goal_posX = 0;
    float BlockTime = -1;

    bool Nail_LR = false;//釘の召喚をばらけさせるため。右がfalse
    bool Goal_Gen = false;


    [SerializeField, Header("カメラ")]
    GameObject CAMERA;
    camera CMR;

    [SerializeField, Header("プレイヤー")]
    GameObject Player;
    Transform P_t;
    [SerializeField, Header("エネミー")]
    GameObject Enemy;
    [SerializeField, Header("釘")]
    GameObject Nail;
    Transform Nail_t;
    [SerializeField, Header("タイトルブロック")]
    GameObject Block;
    [SerializeField, Header("アイテム")]
    GameObject bigSmall;
    [SerializeField]
    GameObject Slot;

    [SerializeField, Header("NGエリア")]
    GameObject NG;
    [SerializeField, Header("ゴール")]
    GameObject Goal;
    [SerializeField, Header("ステージ横壁")]
    GameObject Wall_LRDS;
    Transform Wall_LRDS_T;
    [SerializeField, Header("ステージ前後壁")]
    GameObject Wall_BA;
    Transform Wall_BA_T;

    [SerializeField, Header("ステージ長さ")]
    int StageLength = 100;
    [SerializeField, Header("ステージ壁X座標")]
    float left = -5;
    [SerializeField]
    float right = 5;

    float senter = 0;
    float depth = -2;

    bool stage_in = false;

    GameObject c_nail;



    //インスタンス用無回転
    Quaternion Nrot = Quaternion.identity;

    //釘インスタンスの回転
    Quaternion Nailrot = Quaternion.Euler(90, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        
        CMR = CAMERA.GetComponent<camera>();
        //プレイヤーの座標取得
        P_t = Player.GetComponent<Transform>();
        P_posY = (int)P_t.position.y;


        if (P_posYbf >= P_posY || Mathf.Abs(P_posYbf - P_posY) >= 10)
        {
            P_posYbf = P_posY;

        }

        //プレイヤーのいる地点からステージの終了地点を決める
        StageLength = P_posY + StageLength;

        //インスタンス用。中心X座標
        senter = (left + right) / 2;

        //釘の座標取得
        Nail_t = Nail.GetComponent<Transform>();
        Nail_t.position = new Vector3(5, Nail_t.position.y);

        //Wallの座標取得
        Wall_LRDS_T = Wall_LRDS.GetComponent<Transform>();
        Wall_LRDS_T.localScale = new Vector3(1, StageLength, 2.5f);

        Wall_BA_T = Wall_BA.GetComponent<Transform>();
        Wall_BA_T.localScale = new Vector3(Mathf.Abs(left) + Mathf.Abs(right), StageLength, 0.2f);
        WallGenerate();

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのy座標取得
        P_posY = (int)Player.transform.position.y;
        time = time + Time.deltaTime;

        if (P_posY <= -StageLength + (StageLength - 3))
        {
            stage_in = true;
        }

        //インスタンス条件
        //タイトル中
        if (!CMR.GetSetTitleEnd && BlockTime + 2 <= time)
        {
            BlockTime += 2;
            BlockGenerate();
        }
        //プレイ中
        else if (Nail_t.position.y - P_t.position.y <= distance &&//釘との距離で判定
            P_t.position.y >= -(StageLength - distance) &&
                NailTime <= time &&//一定間隔のインターバル
                P_posYbf > P_posY+0.5f)//落下していないときは生成しない
        {

            //確率でインスタンス
            switch (Random.Range(0, 100))
            {
                case 0:
                case 1:
                    //NGエリアのインスタンス
//                    NGAreaGenerate();
                    break;
                case <14:
                    //敵のインスタンス
                    EnemyGenerate();
                    break;
                case <39:
                    if (StageNumber == 2)
                        //敵のインスタンス
                        EnemyGenerate();
                    break;
                case 50:
                case 51:
                    //アイテム系のインスタンス
                    ItemGenerate();
                    break;
                case <55:
                    BlockGenerate();
                    break;
                default:
                    break;
            }
            
            //釘のインスタンス
            NailGenerate();
            NailTime += 0.13f;
        }
        //通り過ぎた釘を破壊
        else if (Nail_t.position.y > P_t.position.y + 10)
        {
            //初期設置釘の存在確認
            //if (Nail != null && !NailCheck)
            //{
            //    NailCheck = true;
            //    Destroy(Nail);//エラー表示
            //}
            if (c_nail != null) Destroy(c_nail);

        }
        else if (NailTime <= time)
        {
            NailTime += 0.13f;
        }

        //ゴールの生成
        if (P_t.position.y <= -(StageLength - distance) && !Goal_Gen)
        {
            Debug.Log("aa");
            GoalAreaGenerate();
            Goal_Gen = true;
        }


        //タグで釘を検索（おそらく最も古いもの）
        c_nail = GameObject.FindGameObjectWithTag("Nail");
        //釘の座標を保存(Yがほしい)
        Nail_t.position = new Vector3(5, c_nail.transform.position.y);

        if (time >= bfTime)
        {
            if (P_posYbf >= P_posY || Mathf.Abs(P_posYbf - P_posY) >= 10)
            {
                P_posYbf = P_posY;

            }
            bfTime += 0.5f;
        }
    }

    //---------------------------インスタンス-------------------------------//

    //タイトルブロックのインスタンス
    void BlockGenerate()
    {
        GameObject block = Instantiate(Block, new Vector3(Random.Range(-6, 6), Block.transform.position.y, Block.transform.position.z), Nrot);
        switch (Random.Range(0, 4))
        {
            case 0:
                block.transform.localScale /= 4;

                break;
            case 1:
                block.transform.localScale /= 3;

                break;
            case 2:
                block.transform.localScale /= 2;

                break;
            default:
                break;
        }


        if (Random.Range(0, 2) == 1)
        {
        }
    }

    //釘のインスタンス
    void NailGenerate()
    {
        //釘のインスタンス
        if (Nail_LR)
        {
            GameObject nailL = Instantiate(Nail, new Vector3(Random.Range(left, senter), P_posY - distance), Nailrot) as GameObject;
            //クローンの名前を変更
            nailL.name = "NailLeft";

            Nail_LR = false;
        }
        else
        {
            GameObject nailR = Instantiate(Nail, new Vector3(Random.Range(senter, right), P_posY - distance), Nailrot) as GameObject;
            //クローンの名前を変更
            nailR.name = "NailRight";
            Nail_LR = true;

        }
    }

    //敵のインスタンス
    void EnemyGenerate()
    {
        int side;
        side = Random.Range(0, 2);
        if (side == 0)
        {
            GameObject EnemyBox = Instantiate(Enemy, new Vector3(left, P_posY - distance, 0), Nailrot);
        }
        if (side == 1)
        {
            GameObject EnemyBox = Instantiate(Enemy, new Vector3(right, P_posY - distance, 0), Nailrot);
        }
    }

    //NGエリアのインスタンス
    void NGAreaGenerate()
    {
        Instantiate(NG, new Vector3(Random.Range(senter, right), P_posY - distance, 0), Nailrot);
    }

    //GOALエリアのインスタンス
    void GoalAreaGenerate()
    {
        Goal_posX = (left + right) / 2;
        Instantiate(Goal, new Vector3(Goal_posX, -StageLength + 2, 0), Nailrot);
    }


    //壁のインスタンス
    void WallGenerate()
    {
        

        Instantiate(Wall_LRDS, new Vector3(left, -StageLength / 2, 0), Nrot);
        Instantiate(Wall_LRDS, new Vector3(right, -StageLength / 2, 0), Nrot);

        //底
        GameObject WallDown = Instantiate(Wall_LRDS, new Vector3((left + right) / 2, -StageLength, 0), Nrot);
        WallDown.transform.localScale = new Vector3(Mathf.Abs(left) + Mathf.Abs(right), 1, depth);

        //前後
        Instantiate(Wall_BA, new Vector3((left + right) / 2, -StageLength / 2, -1.5f), Nrot);
        GameObject flont = Instantiate(Wall_BA, new Vector3((left + right) / 2, -StageLength / 2, 1.5f), Nrot);
        flont.transform.localScale = new Vector3(flont.transform.localScale.x, flont.transform.localScale.y + 30, flont.transform.localScale.z);
    }

    void ItemGenerate()
    {
        GameObject BigSmall = Instantiate(bigSmall, new Vector3(Random.Range(senter, right), P_posY - distance, 0), Nrot);
    }

    public bool GetStage_In
    {
        get { return stage_in; }
    }

    public int GetSetStageNumber
    {
        get { return StageNumber; }
        set { StageNumber = value; }
    }
}
