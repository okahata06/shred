using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int Body;
    public static int Body_Break;
    public static float time;
    int SafeBody;
    int score=999;
   float badtime=0;
    bool fast = true;

    [SerializeField] TextMeshProUGUI VarText;

    // Start is called before the first frame update
    void Start()
    {
    }


    void Update()
    {
        if (fast)
        {
            fast = false;

            if(time>60)
            { badtime = time-60.0f; }
            SafeBody = Body - Body_Break;
            score = 999 - (Body_Break * 65+(int)badtime);

           // Debug.Log("score" + score + "Body_Break" + Body_Break + "*65=" + Body_Break * 65 + "badtime" + badtime);
            string BodyBreak = Body_Break.ToString();

            VarText.text = "Žc‘¶•”ˆÊ :" + SafeBody + "/" + Body + "\n"
                            + "Time :" + (int)time + "s\n"
                            + "Score :" + score;
        }
    }
}

