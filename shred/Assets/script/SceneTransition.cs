using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider oth)
    {
        if (oth.tag != "Player") { return ; }
        if (gameObject.tag == "Goal")
        {
            Invoke("ChangeScene", 1.5f);
        }
        if (gameObject.tag == "NG")
        {
            Invoke("ChangeScene", 1.5f);
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
