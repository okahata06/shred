using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.UI;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class HitCheck : MonoBehaviour
{
    EffectManager EM;
    GameObject effect;

    EnemyBullet EnemyBullet;

    BoxCollider BC;
    CapsuleCollider CC;



    bool E_BulletHit;
    int fastbreak=10;//��O�֐�
    int secondbreak=20;//���֐�
    int thredbreak=30;//���֐�
    int Hit_C = 0;


    //�X�N���v�g���ŉ������Ă݂�
    AudioClip HitSE_nail;
    AudioClip HitSE_bullet;
    AudioSource audiosource;
    AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        EM = GameObject.Find("effectManager").GetComponent<EffectManager>();
        effect = EM.Get1Effect;
        Debug.Log(EM.name);
        Debug.Log(effect.name);
        //�X�N���v�g���ŉ������Ă݂�
        HitSE_nail = (AudioClip)Resources.Load("��^���{�b�g�̑���");//�����擾
        HitSE_bullet = (AudioClip)Resources.Load("��^���{�b�g�̑���");//�����擾

        audiosource =gameObject.AddComponent<AudioSource>();//�R���|�쐬
        audioMixer= (AudioMixer)Resources.Load("AudioMixer");//�~�L�T�[�擾�B�O���[�v�����̎擾�͂ł��Ȃ�����
        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Hit")[0];//�~�L�T�[�O���[�v�̎擾


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

            audiosource.clip = HitSE_nail;//�����Z�b�g

            Instantiate(effect,transform.position,transform.rotation);

            //SE�Đ�
            audiosource.Play();

            Hit_C++;
            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//��������
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftCalf"))//���ӂ���͂�
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftFoot"))//������
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightLeg"))//�E������
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightCalf"))//�E�ӂ���͂�
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightFoot"))//�E����
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftUpperArm"))//����r
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftArm"))//���r
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("LeftHand"))//����
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightUpperArm"))//�E��r
            {
                if (Hit_C == thredbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightArm"))//�E�r
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("RightHand"))//�E��
            {
                if (Hit_C == fastbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
            if (gameObject.name == ("Head"))//����
            {
                if (Hit_C == secondbreak)
                {
                    transform.localScale = Vector3.zero;
                    Instantiate(effect, gameObject.transform.position, Quaternion.identity);
                }
            }
        }
        //�e�ɓ��������ꍇ
        if ( col.gameObject.tag == ("EnemyBullet") && E_BulletHit)
        {


            audiosource.clip = HitSE_bullet;//�����Z�b�g

            //SE�Đ�
            audiosource.Play();

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
