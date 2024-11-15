using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wind : MonoBehaviour
{
    public float coefficient;   // ��C��R�W��
     Vector3 velocity;    // ����

    //������
    Vector3 Left=new Vector3(8,0,0);
    Vector3 Right=new Vector3(-8,0,0);
    Vector3 Up=new Vector3(0,10,0);
    Vector3 Down=new Vector3(0,-8,0);

    [SerializeField, Header("Player")]
    GameObject Player;

    Transform P_t;
    Rigidbody rig;

    private void Start()
    {
        velocity = Vector3.zero;
        P_t=Player.GetComponent<Transform>();    
    }

    private void Update()
    {
      //  Debug.Log(velocity);
        gameObject.transform.position = P_t.position;
    }
    void OnTriggerStay(Collider col)
    {
        
        Rigidbody rig;
        rig = col.GetComponent<Rigidbody>();

        if ( rig== null)
        {
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        { velocity = Left; }
        if (Input.GetKey(KeyCode.RightArrow))
        { velocity = Right; }
        if (Input.GetKey(KeyCode.UpArrow))
        { velocity = Up; }
        if (Input.GetKey(KeyCode.DownArrow))
        { velocity = Down; }

        // ���Α��x�v�Z
        var relativeVelocity = velocity - rig.velocity;


        // ��C��R��^����
        rig.AddForce(coefficient * relativeVelocity);
    }
}
