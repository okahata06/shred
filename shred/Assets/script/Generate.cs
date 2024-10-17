using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    int P_posY;
    int distance = 5;
    float NailTime=0.5f;
    int left = -6;
    int right = 6;

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
        Nail_t.position=new Vector3(5,Nail_t.position.y,P_t.position.z-distance);
    
    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーのy座標取得
        P_posY = (int)Player.transform.position.y;
        //Debug.Log(Mathf.Abs(P_posY));

        while (Mathf.Abs(P_posY) <= Mathf.Abs(StageLength))
        {
            //Debug.Log(StageLength);
            //if (Nail_t.position.y - P_t.position.y >= distance &&
            //    NailTime <= Time.deltaTime)
            //{

            //    //Instantiate(Nail);

            //    // NailTime += 0.5f;
            //}

            ////プレイヤーのy座標取得
            //P_posY = (int)Player.transform.position.y;
        }
    }
}
