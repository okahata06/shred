using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    [SerializeField, Header("爆発エフェクト")]
    GameObject[] effect;

    int E_volume=0;
    // Start is called before the first frame update
    void Start()
    {
        E_volume = effect.Length;
    }

    // Update is called once per frame
    public GameObject Get1Effect
    {
        get {  return effect[0]; } 
    }
}
