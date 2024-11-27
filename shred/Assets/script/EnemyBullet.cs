using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Transform Player_t;

    [SerializeField, Header("弾速")]
    float Bullet_Speed = 0.01f;

    int bullet_C=0;//消滅までのカウント

    bool fastHit=true;

    Vector3 Bullet_vec;//弾の放出ベクトル

    //エフェクト取得用
    EffectManager EM;
    GameObject BulletEffect;
    GameObject Bullet_E;

    // Start is called before the first frame update
    void Start()
    {
        //エフェクト取得
        EM=GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>();
        BulletEffect=EM.GetEffect2;

        //プレイヤーの座標取得
        Player_t = GameObject.Find("Hips").transform;

        //プレイヤー方向のベクトルを取得
        Bullet_vec.x = Player_t.position.x-gameObject.transform.position.x;
        Bullet_vec.y = Player_t.position.y-gameObject.transform.position.y;
        //正規化
        Bullet_vec = Vector3.Normalize(Bullet_vec);

        //ベクトル方向に弾速を付与
        Bullet_vec = Bullet_vec * Bullet_Speed;
    }

    // Update is called once per frame
    private void Update()
    {

        //ベクトル方向に移動
        transform.position += Bullet_vec;
        
        //消滅カウント
        bullet_C++;
        if (bullet_C >= 3000) { Destroy(gameObject); }
    }


    

    public bool E_FastHitGetSet
    {
        get { return  fastHit; }
    set { fastHit = value; }
    }
}
