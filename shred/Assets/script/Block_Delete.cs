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
        
        //�X�e�[�W��I������܂ł͏����Ȃ�
        if(Gen.GetStage_In&&time > deleteTime)
        {
            Destroy(gameObject);

        }
    }
}
