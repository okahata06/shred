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

    }

    void ChangeScene()
    {
        SceneManager.LoadScene("GoalScene");

    }


}
