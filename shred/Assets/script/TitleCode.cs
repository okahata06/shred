using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCode : MonoBehaviour
{
    [SerializeField, Header("ÉJÉÅÉâ")]
    GameObject Camera;

    camera CMR;
    Generate Gen;

    int StageNumber=0;
    // Start is called before the first frame update
    void Start()
    {
        Gen=GameObject.Find("Generater").GetComponent<Generate>();
        CMR=Camera.GetComponent<camera>();
    }



    public void OnPressed()
    {
        
        CMR.GetSetTitleEnd = true;
        if(gameObject.name==("ButtonStage1"))
        {
            StageNumber = 1;
            Gen.GetSetStageNumber = StageNumber;
        }
        if(gameObject.name==("ButtonStage2"))
        {
            StageNumber = 2;
            Gen.GetSetStageNumber = StageNumber;
        }
        if (gameObject.name==("ButtonStage3"))
        {
            StageNumber = 3;
            Gen.GetSetStageNumber = StageNumber;
        }
        Destroy(transform.parent.gameObject);
    }

}

