// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses UnityEngine namespace for project
using UnityEngine;

// Creates a public class called CatLook that inherits from MonoBehaviour
public class CatLook : MonoBehaviour
{
    // Declares a public float called mouseSensitivity and sets it to 100
    public float mouseSensitivity = 100.0f;
    // Declares a public float called clampAngle and sets it to 80
    public float clampAngle = 80.0f;

    // Declares a private float called rotY and sets it to 0
    private float rotY = 0.0f;
    // Declares a private float called rotX and sets it to 0
    private float rotX = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Sets rot to transform.localRotation.eulerAngles
        Vector3 rot = transform.localRotation.eulerAngles;
        // sets rotY to rot.y
        rotY = rot.y;
        // Sets rotX to rot.x
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Sets float variable mouseY to the -Inputer.GetAxis  method that passes through the string variable Mouse Y
        float mouseY = -Input.GetAxis("Mouse Y");

        // Adds and assigns rotX to move when the mouse is moved
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        // Assigns rotX to the Clamp method that is located in Mathf that takes the values rotX, -clampAngle, and clampAngle
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        // Assigns localRotation to the Euler method from Quaternion that takes the values rotX, transform.rotation.y, and transform.rotation.z
        Quaternion localRotation = Quaternion.Euler(rotX, transform.rotation.y, transform.rotation.z);
        // Sets transform.rotation to localRotation
        transform.rotation = localRotation;
    }
}
