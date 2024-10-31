using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    int P_posY;
    int P_posYbf;
    int distance = 25;//Playerとインスタンスする釘の距離
    int Goal_posX = 0;



    float time;//経過時間
    float bfTime = 0;//player座標チェック用
    float NailTime = 0.5f;//釘召喚用

    bool NailCheck;
    bool Nail_LR = false;//釘の召喚をばらけさせるため。右がfalse
    bool Goal_Gen = false;

    [SerializeField, Header("プレイヤー")]
    GameObject Player;
    Transform P_t;
    [SerializeField, Header("釘")]
    GameObject Nail;
    Transform Nail_t;
  
    [SerializeField, Header("NGエリア")]
    GameObject NG;
    [SerializeField, Header("ゴール")]
    GameObject Goal;
    [SerializeField, Header("ステージ横壁")]
    GameObject Wall_LR;
    Transform Wall_LR_T;
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

    GameObject c_nail;

    //インスタンス用無回転
    Quaternion Nrot = Quaternion.identity;

    //釘インスタンスの回転
    Quaternion Nailrot = Quaternion.Euler(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの座標取得
        P_t = Player.GetComponent<Transform>();
        P_posY = (int)P_t.position.y;
        P_posYbf = P_posY;

        //釘の座標取得
        Nail_t = Nail.GetComponent<Transform>();
        Nail_t.position = new Vector3(5, Nail_t.position.y, P_t.position.z);

        //Wallの座標取得
        Wall_LR_T = Wall_LR.GetComponent<Transform>();
        Wall_LR_T.localScale = new Vector3(1, StageLength, 2);
        
        Wall_BA_T=Wall_BA.GetComponent<Transform>();
        Wall_BA_T.localScale = new Vector3((left + right), StageLength);
        WallGenerate();

        //プレイヤーのいる地点からステージの終了地点を決める
        StageLength = P_posY + StageLength;

        //インスタンス用。中心X座標
        senter = (left + right) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのy座標取得
        P_posY = (int)Player.transform.position.y;
        time = time + Time.deltaTime;


        //釘のインスタンス
        if (Nail_t.position.y - P_t.position.y <= distance &&//釘との距離で判定
            P_t.position.y>=-(StageLength-distance)&&
                NailTime <= time &&//一定間隔のインターバル
                P_posYbf > P_posY)//落下していないときは生成しない
        {
            //釘のインスタンス
            NailGenerate();
            NailTime += 0.15f;
        }
        //通り過ぎた釘を破壊
        else if (Nail_t.position.y > P_t.position.y + 10)
        {
            //初期設置釘の存在確認
            if (Nail != null && !NailCheck)
            {
                NailCheck = true;
                Destroy(Nail);//エラー表示
            }
            if (c_nail != null) Destroy(c_nail);

        }
        else if (NailTime <= time)
        {
            NailTime += 0.15f;
        }

        //ゴールの生成
        if(P_t.position.y <= -(StageLength - distance))
        {
            Debug.Log("aa");
            GoalAreaGenerate();
            Goal_Gen=true;
        }



        //タグで釘を検索（おそらく最も古いもの）
        c_nail = GameObject.FindGameObjectWithTag("Nail");
        //釘の座標を保存(Yがほしい)
        Nail_t.position = new Vector3(5, c_nail.transform.position.y, P_t.position.z);

        if (time >= bfTime)
        {
            P_posYbf = P_posY;
            bfTime += 0.5f;
        }

    }

    //釘のインスタンス
    void NailGenerate()
    {
        //釘のインスタンス
        if (Nail_LR)
        {
            GameObject nailL = Instantiate(Nail, new Vector3(Random.Range(left, senter), P_posY - distance, P_t.position.z), Nailrot) as GameObject;
            //クローンの名前を変更
            nailL.name = "NailLeft";

            Nail_LR = false;
        }
        else
        {
            GameObject nailR = Instantiate(Nail, new Vector3(Random.Range(senter, right), P_posY - distance, P_t.position.z), Nailrot) as GameObject;
            //クローンの名前を変更
            nailR.name = "NailRight";
            Nail_LR = true;

        }
    }
    
    //NGエリアのインスタンス
    void NGAreaGenerate()
    {
        Instantiate(NG, new Vector3(left, -StageLength / 2, 0), Nailrot);
    }

    //GOALエリアのインスタンス
    void GoalAreaGenerate()
    {
        Instantiate(Goal, new Vector3((left+right)/2, -StageLength / 2, 0), Nailrot);
    }
    
    
    //壁のインスタンス
    void WallGenerate()
    {
        //壁のインスタンス
        Instantiate(Wall_LR, new Vector3(left, -StageLength / 2, 0), Nrot);
        Instantiate(Wall_LR, new Vector3(right, -StageLength / 2, 0), Nrot);


        Instantiate(Wall_BA, new Vector3((left + right) / 2, -StageLength / 2, 0), Nrot);
    }


}
