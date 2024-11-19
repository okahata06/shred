using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Switch;

public class Generate : MonoBehaviour
{
    int P_posY;
    int P_posYbf;
    int distance = 25;//Player�ƃC���X�^���X����B�̋���
    int Enemy_pos;


    float time;//�o�ߎ���
    float bfTime = 0;//player���W�`�F�b�N�p
    float NailTime = 0.5f;//�B�����p
    float Goal_posX = 0;

    bool NailCheck;
    bool Nail_LR = false;//�B�̏������΂炯�����邽�߁B�E��false
    bool Goal_Gen = false;

    [SerializeField, Header("�v���C���[")]
    GameObject Player;
    Transform P_t;
    [SerializeField, Header("�G�l�~�[")]
    GameObject Enemy;
    [SerializeField, Header("�B")]
    GameObject Nail;
    Transform Nail_t;
    [SerializeField, Header("�A�C�e��")]
    GameObject bigSmall;
    [SerializeField]
    GameObject Slot;

    [SerializeField, Header("NG�G���A")]
    GameObject NG;
    [SerializeField, Header("�S�[��")]
    GameObject Goal;
    [SerializeField, Header("�X�e�[�W����")]
    GameObject Wall_LRDS;
    Transform Wall_LRDS_T;
    [SerializeField, Header("�X�e�[�W�O���")]
    GameObject Wall_BA;
    Transform Wall_BA_T;

    [SerializeField, Header("�X�e�[�W����")]
    int StageLength = 100;
    [SerializeField, Header("�X�e�[�W��X���W")]
    float left = -5;
    [SerializeField]
    float right = 5;
    
    float senter = 0;
    float depth = -2;

    GameObject c_nail;

    //�C���X�^���X�p����]
    Quaternion Nrot = Quaternion.identity;

    //�B�C���X�^���X�̉�]
    Quaternion Nailrot = Quaternion.Euler(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

        //�v���C���[�̍��W�擾
        P_t = Player.GetComponent<Transform>();
        P_posY = (int)P_t.position.y;
        P_posYbf = P_posY;

        //�v���C���[�̂���n�_����X�e�[�W�̏I���n�_�����߂�
        StageLength = P_posY + StageLength;

        //�C���X�^���X�p�B���SX���W
        senter = (left + right) / 2;

        //�B�̍��W�擾
        Nail_t = Nail.GetComponent<Transform>();
        Nail_t.position = new Vector3(5, Nail_t.position.y);

        //Wall�̍��W�擾
        Wall_LRDS_T = Wall_LRDS.GetComponent<Transform>();
        Wall_LRDS_T.localScale = new Vector3(1, StageLength, 2.5f);
        
        Wall_BA_T=Wall_BA.GetComponent<Transform>();
        Wall_BA_T.localScale = new Vector3(Mathf.Abs(left) + Mathf.Abs(right), StageLength,0.2f);
        WallGenerate();

    }

    // Update is called once per frame
    void Update()
    {

        //�v���C���[��y���W�擾
        P_posY = (int)Player.transform.position.y;
        time = time + Time.deltaTime;
        //�C���X�^���X����
        if (Nail_t.position.y - P_t.position.y <= distance &&//�B�Ƃ̋����Ŕ���
            P_t.position.y>=-(StageLength-distance)&&
                NailTime <= time &&//���Ԋu�̃C���^�[�o��
                P_posYbf > P_posY)//�������Ă��Ȃ��Ƃ��͐������Ȃ�
        {
            //�m���ŃC���X�^���X
            switch (Random.Range(0, 60))
            {
                case 0:
                case 1:
                    //NG�G���A�̃C���X�^���X
                    NGAreaGenerate();
                    break;
                case 2:
                case 3:
                case 4:
                    //�G�̃C���X�^���X
                    EnemyGenerate();
                    break;
                case 5:
                case 6:
                    //�A�C�e���n�̃C���X�^���X
                    ItemGenerate();
                    break;
                default:
                    break;
            }

            //�B�̃C���X�^���X
            NailGenerate();
            NailTime += 0.15f;
        }
        //�ʂ�߂����B��j��
        else if (Nail_t.position.y > P_t.position.y + 10)
        {
            //�����ݒu�B�̑��݊m�F
            //if (Nail != null && !NailCheck)
            //{
            //    NailCheck = true;
            //    Destroy(Nail);//�G���[�\��
            //}
            if (c_nail != null) Destroy(c_nail);

        }
        else if (NailTime <= time)
        {
            NailTime += 0.15f;
        }

        //�S�[���̐���
        if(P_t.position.y <= -(StageLength - distance)&&!Goal_Gen)
        {
            Debug.Log("aa");
            GoalAreaGenerate();
            Goal_Gen=true;
        }



        //�^�O�œB�������i�����炭�ł��Â����́j
        c_nail = GameObject.FindGameObjectWithTag("Nail");
        //�B�̍��W��ۑ�(Y���ق���)
        Nail_t.position = new Vector3(5, c_nail.transform.position.y);

        if (time >= bfTime)
        {
            P_posYbf = P_posY;
            bfTime += 0.5f;
        }

    }

