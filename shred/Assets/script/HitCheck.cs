using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    EnemyBullet EnemyBullet;

    BoxCollider BC;
    CapsuleCollider CC;

    bool E_BulletHit;
    int NailHit=0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyBullet = new EnemyBullet();
        E_BulletHit = EnemyBullet.E_FastHitGetSet;
        //��ʃR���C�_�[�̎擾
        if(gameObject.GetComponent<BoxCollider>() != null) {
        BC=gameObject.GetComponent<BoxCollider>();
        }
        if(gameObject.GetComponent<CapsuleCollider>() != null) { 
        CC=gameObject.GetComponent<CapsuleCollider>();
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        E_BulletHit = EnemyBullet.E_FastHitGetSet;

        //���ȏ㓖��������T�C�Y�������Ĕj�󂷂�
        if (col.gameObject.tag==("Nail")||col.gameObject.tag==("EnemyBullet")&&E_BulletHit)
        {
            NailHit++;
            if(col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }
            if (gameObject.name == ("LeftLeg"))//��������
            {
                if (NailHit == 30)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftCalf"))//���ӂ���͂�
            {
                if (NailHit == 20)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftFoot"))//������
            {
                if (NailHit == 10)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightLeg"))//�E������
            {
                if (NailHit == 30)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightCalf"))//�E�ӂ���͂�
            {
                if (NailHit == 20)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightFoot"))//�E����
            {
                if (NailHit == 10)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftUpperArm"))//����r
            {
                if (NailHit == 30)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftArm"))//���r
            {
                if (NailHit == 20)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftHand"))//����
            {
                if (NailHit == 10)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightUpperArm"))//�E��r
            {
                if (NailHit == 30)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightArm"))//�E�r
            {
                if (NailHit == 20)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightHand"))//�E��
            {
                if (NailHit == 10)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("Head"))//����
            {
                if (NailHit == 20)
                    transform.localScale = Vector3.zero;
            }


        }
    }
}
