using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] effect;

    ParticleSystem PS;

    EnemyBullet EB;
    Vector3 Bullet_vec;

    int E_volume=0;
    // Start is called before the first frame update
    void Start()
    {
        E_volume = effect.Length;


    }


    // Update is called once per frame
    public GameObject GetEffect1
    {
        get { return effect[0]; }
    }
    public GameObject GetEffect2
    {
        get { return effect[1]; }
    }
    public GameObject GetEffect3
    {
        get { return effect[2]; }
    }
}
