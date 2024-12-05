using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    float time = 0;
    float NG_EntryCount=0;
    float Goal_EntryCount=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("main");

        }
        else if (SceneManager.GetActiveScene().name == "GoalScene")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("main");
            }
        }
        else if (SceneManager.GetActiveScene().name == "NGScene")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("main");

            }
        }


    }


    private void OnTriggerStay(Collider oth)
    {
        Debug.Log(NG_EntryCount);

        if (oth.tag != "Player") { return ; }
        if (gameObject.tag == "Goal")
        {
            Goal_EntryCount += Time.deltaTime;
            if(Goal_EntryCount>=5)
            {
                Invoke("ChangeScene", 0.5f);

            }

        }
        else if (gameObject.tag == "NG")
        {
            NG_EntryCount += Time.deltaTime;
            if (NG_EntryCount >= 5)
            {
                Invoke("ChangeScene", 0.5f);

            }
        }
        else
        {
            NG_EntryCount = 0;
            Goal_EntryCount = 0;

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
