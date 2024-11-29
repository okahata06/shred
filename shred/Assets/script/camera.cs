using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class camera : MonoBehaviour
{
    [SerializeField,Header("通常z座標")]
    float C_posZ = 12;
    float C_posZKP = 12;   
    [SerializeField,Header("通常y座標")]
    float C_posY = 5;
    float C_posYKP = 5;
    [SerializeField,Header("追跡対象")]
    public GameObject target;

    [SerializeField, Header("拡縮量")]
    float MaxMoveZ = 10;
    [SerializeField]
    float MaxMoveY = 10;

    float move = 0.03f;

    float Count=0;//効果時間カウント用
    [SerializeField,Header("効果時間(秒)")]
    int EndTime = 10;

    bigSmall BigSmall;

    Transform c_transform;

    //タイトル画面時のカメラ座標
    Vector3 Title_pos;
    Quaternion title_rot = Quaternion.Euler(25, 180, 0);

    //ゲーム中のカメラ座標
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

        //ｚ軸縮小
        if (BigSmall.HitGetSet&&C_posZ<=MaxMoveZ)
        {
            C_posZ += move;
        }
        //ｙ軸縮小
        if(BigSmall.HitGetSet && C_posY <= MaxMoveY/2.5)
        {
            C_posY += move/2;

        }
        //効果時間カウント
        if(BigSmall.HitGetSet) 
        {
            Count+=Time.deltaTime;
            //時間経過後終了
            if (Count >= EndTime)
            {
                BigSmall.HitGetSet = false;
                Count = 0;

            }

        }



        //ｚ軸拡大
        if (C_posZ>=C_posZKP&&Count==0)
        {
            C_posZ -= move;            

        }
        //ｙ軸拡大
        if (C_posY >= C_posYKP && Count == 0)
        {
            C_posY -= move/2;
        }

        //プレイ中の座標
        PlayMode_pos = new Vector3(target.transform.position.x, target.transform.position.y + C_posY, C_posZ);


        c_transform.position = PlayMode_pos;

        c_transform.rotation = PlayMode_rot;

    }
}
