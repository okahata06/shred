using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    float NG_EntryCount=0;
    float Goal_EntryCount=0;
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
            Goal_EntryCount += Time.deltaTime;
            if(Goal_EntryCount>=120)
            {
                Invoke("ChangeScene", 0.5f);

            }

        }
        else
        {
            Goal_EntryCount = 0;
        }

        if (gameObject.tag == "NG")
        {
            NG_EntryCount += Time.deltaTime;
            if (NG_EntryCount >= 120)
            {
                Invoke("ChangeScene", 0.5f);

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
