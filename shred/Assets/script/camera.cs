using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{

    int C_posZ = -20;
    public GameObject agameobject;
    Transform c_transform;

    Quaternion Camera_rot=Quaternion.Euler(25,0,0);

    // Start is called before the first frame update
    void Start()
    {
        c_transform= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        c_transform.position = new Vector3(agameobject.transform.position.x, agameobject.transform.position.y+7, C_posZ);

        c_transform.rotation = Camera_rot;

    }
}
