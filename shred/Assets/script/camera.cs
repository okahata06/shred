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
    [SerializeField, Header("通常z座標")]
    float C_posZ = 12;
    float C_posZKP = 12;
    [SerializeField, Header("通常y座標")]
    float C_posY = 5;
    float C_posYKP = 5;
    [SerializeField, Header("追跡対象")]
    public GameObject target;

    [SerializeField, Header("拡縮量")]
    float MaxMoveZ = 10;
    [SerializeField]
    float MaxMoveY = 10;

    float move = 0.03f;

    float Count = 0;//効果時間カウント用
    [SerializeField, Header("効果時間(秒)")]
    int EndTime = 5;


    float vibLevel = 0.7f;//揺れの大きさ
    bool isVib = false;

    float ChangeTime = 0;
    bool isTitle = true;
    bool isChange = false;
    bool isPlay = false;
    bool TitleEnd = false;


    bigSmall BigSmall;

    Transform c_transform;

    //タイトル画面時のカメラ座標
    Vector3 Title_pos;
    Quaternion title_rot = Quaternion.Euler(90, 180, 0);

    //ゲーム中のカメラ座標
    Vector3 PlayMode_pos;
    Quaternion PlayMode_rot = Quaternion.Euler(25, 180, 0);

    // Start is called before the first frame update
    void Start()
    {
        BigSmall = new bigSmall();
        MaxMoveZ += C_posZ;
        MaxMoveY += C_posY;
        c_transform = GetComponent<Transform>();

        Title_pos = new Vector3(target.transform.position.x, target.transform.position.y + C_posY * 1.5f, target.transform.position.z);
        PlayMode_pos = new Vector3(target.transform.position.x, target.transform.position.y + C_posY, C_posZ);
    }
    // Update is called once per frame
    void Update()
    {
        //タイトル用コード
        if (isTitle)
        {
            //タイトル中の座標と方向
            gameObject.transform.position = Title_pos;
            gameObject.transform.rotation = title_rot;
            //キーを押して遷移コードへ移動
            if (TitleEnd)
            {
                PlayMode_pos = new Vector3(target.transform.position.x, target.transform.position.y + C_posY, C_posZ);

                isTitle = false;
                isChange = true;
            }
        }
        //遷移コード
        else if(isChange)
        {
            //座標、方向の移動
            transform.position = Vector3.Lerp(Title_pos, PlayMode_pos, ChangeTime);
            transform.rotation = Quaternion.Lerp(title_rot, PlayMode_rot, ChangeTime);
            //遷移速度
            ChangeTime += 0.6f*Time.deltaTime;
            
            //移動が終わったらプレイ中のコードへ移動
            if(ChangeTime>=1)
            {
                isChange = false;
                isPlay = true;
            }
        }
        //プレイ中コード
        else if (isPlay)
        {
            //ｚ軸縮小
            if (BigSmall.HitGetSet && C_posZ <= MaxMoveZ)
            {
                C_posZ += move;
            }
            //ｙ軸縮小
            if (BigSmall.HitGetSet && C_posY <= MaxMoveY / 2.5)
            {
                C_posY += move / 2;

            }
            //効果時間カウント
            if (BigSmall.HitGetSet)
            {
                Count += Time.deltaTime;
                //時間経過後終了
                if (Count >= EndTime)
                {
                    BigSmall.HitGetSet = false;
                    Count = 0;

                }

            }



            //ｚ軸拡大
            if (C_posZ >= C_posZKP && Count == 0)
            {
                C_posZ -= move;

            }
            //ｙ軸拡大
            if (C_posY >= C_posYKP && Count == 0)
            {
                C_posY -= move / 2;
            }

            //プレイ中の座標
            PlayMode_pos = new Vector3(target.transform.position.x, target.transform.position.y + C_posY, C_posZ);

            //振動
            if (isVib)
            {
                c_transform.position = PlayMode_pos + new Vector3(Randomvibration(vibLevel), Randomvibration(vibLevel), Randomvibration(vibLevel));

            }
            else
            {
                c_transform.position = PlayMode_pos;

            }
            c_transform.rotation = PlayMode_rot;
        }



    }

    float Randomvibration(float strength)
    {
        float vibration = 0;
        vibration = UnityEngine.Random.Range(-strength, strength);

        //元の座標に振動量を返して足す
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
    public bool GetSetTitleEnd
    {
        get { return TitleEnd; }
        set { TitleEnd = value; }
    }
}
