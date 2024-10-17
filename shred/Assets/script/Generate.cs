using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    int P_posY;
    int distance = 10;
    float time;
    float NailTime=0.2f;
    float left = -7.0f;
    float right = 7.0f;

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

    //インスタンスの回転
    Quaternion rot = Quaternion.Euler(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの座標取得
        P_t=Player.GetComponent<Transform>();
        P_posY = (int)P_t.position.y;
        //プレイヤーのいる地点からステージの終了地点を決める
        StageLength=P_posY+StageLength;
        //釘の座標取得
        Nail_t=Nail.GetComponent<Transform>(); 
        Nail_t.position=new Vector3(5,Nail_t.position.y,P_t.position.z);
    
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのy座標取得
        P_posY = (int)Player.transform.position.y;
        time = time + Time.deltaTime;

        if (Nail_t.position.y - P_t.position.y >= distance &&
                NailTime <= time)
            {
            //釘のインスタンス
            Debug.Log(NailTime % 2 == 0);


            
            Instantiate(Nail, new Vector3(Random.Range(left + P_t.position.x, right + P_t.position.x), P_posY - distance, P_t.position.z), rot);
            
            Instantiate(Nail, new Vector3(Random.Range(left+P_t.position.x,right + P_t.position.x), P_posY-distance, P_t.position.z),rot);

                 NailTime += 0.5f;
            }
        else if (NailTime <= time)
        {
            NailTime += 0.5f;
        }
    }
}
