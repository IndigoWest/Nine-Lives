using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] powerupPrefabs;
    private float spawnDelay = 5;
    private float spawnInterval = 2.5f;

    private PlayerController playerController;

    public GameObject[] enemyPrefab;
    private float enemySpawnDelay = 30;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
        Invoke("SpawnEnemyObject", enemySpawnDelay);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects ()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-11.66f, 17.88f), 3.5f, Random.Range(-17.25f, 12.9f));
        int index = Random.Range(0, powerupPrefabs.Length);

        if(!playerController.gameOver)
        {
            Instantiate(powerupPrefabs[index], spawnLocation, powerupPrefabs[index].transform.rotation);
        }
    }
    
    void SpawnEnemyObject()
    {
        Vector3 spawnLocation = new Vector3(-15.22f, 4.093f, -11.8f);
        Instantiate(enemyPrefab[0], spawnLocation, Quaternion.identity);
    }
}
