using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Transform Player_t;

    [SerializeField, Header("’e‘¬")]
    float Bullet_Speed = 0.01f;

    int bullet_C=0;
    Vector3 Bullet_vec;//’e‚Ì•úoƒxƒNƒgƒ‹

    // Start is called before the first frame update
    void Start()
    {
        Player_t = GameObject.Find("Hips").transform;
        Bullet_vec = Player_t.position-gameObject.transform.position;
        Bullet_vec =Vector3.Normalize(Bullet_vec);


        Bullet_vec = Bullet_vec * Bullet_Speed;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += Bullet_vec;
        bullet_C++;
        if (bullet_C >= 3000) { Destroy(gameObject); }
    }


    private void OnCollisionEnter(Collision col)
    {

    }
}
