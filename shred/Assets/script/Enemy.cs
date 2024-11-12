using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField, Header("Player")]
    GameObject Player;

    [SerializeField, Header("�e")]
    GameObject Bullet;

    Transform P_t;
    Quaternion BulletRot;
    int Go_count = 0;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Hips");
        P_t = Player.transform;
        //�e�̉�]
        BulletRot = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԋu���v���C���[�̍��W����������Ȃ��Ƃ�
        if(Go_count>=180&&P_t.position.y-transform.position.y>=-1)
        {
            //�C���X�^���X
            GameObject E_Bullet = Instantiate(Bullet, gameObject.transform.position, BulletRot);
            //�N�[���^�C�����Z�b�g
            Go_count = 0;
        }
        //180�܂ŃJ�E���g
        Go_count++;
    }
}
