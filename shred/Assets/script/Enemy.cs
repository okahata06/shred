using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("�e")]
    GameObject Bullet;

    [SerializeField,Header("�e��")]
    float B_Speed = 1;

    Vector2 B_vec = Vector2.right;//�e�̕��o�x�N�g��


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}