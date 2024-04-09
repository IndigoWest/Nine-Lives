// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEditor namespace for project
using UnityEditor;
// Uses UnityEngine namespace for project
using UnityEngine;
using UnityEngine.SceneManagement;

// Creates a public class called LivesManagement that inherits from MonoBehaviour
public class LivesManagement : MonoBehaviour
{
    // Declares a public integer called health and sets it to 9
    public int health = 9;
    // Declares a public GameObject[] called sprites
    public GameObject[] sprites;

    // Creates a private method called Start that is called before the first frame update
    private void Start()
    {
        // Sets health to the length of sprites
        health = sprites.Length;
    }

    // Creates a private method called Update that is called every frame update
    private void Update()
    {
        // Calls the EndGame method
        LoseGame();
    }

    // Create a private method called OnCollisionEnter that passes through a Collision called collision
    private void OnCollisionEnter(Collision collision)
    {
        // Creates an if statement that detects whether or not the player collides with the Enemy
       if (collision.gameObject.CompareTag("Enemy"))
        {
            // Subtracts health each time the player collides with the Enemy
            health--;
            // Calls the UpdateLives method
            UpdateLives();
        }
    }

    // Creates a private method called UpdateLives
    private void UpdateLives()
    {
        // Creates a for loop that declares the integer i and sets it to 0, the loops condition of whether or not i is greater than the lengths of sprites, and declares the increment statement
        for (int i = 0; i < sprites.Length; i++) 
        {
            // Creates an if statement where if i is less than health, sprites[i].SetActive becomes true
            if(i < health)
            {
                sprites[i].SetActive(true);
            }
            // Creates an else statement where sprites[i].SetActive becomes false
            else
            {
                sprites[i].SetActive(false);
            }
        }
        
    }

    // Creates a private method called OnTriggerEnter that passes through a Collider called other
    private void OnTriggerEnter(Collider other)
    {
        // Creates an if statement that detects if the player collides with healthPowerup
        if (other.gameObject.CompareTag("healthPowerup"))
        {
            // Destroys the healthPowerup
            Destroy(other.gameObject);
            // Adds health to the player
            health++;
            // Calls the UpdateLives method
            UpdateLives();
        }
    }

    // Creates a private method called EndGame
    //private void EndGame()
   // {
        // Creates an if statement which checks if health is less than 1
       // if (health < 1)
      //  {
            // If health is less than one, it will exit playmode else it will call Application.Quit method
//#if UNITY_EDITOR
  //          EditorApplication.ExitPlaymode();
//#else
  //          Application.Quit();
//#endif
      //  }
  //  }

    private void LoseGame()
    {
        if (health < 1)
        {
            SceneManager.LoadScene("Lose Screen");
        }
    }
}
