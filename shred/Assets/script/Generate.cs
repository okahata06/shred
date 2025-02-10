using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Switch;

public class Generate : MonoBehaviour
{
    int P_posY;
    int P_posYbf;
    int distance = 25;//Player�ƃC���X�^���X����B�̋���
    int StageNumber;


    float time;//�o�ߎ���
    float bfTime = 0;//player���W�`�F�b�N�p
    float NailTime = 0.5f;//�B�����p
    float Goal_posX = 0;
    float BlockTime = -1;

    bool Nail_LR = false;//�B�̏������΂炯�����邽�߁B�E��false
    bool Goal_Gen = false;


    [SerializeField, Header("�J����")]
    GameObject CAMERA;
    camera CMR;

    [SerializeField, Header("�v���C���[")]
    GameObject Player;
    Transform P_t;
    [SerializeField, Header("�G�l�~�[")]
    GameObject Enemy;
    [SerializeField, Header("�B")]
    GameObject Nail;
    Transform Nail_t;
    [SerializeField, Header("�^�C�g���u���b�N")]
    GameObject Block;
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

    bool stage_in = false;

    GameObject c_nail;



    //�C���X�^���X�p����]
    Quaternion Nrot = Quaternion.identity;

    //�B�C���X�^���X�̉�]
    Quaternion Nailrot = Quaternion.Euler(90, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        
        CMR = CAMERA.GetComponent<camera>();
        //�v���C���[�̍��W�擾
        P_t = Player.GetComponent<Transform>();
        P_posY = (int)P_t.position.y;


        if (P_posYbf >= P_posY || Mathf.Abs(P_posYbf - P_posY) >= 10)
        {
            P_posYbf = P_posY;

        }

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

        Wall_BA_T = Wall_BA.GetComponent<Transform>();
        Wall_BA_T.localScale = new Vector3(Mathf.Abs(left) + Mathf.Abs(right), StageLength, 0.2f);
        WallGenerate();

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[��y���W�擾
        P_posY = (int)Player.transform.position.y;
        time = time + Time.deltaTime;

        if (P_posY <= -StageLength + (StageLength - 3))
        {
            stage_in = true;
        }

        //�C���X�^���X����
        //�^�C�g����
        if (!CMR.GetSetTitleEnd && BlockTime + 2 <= time)
        {
            BlockTime += 2;
            BlockGenerate();
        }
        //�v���C��
        else if (Nail_t.position.y - P_t.position.y <= distance &&//�B�Ƃ̋����Ŕ���
            P_t.position.y >= -(StageLength - distance) &&
                NailTime <= time &&//���Ԋu�̃C���^�[�o��
                P_posYbf > P_posY+0.5f)//�������Ă��Ȃ��Ƃ��͐������Ȃ�
        {

            //�m���ŃC���X�^���X
            switch (Random.Range(0, 100))
            {
                case 0:
                case 1:
                    //NG�G���A�̃C���X�^���X
//                    NGAreaGenerate();
                    break;
                case <14:
                    //�G�̃C���X�^���X
                    EnemyGenerate();
                    break;
                case <39:
                    if (StageNumber == 2)
                        //�G�̃C���X�^���X
                        EnemyGenerate();
                    break;
                case 50:
                case 51:
                    //�A�C�e���n�̃C���X�^���X
                    ItemGenerate();
                    break;
                case <55:
                    BlockGenerate();
                    break;
                default:
                    break;
            }
            
            //�B�̃C���X�^���X
            NailGenerate();
            NailTime += 0.13f;
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
            NailTime += 0.13f;
        }

        //�S�[���̐���
        if (P_t.position.y <= -(StageLength - distance) && !Goal_Gen)
        {
            Debug.Log("aa");
            GoalAreaGenerate();
            Goal_Gen = true;
        }


        //�^�O�œB�������i�����炭�ł��Â����́j
        c_nail = GameObject.FindGameObjectWithTag("Nail");
        //�B�̍��W��ۑ�(Y���ق���)
        Nail_t.position = new Vector3(5, c_nail.transform.position.y);

        if (time >= bfTime)
        {
            if (P_posYbf >= P_posY || Mathf.Abs(P_posYbf - P_posY) >= 10)
            {
                P_posYbf = P_posY;

            }
            bfTime += 0.5f;
        }
    }

    //---------------------------�C���X�^���X-------------------------------//

    //�^�C�g���u���b�N�̃C���X�^���X
    void BlockGenerate()
    {
        GameObject block = Instantiate(Block, new Vector3(Random.Range(-6, 6), Block.transform.position.y, Block.transform.position.z), Nrot);
        switch (Random.Range(0, 4))
        {
            case 0:
                block.transform.localScale /= 4;

                break;
            case 1:
                block.transform.localScale /= 3;

                break;
            case 2:
                block.transform.localScale /= 2;

                break;
            default:
                break;
        }


        if (Random.Range(0, 2) == 1)
        {
        }
    }

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
        if (side == 0)
        {
            GameObject EnemyBox = Instantiate(Enemy, new Vector3(left, P_posY - distance, 0), Nailrot);
        }
        if (side == 1)
        {
            GameObject EnemyBox = Instantiate(Enemy, new Vector3(right, P_posY - distance, 0), Nailrot);
        }
    }

    //NG�G���A�̃C���X�^���X
    void NGAreaGenerate()
    {
        Instantiate(NG, new Vector3(Random.Range(senter, right), P_posY - distance, 0), Nailrot);
    }

    //GOAL�G���A�̃C���X�^���X
    void GoalAreaGenerate()
    {
        Goal_posX = (left + right) / 2;
        Instantiate(Goal, new Vector3(Goal_posX, -StageLength + 2, 0), Nailrot);
    }


    //�ǂ̃C���X�^���X
    void WallGenerate()
    {
        

        Instantiate(Wall_LRDS, new Vector3(left, -StageLength / 2, 0), Nrot);
        Instantiate(Wall_LRDS, new Vector3(right, -StageLength / 2, 0), Nrot);

        //��
        GameObject WallDown = Instantiate(Wall_LRDS, new Vector3((left + right) / 2, -StageLength, 0), Nrot);
        WallDown.transform.localScale = new Vector3(Mathf.Abs(left) + Mathf.Abs(right), 1, depth);

        //�O��
        Instantiate(Wall_BA, new Vector3((left + right) / 2, -StageLength / 2, -1.5f), Nrot);
        GameObject flont = Instantiate(Wall_BA, new Vector3((left + right) / 2, -StageLength / 2, 1.5f), Nrot);
        flont.transform.localScale = new Vector3(flont.transform.localScale.x, flont.transform.localScale.y + 30, flont.transform.localScale.z);
    }

    void ItemGenerate()
    {
        GameObject BigSmall = Instantiate(bigSmall, new Vector3(Random.Range(senter, right), P_posY - distance, 0), Nrot);
    }

    public bool GetStage_In
    {
        get { return stage_in; }
    }

    public int GetSetStageNumber
    {
        get { return StageNumber; }
        set { StageNumber = value; }
    }
}
