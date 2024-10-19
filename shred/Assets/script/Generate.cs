using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    int P_posY;
    int P_posYbf;
    int distance = 10;
    int distance_p = 15;
    float time;
    float bfTime=0;
    float NailTime = 0.5f;
    float left = -7.0f;
    float right = 7.0f;

    bool NailCheck;

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
    [SerializeField, Header("ステージ長さ")]
    int StageLength = 100;

    GameObject c_nail;

    //インスタンスの回転
    Quaternion rot = Quaternion.Euler(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの座標取得
        P_t = Player.GetComponent<Transform>();
        P_posY = (int)P_t.position.y;
        P_posYbf = P_posY;

        //プレイヤーのいる地点からステージの終了地点を決める
        StageLength = P_posY + StageLength;
        //釘の座標取得
        Nail_t = Nail.GetComponent<Transform>();
        Nail_t.position = new Vector3(5, Nail_t.position.y, P_t.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのy座標取得
        P_posY = (int)Player.transform.position.y;
        time = time + Time.deltaTime;


        //釘との距離と時間で判定
        if (Nail_t.position.y - P_t.position.y <= distance &&
                NailTime <= time &&
                P_posYbf > P_posY)//落下していないときは生成しないため
        {
            //釘のインスタンス
            NailGenerate();


            NailTime += 0.15f;
        }
        //通り過ぎた釘を破壊
        else if (Nail_t.position.y > P_t.position.y + 10)
        {
            if (Nail != null && !NailCheck)
            {
                NailCheck = true;
                Destroy(Nail);//初回以降エラー
            }
            if (c_nail != null) Destroy(c_nail);
        }
        else if (NailTime <= time)
        {
            NailTime += 0.15f;
        }


        c_nail = GameObject.FindGameObjectWithTag("Nail");

        Nail_t.position = new Vector3(5, c_nail.transform.position.y, P_t.position.z);

        if(time>=bfTime)
        {
            P_posYbf = P_posY;
            bfTime += 0.5f;
        }

    }


    void NailGenerate()
    {
        //釘のインスタンス
        GameObject nail = Instantiate(Nail, new Vector3(Random.Range(left + P_t.position.x, right + P_t.position.x), P_posY - distance_p, P_t.position.z), rot) as GameObject;
        //クローンの名前を変更
        nail.name = "Nail";



    }
}
