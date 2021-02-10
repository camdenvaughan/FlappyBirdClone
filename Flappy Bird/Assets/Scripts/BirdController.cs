using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    // Rigidbody and Animator
    Rigidbody2D rb;
    Animator anim;

    // public text feild for score
    [HideInInspector] public Text scoreText;

    // Animator for the tutorial text
    Animator tutorialText;

    // Physics variables
    readonly float jumpForce = 5f;
    readonly float tiltSmooth = 1f;
    bool jump;

    // Rotation Variables
    Quaternion downRotation;
    Quaternion forwardRotation;

    // Score Variables
    public int score = 0;
    public int highScore;

    // bools that determine bird movement
    [HideInInspector] public bool waitingForInput;
    [HideInInspector] public bool dead;

    // called before start
    private void Awake()
    {
        // Initilization of text fields
        scoreText = GameObject.FindGameObjectWithTag("Score_Text").GetComponent<Text>();
        tutorialText = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Setting values for the bools that control bird movement
        dead = false;
        waitingForInput = true;

        // Initilization of rigidbody and animator
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Setting rotation values
        downRotation = Quaternion.Euler(0f, 0f, -90f);
        forwardRotation = Quaternion.Euler(0f, 0f, 35f);

        // Retrieving the high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        Rotate();
        OnDeath();
        HighScoreUpdate();
    }

    // Called at fixed intervals
    private void FixedUpdate()
    {
        Jump();
    }

    // Handles space bar input
    void HandleInput()
    {
        // Turns on the rigidbody once the gameplay has started
        if (!waitingForInput)
        {
            rb.isKinematic = false;
        }

        // Sets jump variable to true if space is pressed and bird is alive
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !dead)
        {
            jump = true;
            FindObjectOfType<AudioManager>().Play("Flap");

        }
    }

    // Makes bird jump
    void Jump()
    {
        // If jump was pressed and bird is alive
        if (jump && !dead)
        {
            // Starts the gameplay if it has not started yet
            if (waitingForInput)
            {
                waitingForInput = false;
                tutorialText.SetBool("isStarting", true);
            }
            // Adds velocity to make the bird jump and turn off the jump bool
            rb.velocity = new Vector2(0f, jumpForce);
            transform.rotation = forwardRotation;
            jump = false;
        }
    }


    // Rotates bird down as it falls
    void Rotate()
    {
        if (!dead && !waitingForInput) transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    // Handles collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Updates score and displays it
        if (collision.CompareTag("Score_Trigger") && !dead)
        {
            score++;
            FindObjectOfType<AudioManager>().Play("Score");
            scoreText.text = (score.ToString());
        }
        // Kills bird and plays sound
        if (collision.CompareTag("Pipe") || collision.CompareTag("Ground"))
        {
            FindObjectOfType<AudioManager>().Play("DeathSound");
            dead = true;
        }
    }

    // Stops bird on death
    void OnDeath()
    {
        if (dead)
        {
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            anim.enabled = false;
        }
        
    }

    // Updates high score
    void HighScoreUpdate()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }
    }
}
