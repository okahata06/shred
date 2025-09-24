using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Transform Player_t;

    [SerializeField, Header("�e��")]
    float Bullet_Speed = 3;

    float bullet_C=0;//���ł܂ł̃J�E���g

    bool fastHit=true;

    Vector3 Bullet_vec;//�e�̕��o�x�N�g��

    Generate Gen;
    float StageNumber=1;
    //�G�t�F�N�g�擾�p
    EffectManager EM;
    GameObject BulletEffect;
    
    float c=0;
    float EF_cooltime;
    // Start is called before the first frame update
    void Start()
    {      
        //�G�t�F�N�g�擾
        EM=GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>();
        BulletEffect=EM.GetEffect2;
        
        //�X�e�[�W�擾
        Gen = GameObject.Find("Generater").GetComponent<Generate>();
        StageNumber = Gen.GetSetStageNumber;
        //�X�e�[�W���ɒe��/�G�t�F�N�g����
        if (StageNumber == 1) 
        { 
            EF_cooltime = 0.08f; 
        }
        else if (StageNumber == 2)
        {
            Bullet_Speed *= 1.2f;
            EF_cooltime = 0.06f;
        }
        else if (StageNumber == 3)
        {
            Bullet_Speed *= 2;
            EF_cooltime = 0.02f;
        }

        //�v���C���[�̍��W�擾
        Player_t = GameObject.Find("Hips").transform;

        //�v���C���[�����̃x�N�g�����擾
        Bullet_vec.x = Player_t.position.x-gameObject.transform.position.x;
        Bullet_vec.y = Player_t.position.y-gameObject.transform.position.y;
        //���K��
        Bullet_vec = Vector3.Normalize(Bullet_vec);

        //�x�N�g�������ɒe����t�^
        Bullet_vec = Bullet_vec * Bullet_Speed*Time.deltaTime;
    }

    // Update is called once per frame
    private void Update()
    {
        c+=Time.deltaTime;
        if(c>=EF_cooltime)
        {
            Instantiate(BulletEffect, transform.position, transform.rotation);
            c = 0;
        }
        //�x�N�g�������Ɉړ�
        transform.position += Bullet_vec;
        
        //���ŃJ�E���g
        bullet_C+=Time.deltaTime;
        if (bullet_C >= 5) { Destroy(gameObject); }
    }


    

    public bool E_FastHitGetSet
    {
        get { return  fastHit; }
    set { fastHit = value; }
    }
}
