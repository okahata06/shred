using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("’e")]
    GameObject Bullet;

    Quaternion BulletRot;
    int Go_count = 0;


    // Start is called before the first frame update
    void Start()
    {
        BulletRot=gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Go_count>=180)
        {
            GameObject E_Bullet = Instantiate(Bullet, gameObject.transform.position, BulletRot);
            Go_count = 0;
        }
        Go_count++;
    }
}
