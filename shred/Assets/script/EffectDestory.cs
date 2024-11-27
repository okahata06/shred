using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestory : MonoBehaviour
{
    

    int Count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Count++;
        if (Count >= 400 )
        {
            Destroy( gameObject );
        }
        Debug.Log(Count);
    }
}
