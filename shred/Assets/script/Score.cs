using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int Body;
    public static int Body_Break;

    int time;
    bool fast = true;

    [SerializeField] TextMeshProUGUI VarText;

    // Start is called before the first frame update
    void Start()
    {
        time = (int)Time.time;
    }


    void Update()
    {
        if (fast)
        {
            fast = false;

            time = (int)Time.time;
            Body_Break = Body - Body_Break;

            string BodyBreak = Body_Break.ToString();

            VarText.text = "Žc‘¶•”ˆÊ :" + BodyBreak + "/" + Body + "\n"
                            + "Time :" + time + "s\n"
                            + "Score :" + "999";
        }
    }
}

