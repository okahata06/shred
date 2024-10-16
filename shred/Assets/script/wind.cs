using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : MonoBehaviour
{
    public float coefficient;   // ��C��R�W��
    public Vector3 velocity;    // ����

    Rigidbody rig;

    private void Start()
    {
    }
    void OnTriggerStay(Collider col)
    {
        Rigidbody rig;
        rig = col.GetComponent<Rigidbody>();

        if ( rig== null)
        {
            return;
        }

        // ���Α��x�v�Z
        var relativeVelocity = velocity - rig.velocity;

        // ��C��R��^����
        rig.AddForce(coefficient * relativeVelocity);
    }
}
