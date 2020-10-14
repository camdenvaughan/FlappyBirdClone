using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBird : MonoBehaviour
{
    // Rigidbody component
    Rigidbody2D rb;

    // Bird physics variables
    readonly float jumpForce = 5f;
    readonly float tiltSmooth = 1f;
    bool jump;
    float timeTillJump;

    // Variables for handling rotation
    Quaternion downRotation;
    Quaternion forwardRotation;


    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();

        // Initilizes Rigidbody
        rb = GetComponent<Rigidbody2D>();

        // Sets the rotation Variables
        downRotation = Quaternion.Euler(0f, 0f, -90f);
        forwardRotation = Quaternion.Euler(0f, 0f, 35f);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        Rotate();
        HeightLimiter();

    }

    // Called at a fixed interval, where physics calculations are held
    private void FixedUpdate()
    {
        Jump();
    }

    // Adds velocity to the bird's rigidbody and relsets rotation when jump = true
    void Jump()
    {
        if (jump)
        {
            rb.velocity = new Vector2(0f, jumpForce);
            transform.rotation = forwardRotation;
            FindObjectOfType<AudioManager>().Play("Flap");
            jump = false;
        }
    }


    // Constantly rotates the bird down
    void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    // Timer to randomize the jumps of the bird in the menu
    void Timer()
    {
        timeTillJump -= Time.deltaTime;
        if (timeTillJump <= 0f)
        {
            jump = true;
            ResetTimer();
        }
    }

    // Resets the timer back to zero
    void ResetTimer()
    {
        timeTillJump = Random.Range(.2f, .8f);
    }

    // Restricts the height of the bird in the menu to keep it visible
    void HeightLimiter()
    {
        if (transform.position.y >= 4.15f) ResetTimer();
        if (transform.position.y <= 1.85f) jump = true;
    }

}
