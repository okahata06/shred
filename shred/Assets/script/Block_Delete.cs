using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Delete : MonoBehaviour
{
    int deleteTime = 15;
    float time;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > deleteTime)
            Destroy(gameObject);
    }
}
