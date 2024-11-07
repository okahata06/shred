using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("’e")]
    GameObject Bullet;

    Quaternion BulletRot;

    // Start is called before the first frame update
    void Start()
    {
        BulletRot=gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
       GameObject E_Bullet = Instantiate(Bullet,gameObject.transform.position,BulletRot);
    }
}
