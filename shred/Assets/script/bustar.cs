using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bustar : MonoBehaviour
{

    [SerializeField, Header("ˆÚ“®—Í")]
    float bust_power=0.1f;

    Rigidbody rig;

    Quaternion quaternion;
    Vector3 set;
    Vector3 bust;

    // Start is called before the first frame update
    void Start()
    {
       quaternion.z = gameObject.transform.rotation.z+90;
        set = new Vector3(0, bust_power, 0);
    }

    // Update is called once per frame
    void Update()
    {
        bust = Vector3.Normalize( quaternion.z * set);
        if(Input.GetKey(KeyCode.Space))
        {

            transform.position += bust;
        }
    }
}
