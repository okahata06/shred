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

        //一定以上当たったらサイズを消して破壊する
        if(col.gameObject.tag==("Nail"))
        {
            NailHit++;
            Debug.Log(NailHit);

            if (gameObject.name == ("LeftLeg"))//左太もも
            {
                if (NailHit == 30)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftCalf"))//左ふくらはぎ
            {
                if (NailHit == 15)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftFoot"))//左足先
            {
                if (NailHit == 5)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightLeg"))//右太もも
            {
                if (NailHit == 30)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightCalf"))//右ふくらはぎ
            {
                if (NailHit == 15)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightFoot"))//右足先
            {
                if (NailHit == 5)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftUpperArm"))//左上腕
            {
                if (NailHit == 30)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftArm"))//左腕
            {
                if (NailHit == 15)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftHand"))//左手
            {
                if (NailHit == 5)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightUpperArm"))//右上腕
            {
                if (NailHit == 30)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightArm"))//右腕
            {
                if (NailHit == 5)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightHand"))//右手
            {
                if (NailHit == 5)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("Head"))//頭部
            {
                if (NailHit == 20)
                    transform.localScale = Vector3.zero;
            }


        }
    }
}
