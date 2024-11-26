using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] effect;

    [SerializeField]
    GameObject eeee;
    

    int E_volume=0;
    // Start is called before the first frame update
    void Start()
    {
        E_volume = effect.Length;
    }


    // Update is called once per frame
    public void Effect1()
    {
        Instantiate(effect[0]);
    }
    public void Effect2()
    {
        Instantiate(eeee);
    }
    public void Effect3()
    {
        Instantiate(effect[2]);
    }
}
