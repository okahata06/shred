using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    [SerializeField]
    GameObject sentral;

    [SerializeField]
    GameObject _target;

    void Start()
    {
        float angle = GetAngle(sentral.transform.position, _target.transform.position);
        Debug.Log(angle);
    }


    private void Update()
    {
        float angle = GetAngle(sentral.transform.position, _target.transform.position);

        transform.rotation= Quaternion.Euler(0,0, angle);

    }
    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }
}