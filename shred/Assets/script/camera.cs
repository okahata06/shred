using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField,Header("�ʏ�z���W")]
    float C_posZ = 20;
    [SerializeField,Header("���Zy���W")]
    float C_posY = 5;
    [SerializeField,Header("�ǐՑΏ�")]
    public GameObject target;

    [SerializeField, Header("�g�k��")]
    float MaxMove = 10;

    float move = 0.05f;

    float Count=0;//���ʎ��ԃJ�E���g�p

    bigSmall BigSmall;

    Transform c_transform;

    Quaternion Camera_rot=Quaternion.Euler(25,180,0);

    // Start is called before the first frame update
    void Start()
    {
        BigSmall=new bigSmall();
        MaxMove += C_posZ;
        c_transform= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        

        Debug.Log("C_posZ"+C_posZ+"MaxMove"+MaxMove);
        if(BigSmall.HitGetSet&&C_posZ<=MaxMove)
        {
            C_posZ += move;
        }
        if(BigSmall.HitGetSet && C_posY <= MaxMove/2.7)
        {
            C_posY += move;

        }
        if(BigSmall.HitGetSet) { Count }
        c_transform.position = new Vector3(target.transform.position.x, target.transform.position.y+C_posY, C_posZ);

        c_transform.rotation = Camera_rot;

    }
}
