// Uses System.Collections namespace for project
using System.Collections;
// Uses System.Collections.Generic namespace for project
using System.Collections.Generic;
// Uses System.Runtime.CompilerServices namespace for project
using System.Runtime.CompilerServices;
// Uses UnityEngine namespace for project
using UnityEngine;
// Uses UnityEngine.InputSystem namespace for project
using UnityEngine.InputSystem;

// Creates a public class called PlayerController that inherits from MonoBehaviour
public class PlayerController : MonoBehaviour
{
    // Declares a private float called speed and sets it to 5
    private float speed = 5;
    // Declares a public float called rotationSpeed and sets it to 25
    public float rotationSpeed = 25;
    // Declares a private Rigidbody called playerRb
    private Rigidbody playerRb;
    // Declares a private float called verticalInput
    private float verticalInput;
    // Declares a private float called horizontalInput
    private float horizontalInput;
    // Declares a private float called jumpForce and sets it to 8
    private float jumpForce = 8;

    // Declares a private bool called isJumping and sets it to false
    private bool isJumping = false;
    // Declares a private float called jumpTime and sets it to 1
    private float jumpTime = 1;
    // Declares a private float called jumpTimer
    private float jumpTimer;
    // Declares a private bool called hasJumped and sets it to false
    private bool hasJumped = false;
    // Declares a private bool called canJump and sets it to true
    private bool canJump = true;

    // Declares a public vool called hasSpeedPowerup
    public bool hasSpeedPowerup;
    // Declares a private float called powerupSpeed and sets it to 10
    private float powerupSpeed = 10;
    // Declares a public int called powerupDuration and sets it to 30
    public int powerupDuration = 30;

    // Declares a public bool called hasSlowness
    public bool hasSlowness;
    // Declares a private float called slownessSpeed and sets it to 1
    private float slownessSpeed = 1;
    // Declares a public int called slownessDuration and sets it to 30
    public int slownessDuration = 30;

    // Declares a public bool called hasJumpPowerup
    public bool hasJumpPowerup;
    // Declares a private float called powerupJump and sets it to 11
    private float powerupJump = 11;
    // Declares a public int called jumpDuration and sets it to 30
    public int jumpDuration = 30;

    // Declares a public bool called gameOver
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        // Sets playerRb to get the component of Rigidbody
        playerRb = GetComponent<Rigidbody>();
        jumpTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Sets horizontalInput to the GetAxis method from Input that passes through the string variable Horizontal
        //horizontalInput = Input.GetAxis("Horizontal");
        // Sets verticalInput to the GetAxis method from Input that passes through the string variable Vertical
        //verticalInput = Input.GetAxis("Vertical");

        // Calls the Translate method to be used to move the player
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        // Calls the Rotate method to be used to rotate where the player looks
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizontalInput);

        // Creates an if statement where if the space key is held down and isJumping is false, the player will jump
        if (hasJumped && (isJumping == false))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Creates an if statement where if the player has the speed powerup, speed is set to powerupSpeed
        // If the player has slowness, speed is set to slownessSpeed
        // Else, speed is set to 5
        if (hasSpeedPowerup)
        {
            speed = powerupSpeed;
        }
        else if (hasSlowness)
        {
            speed = slownessSpeed;
        }
        else
        {
            speed = 5;
        }

        // Creates an if statement where if the player has the jump powerup, jumpForce is set to powerupJump
        // Else, jumpForce is set to 8
        if (hasJumpPowerup)
        {
            jumpForce = powerupJump;
        }
        else
        {
            jumpForce = 8;
        }
    }

    // Creates a private method called OnTriggerEnter that passes through a Collider called other
    private void OnTriggerEnter(Collider other)
    {
        // Creates an if statement where if the player interacts with the speedPowerup, the speedPowerup will be destroyed, hasSpeedPowerup is set to true, hasSlowness is set to false, hasJumpPowerup is set to false, and the coroutine PowerupCooldown is started
        if (other.gameObject.CompareTag("speedPowerup"))
        {
            Destroy(other.gameObject);
            hasSpeedPowerup = true;
            hasSlowness = false;
            hasJumpPowerup = false;
            StartCoroutine(PowerupCooldown());
        }

        // Creates an if statement where if the player interacts with slowness, the slowness powerdown will be destroyed, hasSpeedPowerup is set to false, hasSlowness is set to true, hasJumpPowerup is set to false, and the coroutine slownessCooldown is started
        if (other.gameObject.CompareTag("slowness"))
        {
            Destroy(other.gameObject);
            hasSlowness = true;
            hasSpeedPowerup = false;
            hasJumpPowerup = false;
            StartCoroutine(slownessCooldown());
        }

        // Creates an if statement where if the player interacts with the jumpPowerup, the jumpPowerup will be destroyed, hasSpeedPowerup is set to false, hasSlowness is set to false, hasJumpPowerup is set to true, and the coroutine jumpCooldown is started
        if (other.gameObject.CompareTag("jumpPowerup"))
        {
            Destroy(other.gameObject);
            hasJumpPowerup = true;
            hasSlowness = false;
            hasSpeedPowerup= false;
            StartCoroutine(jumpCooldown());
        }
    }

    // Creates an IEnumerator method called PowerupCooldown that waits for the amount of time set to powerupDuration and sets hasSpeedPowerup to false
    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerupDuration);
        hasSpeedPowerup = false;
    }

    // Creates an IEnumerator method called slownessCooldown that waits for the amount of time set to slownessDuration and sets hasSlowness to false
    IEnumerator slownessCooldown()
    {
        yield return new WaitForSeconds(slownessDuration);
        hasSlowness = false;
    }

    // Creates an IEnumerator method called jumpCooldown that waits for the amount of time set to jumpDuration and sets hasJumpPowerup to false
    IEnumerator jumpCooldown()
    {
        yield return new WaitForSeconds(jumpDuration);
        hasJumpPowerup = false;
    }

    // Creates a private method called OnCollisionStay that passes through a Collision called collision
    private void OnCollisionStay(Collision collision)
    {
        // Creates an if statement where if the player collides with the ground or the player collides with an object tagged isJumpable and isJumping is set to true, then isJumping is set to false
        if (collision.collider.tag == "Ground" || collision.collider.tag == "isJumpable" && isJumping == true)
        {
            isJumping = false;
        }
    }

    // Creates a private method called OnCollisionExit that passes through a Collision called collision
    private void OnCollisionExit(Collision collision)
    {
        // Creates an if statement where if the player collides with the ground or the player collides with an object tagged isJumpable, then isJumping is set to true
        if (collision.collider.tag == "Ground" || collision.collider.tag == "isJumpable")
        {
            isJumping = true;
        }
    }

    // Creates a private method called OnDrawGizmosSelected
    private void OnDrawGizmosSelected()
    {
        // Sets the gizmo's color to red
        Gizmos.color = Color.red;
        // Draws a line from the player's position to a place in front of the player at a distance of 500
        Gizmos.DrawLine(transform.position, transform.forward * 500f);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
        verticalInput = context.ReadValue<Vector2>().y;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        hasJumped = context.ReadValueAsButton();
    }
}
