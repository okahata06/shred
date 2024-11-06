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
        _target = GameObject.Find("Hips");
        float angle = GetAngle(sentral.transform.position, _target.transform.position);
    }


    private void Update()
    {
        //Šp“xŽæ“¾
        float angle = GetAngle(sentral.transform.position, _target.transform.position);

        //”½‰f
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }


}