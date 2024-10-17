using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    int P_posY;
    int distance = 10;
    float time;
    float NailTime=0.2f;
    float left = -7.0f;
    float right = 7.0f;

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
    [SerializeField, Header("�X�e�[�W����")]
    int StageLength = 100;

    //�C���X�^���X�̉�]
    Quaternion rot = Quaternion.Euler(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̍��W�擾
        P_t=Player.GetComponent<Transform>();
        P_posY = (int)P_t.position.y;
        //�v���C���[�̂���n�_����X�e�[�W�̏I���n�_�����߂�
        StageLength=P_posY+StageLength;
        //�B�̍��W�擾
        Nail_t=Nail.GetComponent<Transform>(); 
        Nail_t.position=new Vector3(5,Nail_t.position.y,P_t.position.z);
    
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[��y���W�擾
        P_posY = (int)Player.transform.position.y;
        time = time + Time.deltaTime;

        if (Nail_t.position.y - P_t.position.y >= distance &&
                NailTime <= time)
            {
            //�B�̃C���X�^���X
            Debug.Log(NailTime % 2 == 0);


            
            Instantiate(Nail, new Vector3(Random.Range(left + P_t.position.x, right + P_t.position.x), P_posY - distance, P_t.position.z), rot);
            
            Instantiate(Nail, new Vector3(Random.Range(left+P_t.position.x,right + P_t.position.x), P_posY-distance, P_t.position.z),rot);

                 NailTime += 0.5f;
            }
        else if (NailTime <= time)
        {
            NailTime += 0.5f;
        }
    }
}
