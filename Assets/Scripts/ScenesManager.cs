using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("My Game");
    }

    public void OnMainButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }
}
