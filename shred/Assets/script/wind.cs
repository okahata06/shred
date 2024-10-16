using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : MonoBehaviour
{
    public float coefficient;   // ‹ó‹C’ïRŒW”
    public Vector3 velocity;    // •—‘¬

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

        // ‘Š‘Î‘¬“xŒvZ
        var relativeVelocity = velocity - rig.velocity;

        // ‹ó‹C’ïR‚ğ—^‚¦‚é
        rig.AddForce(coefficient * relativeVelocity);
    }
}
