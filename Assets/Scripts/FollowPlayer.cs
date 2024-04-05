// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEngine namespace for project
using UnityEngine;

// Creates a public class called FollowPlayer that inherits from MonoBehaviour
public class FollowPlayer : MonoBehaviour
{
    // Declares a public GameObject called player
    public GameObject player;
    // Declares a private Vector3 called offset
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Sets offset to be away from the player
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Sets the position to be focused on the player but away from it
        transform.position = player.transform.position + offset;
    }
}
