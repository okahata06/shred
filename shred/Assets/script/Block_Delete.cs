using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Delete : MonoBehaviour
{
    int deleteTime = 8;
    float time;

    Generate Gen;
    void Update()
    {
        Gen = GameObject.FindGameObjectWithTag("Generater").GetComponent<Generate>();
        time += Time.deltaTime;
        
        //ステージを選択するまでは消さない
        if(Gen.GetStage_In&&time > deleteTime)
        {
            Destroy(gameObject);

        }
    }
}
