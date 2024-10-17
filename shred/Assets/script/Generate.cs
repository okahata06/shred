using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    int P_posY;
    int distance = 5;
    float NailTime=0.5f;
    int left = -6;
    int right = 6;

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
        Nail_t.position=new Vector3(5,Nail_t.position.y,P_t.position.z-distance);
    
    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���[��y���W�擾
        P_posY = (int)Player.transform.position.y;
        //Debug.Log(Mathf.Abs(P_posY));

        while (Mathf.Abs(P_posY) <= Mathf.Abs(StageLength))
        {
            //Debug.Log(StageLength);
            //if (Nail_t.position.y - P_t.position.y >= distance &&
            //    NailTime <= Time.deltaTime)
            //{

            //    //Instantiate(Nail);

            //    // NailTime += 0.5f;
            //}

            ////�v���C���[��y���W�擾
            //P_posY = (int)Player.transform.position.y;
        }
    }
}
