// Uses JetBrains.Annotations namespace for project
using JetBrains.Annotations;
// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEngine namespace for project
using UnityEngine;
// Uses UnityEngine.SceneManagement namespace for project
using UnityEngine.SceneManagement;
// Uses UnityEngine.UI namespace for project
using UnityEngine.UI;

// Creates a public class called StartGame that inherits from MonoBehaviour
public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Creates a public method called OnStartButtonClick
    public void OnStartButtonClick()
    {
        // Loads the scene My Game
        SceneManager.LoadScene("My Game");
    }
}
