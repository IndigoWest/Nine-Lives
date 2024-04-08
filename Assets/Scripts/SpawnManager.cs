// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEngine namespace for project
using UnityEngine;

// Creates a public class called SpawnManager that inherits from MonoBehaviour
public class SpawnManager : MonoBehaviour
{
    // Declares a public GameObject called powerupPrefabs
    public GameObject[] powerupPrefabs;
    // Declares a private float called spawnDelay and sets it to 5
    private float spawnDelay = 5;
    // Declares a private float called spawnInterval and sets it to 2.5
    private float spawnInterval = 2.5f;

    // Declares a private PlayerController called playerController
    private PlayerController playerController;

    // Declares a public GameObject called enemyPrefab
    public GameObject[] enemyPrefab;
    // Declares a private float called enemySpawnDelay and sets it to 30
    private float enemySpawnDelay = 30;

    // Start is called before the first frame update
    void Start()
    {
        // Creates an InvokeRepating method that passes through arguments SpawnObjects, spawnDelay, and spawnInterval
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        // Creates an Invoke method that passes through arguments SpawnEnemyObject and enemySpawnDelay
        Invoke("SpawnEnemyObject", enemySpawnDelay);
        // Sets playerController to find the GameObject Player and get the component of PlayerController
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Creates a method called SpawnObjects
    void SpawnObjects()
    {
        // Sets spawnLocation to a random range between -11.66 and 17.88 for x, 3.5 for y, and a range range between -17.25 and 12.9 for z
        Vector3 spawnLocation = new Vector3(Random.Range(-11.66f, 17.88f), 3.5f, Random.Range(-17.25f, 12.9f));
        // Sets index to a random range between 0 and the amount of powerupPrefabs in the index list
        int index = Random.Range(0, powerupPrefabs.Length);

        // Creates an if statement where if it's not gameOver, then it will create an Instantiate method that passes through the arguments powerupPrefabs[index], spawnLocation, and powerupPrefabs[index].transform.rotation
        if(!playerController.gameOver)
        {
            Instantiate(powerupPrefabs[index], spawnLocation, powerupPrefabs[index].transform.rotation);
        }
    }
    
    // Creates a SpawnEnemyObject method
    void SpawnEnemyObject()
    {
        // Sets spawnLocation to -15.22 for x, 4.093 for y, and -11.8 for z
        Vector3 spawnLocation = new Vector3(-15.22f, 4.093f, -11.8f);
        // Creates an Instantiate method that passes through the arguments enemyPrefabs[0], spawnLocation, and Quaternion.identity
        Instantiate(enemyPrefab[0], spawnLocation, Quaternion.identity);
    }
}
