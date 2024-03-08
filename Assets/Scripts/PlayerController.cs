using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 5;
    public float rotationSpeed = 25;
    private Rigidbody playerRb;
    private float verticalInput;
    private float horizontalInput;
    private float jumpForce = 8;
    private bool isJumping = false;

    public bool hasSpeedPowerup;
    private float powerupSpeed = 10;
    public int powerupDuration = 30;

    public bool hasSlowness;
    private float slownessSpeed = 1;
    public int slownessDuration = 30;

    public bool hasJumpPowerup;
    private float powerupJump = 11;
    public int jumpDuration = 30;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && (isJumping == false))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

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

        if (hasJumpPowerup)
        {
            jumpForce = powerupJump;
        }
        else
        {
            jumpForce = 8;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("speedPowerup"))
        {
            Destroy(other.gameObject);
            hasSpeedPowerup = true;
            hasSlowness = false;
            hasJumpPowerup = false;
            StartCoroutine(PowerupCooldown());
        }

        if (other.gameObject.CompareTag("slowness"))
        {
            Destroy(other.gameObject);
            hasSlowness = true;
            hasSpeedPowerup = false;
            hasJumpPowerup = false;
            StartCoroutine(slownessCooldown());
        }

        if (other.gameObject.CompareTag("jumpPowerup"))
        {
            Destroy(other.gameObject);
            hasJumpPowerup = true;
            hasSlowness = false;
            hasSpeedPowerup= false;
            StartCoroutine(jumpCooldown());
        }
    }

    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerupDuration);
        hasSpeedPowerup = false;
    }

    IEnumerator slownessCooldown()
    {
        yield return new WaitForSeconds(slownessDuration);
        hasSlowness = false;
    }

    IEnumerator jumpCooldown()
    {
        yield return new WaitForSeconds(jumpDuration);
        hasJumpPowerup = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "isJumpable" && isJumping == true)
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "isJumpable")
        {
            isJumping = true;
        }
    }
}
