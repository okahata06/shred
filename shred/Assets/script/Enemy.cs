using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("Player")]
    GameObject Player;

    [SerializeField, Header("弾")]
    GameObject Bullet;

    Transform P_t;
    Quaternion BulletRot;
    float Go_count = 0;
    float inter=0;

    int StageNumber = 0;
    Generate Gen;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Hips");
        P_t = Player.transform;
        //弾の回転
        BulletRot = gameObject.transform.rotation;
        //ステージ取得
        Gen = GameObject.Find("Generater").GetComponent<Generate>();
        StageNumber = Gen.GetSetStageNumber;
        if(StageNumber == 1 || StageNumber == 2)
        {
            inter = 1.5f;
        }
        
        if (StageNumber == 3)
        {
            inter = 0.7f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //一定間隔＆プレイヤーの座標が下側じゃないとき
        if (Go_count >= inter && P_t.position.y - transform.position.y >= -1)
        {
            //インスタンス
            GameObject E_Bullet = Instantiate(Bullet, gameObject.transform.position, BulletRot);
            //クールタイムリセット
            Go_count = 0;
        }
        //180までカウント
        Go_count +=Time.deltaTime;
    }
}
