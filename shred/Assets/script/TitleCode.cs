using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCode : MonoBehaviour
{
    [SerializeField, Header("�J����")]
    GameObject Camera;

    camera CMR;

    // Start is called before the first frame update
    void Start()
    {
        CMR=Camera.GetComponent<camera>();
    }



    public void OnPressed()
    {
        CMR.GetSetTitleEnd = true;

        Destroy(gameObject);
    }

}
