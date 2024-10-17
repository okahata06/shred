using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{

    Transform transform;

    Quaternion Camera_rot=Quaternion.Euler(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        transform= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera_rot;
    }
}
