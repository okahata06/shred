using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField,Header("�ʏ�z���W")]
    float C_posZ = 12;
    float C_posZKP = 12;   
    [SerializeField,Header("���Zy���W")]
    float C_posY = 5;
    float C_posYKP = 5;
    [SerializeField,Header("�ǐՑΏ�")]
    public GameObject target;

    [SerializeField, Header("�g�k��")]
    float MaxMove = 10;

    float move = 0.05f;

    float Count=0;//���ʎ��ԃJ�E���g�p
    int EndTime = 5;//���ʏI������

    bigSmall BigSmall;

    Transform c_transform;

    Quaternion Camera_rot=Quaternion.Euler(25,180,0);

    // Start is called before the first frame update
    void Start()
    {
        BigSmall=new bigSmall();
        MaxMove += C_posZ;
        c_transform= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Debug.Log(Count);
        Debug.Log(BigSmall.HitGetSet);

        //�����k��
        if (BigSmall.HitGetSet&&C_posZ<=MaxMove)
        {
            C_posZ += move;
        }
        //�����k��
        if(BigSmall.HitGetSet && C_posY <= MaxMove/2.7)
        {
            C_posY += move;

        }
        //���ʎ��ԃJ�E���g
        if(BigSmall.HitGetSet) 
        {
            Count+=Time.deltaTime;
        }
        if(Count >= EndTime)
        {
            BigSmall.HitGetSet = false;
            Count = 0;

        }



        //�����g��
        if (C_posZ>=C_posZKP)
        {
            C_posZ -= move;

            //�����g��
            if (Count >= EndTime && C_posY >= C_posYKP)
            {
                C_posY -= move;
            }
            else
            {
            }

        }

        c_transform.position = new Vector3(target.transform.position.x, target.transform.position.y+C_posY, C_posZ);

        c_transform.rotation = Camera_rot;

    }
}
