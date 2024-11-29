using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rean : MonoBehaviour
{

    float count=0;
    float move = 0.01f;
    float MAXmove = 1;

    bool up = true;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        MAXmove += pos.y;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count>=2&&up)
        {
            pos.y += move;
            if(pos.y==MAXmove)
            {
                count = 0;
                up = false;
            }
        }
        else if(pos.y<=MAXmove)

        transform.position = pos;
    }
}
