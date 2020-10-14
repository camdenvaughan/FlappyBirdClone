using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBird : MonoBehaviour
{
    Rigidbody2D rb;

    readonly float jumpForce = 5f;
    readonly float tiltSmooth = 1f;
    bool jump;
    float timeTillJump;

    Quaternion downRotation;
    Quaternion forwardRotation;


    // Start is called before the first frame update
    void Start()
    {
        ResetTimer();
        rb = GetComponent<Rigidbody2D>();

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

    private void FixedUpdate()
    {
        Jump();
    }


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



    void Rotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    void Timer()
    {
        timeTillJump -= Time.deltaTime;
        if (timeTillJump <= 0f)
        {
            jump = true;
            ResetTimer();
        }
    }
    void ResetTimer()
    {
        timeTillJump = Random.Range(.2f, .8f);
    }

    void HeightLimiter()
    {
        if (transform.position.y >= 4.15f) ResetTimer();
        if (transform.position.y <= 1.85f) jump = true;
    }

}
