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
        //��ʃR���C�_�[�̎擾
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

        //���ȏ㓖��������T�C�Y�������Ĕj�󂷂�
        if (col.gameObject.tag == ("Nail"))
        {
            AudioClip audio = (AudioClip)Resources.Load("�j��_�Z��");
            Hit_C++;
            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//��������
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftCalf"))//���ӂ���͂�
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftFoot"))//������
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightLeg"))//�E������
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightCalf"))//�E�ӂ���͂�
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightFoot"))//�E����
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftUpperArm"))//����r
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftArm"))//���r
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftHand"))//����
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightUpperArm"))//�E��r
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightArm"))//�E�r
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightHand"))//�E��
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("Head"))//����
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
        }
        //�e�ɓ��������ꍇ
        if ( col.gameObject.tag == ("EnemyBullet") && E_BulletHit)
        {
            Hit_C++;
            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//��������
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftCalf"))//���ӂ���͂�
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftFoot"))//������
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightLeg"))//�E������
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightCalf"))//�E�ӂ���͂�
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightFoot"))//�E����
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftUpperArm"))//����r
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftArm"))//���r
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("LeftHand"))//����
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightUpperArm"))//�E��r
            {
                if (Hit_C == thredbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightArm"))//�E�r
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("RightHand"))//�E��
            {
                if (Hit_C == fastbreak)
                    transform.localScale = Vector3.zero;
            }
            if (gameObject.name == ("Head"))//����
            {
                if (Hit_C == secondbreak)
                    transform.localScale = Vector3.zero;
            }


        }
    }
}
