using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static Cinemachine.DocumentationSortingAttribute;

public class camera : MonoBehaviour
{
    [SerializeField,Header("�ʏ�z���W")]
    float C_posZ = 12;
    float C_posZKP = 12;   
    [SerializeField,Header("�ʏ�y���W")]
    float C_posY = 5;
    float C_posYKP = 5;
    [SerializeField,Header("�ǐՑΏ�")]
    public GameObject target;

    [SerializeField, Header("�g�k��")]
    float MaxMoveZ = 10;
    [SerializeField]
    float MaxMoveY = 10;

    float move = 0.03f;

    float Count=0;//���ʎ��ԃJ�E���g�p
    [SerializeField,Header("���ʎ���(�b)")]
    int EndTime = 10;


    float vibLevel = 0.7f;//�h��̑傫��
    bool isVib = false;

bigSmall BigSmall;

    Transform c_transform;

    //�^�C�g����ʎ��̃J�������W
    Vector3 Title_pos;
    Quaternion title_rot = Quaternion.Euler(25, 180, 0);

    //�Q�[�����̃J�������W
    Vector3 PlayMode_pos;
    Quaternion PlayMode_rot=Quaternion.Euler(25,180,0);

    // Start is called before the first frame update
    void Start()
    {
        BigSmall=new bigSmall();
        MaxMoveZ += C_posZ;
        MaxMoveY += C_posY;
        c_transform= GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {

        //�����k��
        if (BigSmall.HitGetSet&&C_posZ<=MaxMoveZ)
        {
            C_posZ += move;
        }
        //�����k��
        if(BigSmall.HitGetSet && C_posY <= MaxMoveY/2.5)
        {
            C_posY += move/2;

        }
        //���ʎ��ԃJ�E���g
        if(BigSmall.HitGetSet) 
        {
            Count+=Time.deltaTime;
            //���Ԍo�ߌ�I��
            if (Count >= EndTime)
            {
                BigSmall.HitGetSet = false;
                Count = 0;

            }

        }
        


        //�����g��
        if (C_posZ>=C_posZKP&&Count==0)
        {
            C_posZ -= move;            

        }
        //�����g��
        if (C_posY >= C_posYKP && Count == 0)
        {
            C_posY -= move/2;
        }

        //�v���C���̍��W
        PlayMode_pos = new Vector3(target.transform.position.x, target.transform.position.y + C_posY, C_posZ);

        if(isVib)
        {
            c_transform.position = PlayMode_pos+new Vector3(Randomvibration(vibLevel),Randomvibration(vibLevel), Randomvibration(vibLevel));

        }
        else
        {
            c_transform.position = PlayMode_pos;

        }
        c_transform.rotation = PlayMode_rot;

    }

    float Randomvibration(float strength)
    {
        float vibration = 0;
        vibration = UnityEngine.Random.Range(-strength, strength);

        //���̍��W�ɐU���ʂ�Ԃ��đ���
        return vibration;
    }

    public bool GetSetisViberation
    {
        get { return isVib; } 
        set { isVib = value; }
    }

    public float GetSetVibLevel
    {
        get { return vibLevel; }
        set { vibLevel = value; }
    }
}
