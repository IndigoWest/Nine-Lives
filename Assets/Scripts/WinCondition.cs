// Uses the System.Collections namespace for project
using System.Collections;
// Uses the System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses the UnityEngine namespace for project
using UnityEngine;
// Uses the UnityEngine.SceneManagement namespace for project
using UnityEngine.SceneManagement;

// Created a public class called WinCondition that inherited from MonoBehaviour
public class WinCondition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Created a private method called OnTriggerEnter
    private void OnTriggerEnter(Collider other)
    {
        // Created an if statement where if the player collided with the Milk, then the Win Screen will be loaded
        if (other.gameObject.CompareTag("Milk"))
        {
            SceneManager.LoadScene("Win Screen");
        }
    }
}
