using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class HitCheck : MonoBehaviour
{

    EnemyBullet EnemyBullet;

    BoxCollider BC;
    CapsuleCollider CC;



    bool E_BulletHit;
    int fastbreak = 8;//��O�֐�
    int secondbreak = 15;//���֐�
    int thredbreak = 25;//���֐�
    int Hit_C = 0;
    //���ʔj�����̐U�����x��
    float VibLevel_Neil = 0.25f;
    float VibLevel_Bullet = 0.4f;


    //�G�t�F�N�g�擾�p
    EffectManager EM;
    GameObject HitEffect;
    GameObject BreakEffect;

    //�X�N���v�g���ŉ������Ă݂�
    AudioClip HitSE_nail;
    AudioClip HitSE_bullet;
    AudioClip BreakSE;
    AudioSource audiosource;
    AudioMixer audioMixer;

    //�J�����̐U��
    camera cmr;
    bool isVibration;

    // Start is called before the first frame update
    void Start()
    {
        //�J�����U��bool�擾
        cmr = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<camera>();

        //�G�t�F�N�g�擾
        EM = GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>();
        HitEffect = EM.GetEffect1;
        BreakEffect = EM.GetEffect3;
        //�X�N���v�g���ŉ������Ă݂�
        HitSE_nail = (AudioClip)Resources.Load("��^���{�b�g�̑���");//�����擾
        BreakSE = (AudioClip)Resources.Load("�j��");//�����擾
        HitSE_bullet = (AudioClip)Resources.Load("��^���{�b�g�̑���");//�����擾

        audiosource = gameObject.AddComponent<AudioSource>();//�R���|�쐬
        audioMixer = (AudioMixer)Resources.Load("AudioMixer");//�~�L�T�[�擾�B�O���[�v�����̎擾�͂ł��Ȃ�����
        audiosource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Hit")[0];//�~�L�T�[�O���[�v�̎擾


        EnemyBullet = new EnemyBullet();//���Ԃ�����΂��������G�t�F�N�g�Ɠ����悤�ɏ���������
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

            //Hit�G�t�F�N�g�Đ�
            Instantiate(HitEffect, transform.position, transform.rotation);

            //SE�Đ�
            audiosource.Play();

            Hit_C++;



            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//��������
            {
                if (Hit_C == thredbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("LeftCalf"))//���ӂ���͂�
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("LeftFoot"))//������
            {
                if (Hit_C == fastbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("RightLeg"))//�E������
            {
                if (Hit_C == thredbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("RightCalf"))//�E�ӂ���͂�
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("RightFoot"))//�E����
            {
                if (Hit_C == fastbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("LeftUpperArm"))//����r
            {
                if (Hit_C == thredbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("LeftArm"))//���r
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("LeftHand"))//����
            {
                if (Hit_C == fastbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("RightUpperArm"))//�E��r
            {
                if (Hit_C == thredbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("RightArm"))//�E�r
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("RightHand"))//�E��
            {
                if (Hit_C == fastbreak)
                {
                    Hit_Nail();
                }
            }
            else if (gameObject.name == ("Head"))//����
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Nail();        
                }
            }
        }
        //�e�ɓ��������ꍇ
        if (col.gameObject.tag == ("EnemyBullet") && E_BulletHit)
        {


            audiosource.clip = HitSE_bullet;//�����Z�b�g

            //Hit�G�t�F�N�g�Đ�
            Instantiate(HitEffect, transform.position, transform.rotation);

            //SE�Đ�
            audiosource.Play();


            Hit_C++;
            if (col.gameObject.tag == ("EnemyBullet"))
            { EnemyBullet.E_FastHitGetSet = true; }

            if (gameObject.name == ("LeftLeg"))//��������
            {
                if (Hit_C == thredbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("LeftCalf"))//���ӂ���͂�
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("LeftFoot"))//������
            {
                if (Hit_C == fastbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("RightLeg"))//�E������
            {
                if (Hit_C == thredbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("RightCalf"))//�E�ӂ���͂�
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("RightFoot"))//�E����
            {
                if (Hit_C == fastbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("LeftUpperArm"))//����r
            {
                if (Hit_C == thredbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("LeftArm"))//���r
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("LeftHand"))//����
            {
                if (Hit_C == fastbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("RightUpperArm"))//�E��r
            {
                if (Hit_C == thredbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("RightArm"))//�E�r
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("RightHand"))//�E��
            {
                if (Hit_C == fastbreak)
                {
                    Hit_Bullet();
                }
            }
            else if (gameObject.name == ("Head"))//����
            {
                if (Hit_C == secondbreak)
                {
                    Hit_Bullet();
                }
            }


        }
    }
    void Hit_Nail()
    {
        transform.localScale = Vector3.zero;
        audiosource.clip = BreakSE;
        audiosource.Play();
        //break�G�t�F�N�g�Đ�
        Instantiate(BreakEffect, transform.position, transform.rotation);
        //�J�����̐U���N��
        cmr.GetSetVibLevel = VibLevel_Neil;
        cmr.GetSetisViberation = true;
        //��莞�Ԍ�U����~
        Invoke("isVibrationFalse", 1.3f);
    }
    void Hit_Bullet()
    {
        transform.localScale = Vector3.zero;
        audiosource.clip = BreakSE;
        audiosource.Play();
        //break�G�t�F�N�g�Đ�
        Instantiate(BreakEffect, transform.position, transform.rotation);
        //�J�����̐U���N��
        cmr.GetSetVibLevel = VibLevel_Bullet;
        cmr.GetSetisViberation = true;
        //��莞�Ԍ�U����~
        Invoke("isVibrationFalse", 2);

    }

    bool isVibrationFalse()
    {
        return cmr.GetSetisViberation = false;
    }
}
