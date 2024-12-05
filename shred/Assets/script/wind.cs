using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wind : MonoBehaviour
{
    public float coefficient;   // ‹ó‹C’ïRŒW”
     Vector3 velocity;    // •—‘¬

    //•—Œü‚«
    Vector3 Left=new Vector3(8,0,0);
    Vector3 Right=new Vector3(-8,0,0);
    Vector3 Up=new Vector3(0,10,0);
    Vector3 Down=new Vector3(0,-8,0);

    [SerializeField, Header("Player")]
    GameObject Player;

    Transform P_t;
    Rigidbody rig;
    camera CMR;
    private void Start()
    {
        CMR=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camera>();
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
        if (!CMR.GetSetTitleEnd)
            return;
        Rigidbody rig;
        rig = col.GetComponent<Rigidbody>();

        if ( rig== null)
        {
            return;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        { velocity = Left; }
        else if (Input.GetKey(KeyCode.RightArrow))
        { velocity = Right; }
        else if (Input.GetKey(KeyCode.UpArrow))
        { velocity = Up; }
        else if (Input.GetKey(KeyCode.DownArrow))
        { velocity = Down; }

        // ‘Š‘Î‘¬“xŒvZ
        var relativeVelocity = velocity - rig.velocity;


        // ‹ó‹C’ïR‚ğ—^‚¦‚é
        rig.AddForce(coefficient * relativeVelocity);
    }
}
