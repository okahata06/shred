using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rean : MonoBehaviour
{
    float posY;
    float count=0;
    float move = 2f;
    float MAXmove = 0.2f;
    bool up=true;

    Vector3 pos;
    Vector3 MovePos;

    camera CMR;
    // Start is called before the first frame update
    void Start()
    {
        CMR=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camera>();
        pos = new Vector3(transform.position.x,transform.position.y,transform.position.z);  
    posY= transform.position.y;
        MAXmove += posY;
    }

    // Update is called once per frame
    void Update()
    {

        count += Time.deltaTime;
        if( up&&count>=2)
        {
            pos.y += move*Time.deltaTime;
        if(pos.y >= MAXmove) { up = false; count = 0; }
        }
        else if(!up)
        {
            pos.y -= move * Time.deltaTime;
            if (pos.y <= posY) { up = true; }

        }


        transform.position= pos;
    }

    private void OnCollisionStay(Collision col)
    {
        //タイトル中、プレイヤー以外を等しく移動させる

        if (!CMR.GetSetTitleEnd)//タイトル中かどうか
        {
            if(col.gameObject.CompareTag("Player"))
            {//プレイヤータグは移動しない
            col.rigidbody.velocity = Vector3.zero;
            }
            else
            {
                col.rigidbody.velocity = Vector3.forward * 2;
            }
        }
        else
        {
            col.rigidbody.velocity = Vector3.forward * 2;
        }
    }
}
