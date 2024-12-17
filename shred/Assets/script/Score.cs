using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int Body;
    public static int Body_Break;

    float time;

    [SerializeField] TextMeshProUGUI VarText;
    int NowTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            NowTimes++;

            string Times = NowTimes.ToString();

            string BodyBreak=Body_Break.ToString();

            VarText.text = "•”ˆÊ”j‘¹ :" + BodyBreak + "‰ñ\n"
                            +"Time :" + Time.time + "‰ñ\n"
                            + "Score :" + "‰ñ";
        }
    }
}

