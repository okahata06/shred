using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField,Header("í èÌzç¿ïW")]
    float C_posZ = 12;
    float C_posZKP = 12;   
    [SerializeField,Header("â¡éZyç¿ïW")]
    float C_posY = 5;
    float C_posYKP = 5;
    [SerializeField,Header("í«ê’ëŒè€")]
    public GameObject target;

    [SerializeField, Header("ägèkó ")]
    float MaxMove = 10;

    float move = 0.05f;

    float Count=0;//å¯â éûä‘ÉJÉEÉìÉgóp
    int EndTime = 5;//å¯â èIóπéûä‘

    bigSmall BigSmall;

    Transform c_transform;

    Quaternion Camera_rot=Quaternion.Euler(25,180,0);

    // Start is called before the first frame update
    void Start()
    {
        BigSmall=new bigSmall();
        MaxMove += C_posZ;
        c_transform= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Debug.Log(Count);
        Debug.Log(BigSmall.HitGetSet);

        //Çöé≤èkè¨
        if (BigSmall.HitGetSet&&C_posZ<=MaxMove)
        {
            C_posZ += move;
        }
        //Çôé≤èkè¨
        if(BigSmall.HitGetSet && C_posY <= MaxMove/2.7)
        {
            C_posY += move;

        }
        //å¯â éûä‘ÉJÉEÉìÉg
        if(BigSmall.HitGetSet) 
        {
            Count+=Time.deltaTime;
        }
        if(Count >= EndTime)
        {
            BigSmall.HitGetSet = false;
            Count = 0;

        }



        //Çöé≤ägëÂ
        if (C_posZ>=C_posZKP)
        {
            C_posZ -= move;

            //Çôé≤ägëÂ
            if (Count >= EndTime && C_posY >= C_posYKP)
            {
                C_posY -= move;
            }
            else
            {
            }

        }

        c_transform.position = new Vector3(target.transform.position.x, target.transform.position.y+C_posY, C_posZ);

        c_transform.rotation = Camera_rot;

    }
}
