using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int Body;
    public static int Body_Break;
    int SafeBody;
    int score=999;
    int time;
    int badtime=0;
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
            if(time>60)
            { badtime = time-60; }
            SafeBody = Body - Body_Break;
            score = 999 - (Body_Break * 65+badtime);

           // Debug.Log("score" + score + "Body_Break" + Body_Break + "*65=" + Body_Break * 65 + "badtime" + badtime);
            string BodyBreak = Body_Break.ToString();

            VarText.text = "Žc‘¶•”ˆÊ :" + SafeBody + "/" + Body + "\n"
                            + "Time :" + time + "s\n"
                            + "Score :" + score;
        }
    }
}

