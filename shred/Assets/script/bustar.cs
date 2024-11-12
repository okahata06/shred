using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bustar : MonoBehaviour
{

    [SerializeField, Header("ˆÚ“®—Í")]
    float bust_power=0.1f;

    Rigidbody rig;
    //GameObject Hip;

    Quaternion quaternion;
    Vector3 set;
    Vector3 bust;

    // Start is called before the first frame update
    void Start()
    {
        //Hip = transform.parent.gameObject;
        quaternion.z = gameObject.transform.rotation.z+90;
        set = new Vector3(0, bust_power, 0);
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.LeftArrow)) { set.x = 10; }
        else
        {
            set.x = 0;
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)) { set.x = -10; }
        else 
        {
            set.x = 0;
        }
        bust = Vector3.Normalize( quaternion.z * set);
        if(Input.GetKey(KeyCode.Space))
        {
            rig.velocity += bust;
        }
    }
}
