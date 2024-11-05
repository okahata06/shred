using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitCheck : MonoBehaviour
{

    BoxCollider BC;
    CapsuleCollider CC;

    int NailHit=0;

    // Start is called before the first frame update
    void Start()
    {
        //種別コライダーの取得
        if(gameObject.GetComponent<BoxCollider>() != null) {
        BC=gameObject.GetComponent<BoxCollider>();
        }
        if(gameObject.GetComponent<CapsuleCollider>() != null) { 
        CC=gameObject.GetComponent<CapsuleCollider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision col)
    {
        NailHit++;
        Debug.Log(NailHit);
        if (NailHit == 20)
            this.gameObject.transform.localScale =new Vector3(3,3,3);
    }
}