    //---------------------------�C���X�^���X-------------------------------//

    //�B�̃C���X�^���X
    void NailGenerate()
    {
        //�B�̃C���X�^���X
        if (Nail_LR)
        {
            GameObject nailL = Instantiate(Nail, new Vector3(Random.Range(left, senter), P_posY - distance), Nailrot) as GameObject;
            //�N���[���̖��O��ύX
            nailL.name = "NailLeft";

            Nail_LR = false;
        }
        else
        {
            GameObject nailR = Instantiate(Nail, new Vector3(Random.Range(senter, right), P_posY - distance), Nailrot) as GameObject;
            //�N���[���̖��O��ύX
            nailR.name = "NailRight";
            Nail_LR = true;

        }
    }
    
    //�G�̃C���X�^���X
    void EnemyGenerate()
    {
        int side;
        side = Random.Range(0, 2);
        if (side==0)
        {
           �@GameObject EnemyBox = Instantiate(Enemy, new Vector3(left, P_posY - distance, 0), Nailrot);
        }
        if(side==1)
        {
            GameObject EnemyBox =Instantiate(Enemy, new Vector3(right, P_posY - distance, 0), Nailrot);
        }
    }

    //NG�G���A�̃C���X�^���X
    void NGAreaGenerate()
    {
        Instantiate(NG, new Vector3(Random.Range(senter, right), P_posY-distance, 0), Nailrot);
    }

    //GOAL�G���A�̃C���X�^���X
    void GoalAreaGenerate()
    {
        Goal_posX = (left + right) / 2;
        Instantiate(Goal, new Vector3(Goal_posX, -StageLength+2, 0), Nailrot);
    }


    //�ǂ̃C���X�^���X
    void WallGenerate()
    {
        //�ǂ̃C���X�^���X
        Instantiate(Wall_LRDS, new Vector3(left, -StageLength / 2, 0), Nrot);
        Instantiate(Wall_LRDS, new Vector3(right, -StageLength / 2, 0), Nrot);
        
        //��
        GameObject WallDown = Instantiate(Wall_LRDS, new Vector3((left + right) / 2, -StageLength, 0), Nrot);
        WallDown.transform.localScale = new Vector3(Mathf.Abs(left) + Mathf.Abs(right), 1, depth);

        //�΂�
        GameObject WallSlice = Instantiate(Wall_LRDS, new Vector3((left + right) / 2, P_posY, 10), Nrot);
        WallSlice.transform.localScale=new Vector3((left + right) / 2, 10, 1);
        WallSlice.transform.rotation= new Quaternion(60, 60, 0, 0);///////////////////////////////

        //�O��
        Instantiate(Wall_BA, new Vector3((left + right) / 2, -StageLength / 2, -1.5f), Nrot);
        Instantiate(Wall_BA, new Vector3((left + right) / 2, -StageLength / 2, 1.5f), Nrot);
    }

    void ItemGenerate()
    {
       GameObject BigSmall = Instantiate(bigSmall, new Vector3(Random.Range(senter, right), P_posY - distance, 0), Nrot);
    }

}
