using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LivesManagement : MonoBehaviour
{
    public int health = 9;
    public GameObject[] sprites;

    private void Start()
    {
        health = sprites.Length;
    }

    private void Update()
    {
        EndGame();
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            UpdateLives();
        }
    }

    private void UpdateLives()
    {
        for (int i = 0; i < sprites.Length; i++) 
        {
            if(i < health)
            {
                sprites[i].SetActive(true);
            }
            else
            {
                sprites[i].SetActive(false);
            }
        }
        
    }

    private void EndGame()
    {
        if (health < 1)
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}
