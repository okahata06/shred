using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Transform Player_t;

    [SerializeField, Header("�e��")]
    float Bullet_Speed = 0.01f;

    int bullet_C=0;//���ł܂ł̃J�E���g

    bool fastHit=true;

    Vector3 Bullet_vec;//�e�̕��o�x�N�g��

    //�G�t�F�N�g�擾�p
    EffectManager EM;
    GameObject BulletEffect;
    GameObject Bullet_E;

    // Start is called before the first frame update
    void Start()
    {
        //�G�t�F�N�g�擾
        EM=GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>();
        BulletEffect=EM.GetEffect2;

        //�v���C���[�̍��W�擾
        Player_t = GameObject.Find("Hips").transform;

        //�v���C���[�����̃x�N�g�����擾
        Bullet_vec.x = Player_t.position.x-gameObject.transform.position.x;
        Bullet_vec.y = Player_t.position.y-gameObject.transform.position.y;
        //���K��
        Bullet_vec = Vector3.Normalize(Bullet_vec);

        //�x�N�g�������ɒe����t�^
        Bullet_vec = Bullet_vec * Bullet_Speed;
    }

    // Update is called once per frame
    private void Update()
    {

        //�x�N�g�������Ɉړ�
        transform.position += Bullet_vec;
        
        //���ŃJ�E���g
        bullet_C++;
        if (bullet_C >= 3000) { Destroy(gameObject); }
    }


    

    public bool E_FastHitGetSet
    {
        get { return  fastHit; }
    set { fastHit = value; }
    }
}
