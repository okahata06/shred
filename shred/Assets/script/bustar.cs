using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class bustar : MonoBehaviour
{
    [SerializeField, Header("�Q�[�W")]
    Slider EnergyGage;

    [SerializeField, Header("�ړ���")]�@//�ړ��ʁ�����G�l���M�[
    float bust_power = 0.2f;
    [SerializeField, Header("MaxEnergy")]
    float Energy_Max = 10;

    Rigidbody rig;
    //GameObject Hip;
    float cooltime = 0;
    float Energy_Remaining;

    Quaternion quaternion;
    Vector3 set;
    Vector3 bust;

    Generate Gen;
    // Start is called before the first frame update
    void Start()
    {
        Gen=GameObject.FindGameObjectWithTag("Generater").GetComponent<Generate>();
        //�����G�l���M�[���ő�l��
        Energy_Remaining = Energy_Max;
        //�Q�[�WUI�̍ő�l
        EnergyGage.maxValue = Energy_Max;

        quaternion.z = gameObject.transform.rotation.z + 90;
        set = new Vector3(0, bust_power, 0);
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //���E�ւ̈ړ��x�N�g���t�^
        if (Input.GetKey(KeyCode.RightArrow))
        { set.x = -5; }
        else if (Input.GetKey(KeyCode.LeftArrow))
        { set.x = 5; }
        else
        {
            if(!Gen.GetStage_In)
            { set.y = 0; }
            else { set.y=bust_power; }
            set.x = 0;
        }
        //�x�N�g���̐��K��
        bust = Vector3.Normalize(quaternion.z * set)*Time.deltaTime;

        //�c�ʂ��聕�X�y�[�X�������ƃu�[�X�g
        if (Input.GetKey(KeyCode.Space) && Energy_Remaining > 0)
        {
            //�x�N�g�����Z
            rig.velocity += bust;
            //�G�l���M�[����
            if (set.y != 0)
            Energy_Remaining -= bust_power;

            //�c�ʂ��}�C�i�X�Ȃ�O�ɂ���
            if (Energy_Remaining < 0) { Energy_Remaining = 0; }
            cooltime = 0;


        }
        //�ő�e�ʖ������g�p����Q�b�o�߂Ȃ�G�l���M�[��
        else if (Energy_Remaining <= Energy_Max && cooltime >= 2)
        {
            Energy_Remaining += bust_power / 3;//�����1/3�̑��x
        }
        else
        {//�g�p���Ă���̎��Ԍo��
            cooltime += Time.deltaTime;
        }
        EnergyGage.value = Energy_Remaining;
    }

}
