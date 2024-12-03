using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestory : MonoBehaviour
{


    float Count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Count += Time.deltaTime;

        if (CompareTag("BulletEffect") && Count >= 0.3)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }

        if (Count >= 2)
        {
            Destroy(gameObject);
            //gameObject.SetActive(false);
        }
    }
}
