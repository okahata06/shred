using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isVisible : MonoBehaviour
{
    [SerializeField, Header("Player")]
    GameObject Player;
    Transform P_T;

    float posX;
    float posZ;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        P_T=Player.transform;
        posX = P_T.position.x;
        posZ = P_T.position.z;
        pos = P_T.position;
    }
    private void Update()
    {
        pos = new Vector3(posX,P_T.position.y+5,posZ);
        
        //Player‚ÌÀ•W‹ß‚­‚ÉˆÚ“®
        transform.position = pos;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.transform.position.y>=gameObject.transform.position.y)
        {
            Destroy(other.gameObject);
        }
    }
}
