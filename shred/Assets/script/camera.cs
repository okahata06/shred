using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField,Header("í èÌzç¿ïW")]
    float C_posZ = 12;
    float C_posZKP = 12;   
    [SerializeField,Header("í èÌyç¿ïW")]
    float C_posY = 5;
    float C_posYKP = 5;
    [SerializeField,Header("í«ê’ëŒè€")]
    public GameObject target;

    [SerializeField, Header("ägèkó ")]
    float MaxMoveZ = 10;
    [SerializeField]
    float MaxMoveY = 10;

    float move = 0.03f;

    float Count=0;//å¯â éûä‘ÉJÉEÉìÉgóp
    [SerializeField,Header("å¯â éûä‘(ïb)")]
    int EndTime = 10;

    bigSmall BigSmall;

    Transform c_transform;

    Quaternion Camera_rot=Quaternion.Euler(25,180,0);

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

        //Çöé≤èkè¨
        if (BigSmall.HitGetSet&&C_posZ<=MaxMoveZ)
        {
            C_posZ += move;
        }
        //Çôé≤èkè¨
        if(BigSmall.HitGetSet && C_posY <= MaxMoveY/2.5)
        {
            C_posY += move/2;

        }
        //å¯â éûä‘ÉJÉEÉìÉg
        if(BigSmall.HitGetSet) 
        {
            Count+=Time.deltaTime;
        }
        //éûä‘åoâﬂå„èIóπ
        if(Count >= EndTime)
        {
            BigSmall.HitGetSet = false;
            Count = 0;

        }



        //Çöé≤ägëÂ
        if (C_posZ>=C_posZKP&&Count==0)
        {
            C_posZ -= move;            

        }
        //Çôé≤ägëÂ
        if (C_posY >= C_posYKP && Count == 0)
        {
            C_posY -= move/2;
        }


        c_transform.position = new Vector3(target.transform.position.x, target.transform.position.y+C_posY, C_posZ);

        c_transform.rotation = Camera_rot;

    }
}
