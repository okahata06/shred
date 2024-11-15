using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigSmall : MonoBehaviour
{

 static bool hit=false;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Destroy(this.gameObject);
            hit= true;
        }
    }

    public bool HitGetSet
    {
        get { return hit; }
        set {  hit = value; }
    }

}
