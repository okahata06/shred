using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Transform Player_t;

    [SerializeField, Header("弾速")]
    float Bullet_Speed = 3;

    float bullet_C=0;//消滅までのカウント

    bool fastHit=true;

    Vector3 Bullet_vec;//弾の放出ベクトル

    Generate Gen;
    float StageNumber=1;
    //エフェクト取得用
    EffectManager EM;
    GameObject BulletEffect;
    
    float c=0;
    float EF_cooltime;
    // Start is called before the first frame update
    void Start()
    {      
        //エフェクト取得
        EM=GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>();
        BulletEffect=EM.GetEffect2;
        
        //ステージ取得
        Gen = GameObject.Find("Generater").GetComponent<Generate>();
        StageNumber = Gen.GetSetStageNumber;
        //ステージ事に弾速/エフェクト調整
        if (StageNumber == 1) 
        { 
            EF_cooltime = 0.08f; 
        }
        else if (StageNumber == 2)
        {
            Bullet_Speed *= 1.2f;
            EF_cooltime = 0.06f;
        }
        else if (StageNumber == 3)
        {
            Bullet_Speed *= 2;
            EF_cooltime = 0.02f;
        }

        //プレイヤーの座標取得
        Player_t = GameObject.Find("Hips").transform;

        //プレイヤー方向のベクトルを取得
        Bullet_vec.x = Player_t.position.x-gameObject.transform.position.x;
        Bullet_vec.y = Player_t.position.y-gameObject.transform.position.y;
        //正規化
        Bullet_vec = Vector3.Normalize(Bullet_vec);

        //ベクトル方向に弾速を付与
        Bullet_vec = Bullet_vec * Bullet_Speed*Time.deltaTime;
    }

    // Update is called once per frame
    private void Update()
    {
        c+=Time.deltaTime;
        if(c>=EF_cooltime)
        {
            Instantiate(BulletEffect, transform.position, transform.rotation);
            c = 0;
        }
        //ベクトル方向に移動
        transform.position += Bullet_vec;
        
        //消滅カウント
        bullet_C+=Time.deltaTime;
        if (bullet_C >= 5) { Destroy(gameObject); }
    }


    

    public bool E_FastHitGetSet
    {
        get { return  fastHit; }
    set { fastHit = value; }
    }
}
