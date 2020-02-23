using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMotor : MonoBehaviour
{
    public float speed = 10.0f;
    public float dashSpeed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;
    PlayerStats playerStats;
    public int playerNumber;
    Vector3 targetVelocity;
    Rigidbody playerRB;


    void Awake()
    {

        playerRB = GetComponent<Rigidbody>();
        playerRB.freezeRotation = true;
        playerRB.useGravity = true;
        playerStats = GetComponentInParent<PlayerStats>();
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            // Calculate how fast we should be moving
            if (!playerStats.useController)
            {
                targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }
            else
            {
                targetVelocity = new Vector3(Input.GetAxis("ControllerMotor" + playerNumber + "H"), 0, Input.GetAxis("ControllerMotor" + playerNumber + "V"));
            }
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = playerRB.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            playerRB.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (canJump && Input.GetButton("Jump" + playerNumber) || Input.GetKeyDown(KeyCode.Space))
            {
                playerRB.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }

        // We apply gravity manually for more tuning control
        playerRB.AddForce(new Vector3(0, -gravity * playerRB.mass, 0));

        grounded = false;

        if (/*Input.GetButtonDown("Dash"+playerNumber)||*/Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Dash!");
            Vector3 dashVelocity = Vector3.Scale(transform.forward, dashSpeed * new Vector3((Mathf.Log(1f / (Time.deltaTime * playerRB.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * playerRB.drag + 1)) / -Time.deltaTime)));
            playerRB.AddForce(dashVelocity, ForceMode.VelocityChange);
        }
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}
