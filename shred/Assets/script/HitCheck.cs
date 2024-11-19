using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    EnemyBullet EnemyBullet;

    BoxCollider BC;
    CapsuleCollider CC;

    bool E_BulletHit;
    int fastbreak=10;
    int secondbreak=20;
    int thredbreak=30;
    int Hit_C = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyBullet = new EnemyBullet();
        E_BulletHit = EnemyBullet.E_FastHitGetSet;
        //éÌï ÉRÉâÉCÉ_Å[ÇÃéÊìæ
        if (gameObject.GetComponent<BoxCollider>() != null)
        {
            BC = gameObject.GetComponent<BoxCollider>();
        }
        if (gameObject.GetComponent<CapsuleCollider>() != null)
        {
            CC = gameObject.GetComponent<CapsuleCollider>();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        E_BulletHit = EnemyBullet.E_FastHitGetSet;

        //àÍíËà»è„ìñÇΩÇ¡ÇΩÇÁÉTÉCÉYÇè¡ÇµÇƒîjâÛÇ∑ÇÈ
        if (col.gameObject.tag == ("Nail"))
        {
            AudioClip audio = (AudioClip)Resources.Load("îjâÛâπ_íZÇ¢");
            Hit_C++;
            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//ç∂ëæÇ‡Ç‡
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftCalf"))//ç∂Ç”Ç≠ÇÁÇÕÇ¨
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftFoot"))//ç∂ë´êÊ
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightLeg"))//âEëæÇ‡Ç‡
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightCalf"))//âEÇ”Ç≠ÇÁÇÕÇ¨
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightFoot"))//âEë´êÊ
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftUpperArm"))//ç∂è„òr
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftArm"))//ç∂òr
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftHand"))//ç∂éË
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightUpperArm"))//âEè„òr
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightArm"))//âEòr
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightHand"))//âEéË
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("Head"))//ì™ïî
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
        }
        //íeÇ…ìñÇΩÇ¡ÇΩèÍçá
        if ( col.gameObject.tag == ("EnemyBullet") && E_BulletHit)
        {
            Hit_C++;
            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//ç∂ëæÇ‡Ç‡
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftCalf"))//ç∂Ç”Ç≠ÇÁÇÕÇ¨
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftFoot"))//ç∂ë´êÊ
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightLeg"))//âEëæÇ‡Ç‡
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightCalf"))//âEÇ”Ç≠ÇÁÇÕÇ¨
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightFoot"))//âEë´êÊ
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftUpperArm"))//ç∂è„òr
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftArm"))//ç∂òr
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftHand"))//ç∂éË
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightUpperArm"))//âEè„òr
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightArm"))//âEòr
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightHand"))//âEéË
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("Head"))//ì™ïî
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }


        }
    }
}
