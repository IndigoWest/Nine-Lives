// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEngine namespace for project
using UnityEngine;

// Creates a public class called SelfDestruct that inherits from MonoBehaviour
public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Starts the Coroutine Destruct
        StartCoroutine(Destruct());
    }

    // Creates an IEnumerator method called Destruct that waits for seven seconds before destroying the gameObject
    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
