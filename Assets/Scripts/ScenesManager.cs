// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses JetBrins.Annotations namespace for project
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

// Creates a public class called ScenesManager that inherits from MonoBehaviour
public class ScenesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Creates a public method called OnStartButtonClick that loads the scene My Game
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("My Game");
    }

    // Creates a public method called OnMainButtonClick that loads the scene Main Menu
    public void OnMainButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Creates a public method called OnMenuButtonClick that loads the scene Menu
    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
