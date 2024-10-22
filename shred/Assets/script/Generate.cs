using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    int P_posY;
    int P_posYbf;
    int distance = 10;
    int distance_p = 15;
    float time;
    float bfTime=0;
    float NailTime = 0.5f;

    bool NailCheck;

    [SerializeField, Header("�v���C���[")]
    GameObject Player;
    Transform P_t;
    [SerializeField, Header("�B")]
    GameObject Nail;
    Transform Nail_t;
    [SerializeField, Header("NG�G���A")]
    GameObject NG;
    [SerializeField, Header("�S�[��")]
    GameObject Goal;
    [SerializeField, Header("�X�e�[�W��")]
    GameObject Wall;
    Transform Wall_T;
    [SerializeField, Header("�X�e�[�W����")]
    int StageLength = 100;
    [SerializeField, Header("�X�e�[�W��X���W")]
    float left=-5;
    [SerializeField]
    float right = 5;
    float depth = -2;

    GameObject c_nail;

    //�C���X�^���X�p����]
    Quaternion Nrot=Quaternion.identity;

    //�B�C���X�^���X�̉�]
    Quaternion Nailrot = Quaternion.Euler(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̍��W�擾
        P_t = Player.GetComponent<Transform>();
        P_posY = (int)P_t.position.y;
        P_posYbf = P_posY;

        //�B�̍��W�擾
        Nail_t = Nail.GetComponent<Transform>();
        Nail_t.position = new Vector3(5, Nail_t.position.y, P_t.position.z);

        //Wall�̍��W�擾
        Wall_T=Wall.GetComponent<Transform>();
        Wall_T.localScale=new Vector3(1,StageLength,2);
        WallGenerate();
        //�v���C���[�̂���n�_����X�e�[�W�̏I���n�_�����߂�
        StageLength = P_posY + StageLength;
        

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[��y���W�擾
        P_posY = (int)Player.transform.position.y;
        time = time + Time.deltaTime;


        //�B�Ƃ̋����Ǝ��ԂŔ���
        if (Nail_t.position.y - P_t.position.y <= distance &&
                NailTime <= time &&
                P_posYbf > P_posY)//�������Ă��Ȃ��Ƃ��͐������Ȃ�����
        {
            //�B�̃C���X�^���X
            NailGenerate();


            NailTime += 0.15f;
        }
        //�ʂ�߂����B��j��
        else if (Nail_t.position.y > P_t.position.y + 10)
        {
            if (Nail != null && !NailCheck)
            {
                NailCheck = true;
                Destroy(Nail);//����ȍ~�G���[
            }
            if (c_nail != null) Destroy(c_nail);
        }
        else if (NailTime <= time)
        {
            NailTime += 0.15f;
        }


        c_nail = GameObject.FindGameObjectWithTag("Nail");

        Nail_t.position = new Vector3(5, c_nail.transform.position.y, P_t.position.z);

        if(time>=bfTime)
        {
            P_posYbf = P_posY;
            bfTime += 0.5f;
        }

    }

    //�B�̃C���X�^���X
    void NailGenerate()
    {
        //�B�̃C���X�^���X
        GameObject nail = Instantiate(Nail, new Vector3(Random.Range(left + P_t.position.x, right + P_t.position.x), P_posY - distance_p, P_t.position.z), Nailrot) as GameObject;
        //�N���[���̖��O��ύX
        nail.name = "Nail";

    }

    //�ǂ̃C���X�^���X
    void WallGenerate()
    {
        //�ǂ̃C���X�^���X
        Instantiate(Wall, new Vector3(left, -StageLength / 2, 0), Nrot);
        Instantiate(Wall, new Vector3(right, -StageLength / 2, 0), Nrot);

    }

}
