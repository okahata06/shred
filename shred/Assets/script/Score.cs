using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int Body;
    public static int Body_Break;

    [SerializeField] TextMeshProUGUI VarText;
    int NowTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            NowTimes++;

            string Times = NowTimes.ToString();

            VarText.text = "Score:" + Times + "‰ñ\n"
                            +"a";
        }
    }
}

