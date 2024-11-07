using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField, Header("PlayerTransform")]
    Transform Player_t;

    [SerializeField, Header("弾速")]
    float Bullet_Speed = 0.01f;


    Vector3 Bullet_vec;//弾の放出ベクトル

    // Start is called before the first frame update
    void Start()
    {
        Bullet_vec = Player_t.position-transform.parent.gameObject.transform.position;

        Bullet_vec =Normalize(Bullet_vec);
        
        Bullet_vec = Bullet_vec * Bullet_Speed;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Bullet_vec;
    }


    private void OnCollisionEnter(Collision col)
    {

    }
}
