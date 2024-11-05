using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    int NG_EntryCount=0;
    int Goal_EntryCount=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay(Collider oth)
    {
        if (oth.tag != "Player") { return ; }
        if (gameObject.tag == "Goal")
        {
            Goal_EntryCount++;
            if(Goal_EntryCount>=60)
            {
                Invoke("ChangeScene", 1.5f);

            }

        }
        else
        {
            Goal_EntryCount = 0;
        }

        if (gameObject.tag == "NG")
        {
            NG_EntryCount++;
            if (NG_EntryCount >= 60)
            {
                Invoke("ChangeScene", 1.5f);

            }
        }
        else
        {
            NG_EntryCount = 0;
        }
    }

    void ChangeScene()
    {
        if (gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("GoalScene");

        }
        if (gameObject.tag == "NG")
        {
            SceneManager.LoadScene("NGScene");

        }

    }


}
