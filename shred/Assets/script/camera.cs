using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField,Header("í èÌzç¿ïW")]
    int C_posZ = -20;
    [SerializeField,Header("í«ê’ëŒè€")]
    public GameObject target;

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

        c_transform.position = new Vector3(target.transform.position.x, target.transform.position.y+5, C_posZ);

        c_transform.rotation = Camera_rot;

    }
}
