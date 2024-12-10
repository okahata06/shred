using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class bustar : MonoBehaviour
{
    [SerializeField, Header("ゲージ")]
    Slider EnergyGage;

    [SerializeField, Header("移動力")]　//移動量＝消費エネルギー
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
        //初期エネルギーを最大値に
        Energy_Remaining = Energy_Max;
        //ゲージUIの最大値
        EnergyGage.maxValue = Energy_Max;

        quaternion.z = gameObject.transform.rotation.z + 90;
        set = new Vector3(0, bust_power, 0);
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //左右への移動ベクトル付与
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
        //ベクトルの正規化
        bust = Vector3.Normalize(quaternion.z * set)*Time.deltaTime;

        //残量あり＆スペースを押すとブースト
        if (Input.GetKey(KeyCode.Space) && Energy_Remaining > 0)
        {
            //ベクトル加算
            rig.velocity += bust;
            //エネルギー減少
            if (set.y != 0)
            Energy_Remaining -= bust_power;

            //残量がマイナスなら０にする
            if (Energy_Remaining < 0) { Energy_Remaining = 0; }
            cooltime = 0;


        }
        //最大容量未満＆使用から２秒経過ならエネルギー回復
        else if (Energy_Remaining <= Energy_Max && cooltime >= 2)
        {
            Energy_Remaining += bust_power / 3;//消費の1/3の速度
        }
        else
        {//使用してからの時間経過
            cooltime += Time.deltaTime;
        }
        EnergyGage.value = Energy_Remaining;
    }

}
