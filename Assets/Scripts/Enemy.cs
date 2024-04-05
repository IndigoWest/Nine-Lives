// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEngine namespace for project
using UnityEngine;

// Creates a public class called Enemy that inherits from MonoBehaviour.
public class Enemy : MonoBehaviour
{
    // Declares a public float called speed
    public float speed;
    // Declares a private Rigidbody called enemyRb
    private Rigidbody enemyRb;
    // Declares a private GameObject called player
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Sets enemyRb to get the component of Rigidbody
        enemyRb = GetComponent<Rigidbody>();
        // Sets player to find the GameObject Player
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Sets lookDirection to look at the player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        // Moves the enemy towards the player
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }

   // private void OnCollisionEnter(Collision collision)
   // {
   //   if (collision.gameObject.name == "Player")
   //    {
   //       Destroy(collision.gameObject);
   //    }
   // }
}
