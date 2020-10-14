using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    [HideInInspector] public Text scoreText;

    Animator tutorialText;


    readonly float jumpForce = 5f;
    readonly float tiltSmooth = 1f;
    bool jump;


    Quaternion downRotation;
    Quaternion forwardRotation;


    public int score = 0;
    public int highScore;

    [HideInInspector] public bool waitingForInput;
    [HideInInspector] public bool dead;

    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score_Text").GetComponent<Text>();
        tutorialText = GameObject.FindGameObjectWithTag("Tutorial").GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        waitingForInput = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        downRotation = Quaternion.Euler(0f, 0f, -90f);
        forwardRotation = Quaternion.Euler(0f, 0f, 35f);

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

    private void FixedUpdate()
    {
        Jump();
    }

    void HandleInput()
    {
        if (!waitingForInput)
        {
            rb.isKinematic = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && !dead)
        {
            jump = true;
            FindObjectOfType<AudioManager>().Play("Flap");

        }
    }

    void Jump()
    {
        if (jump && !dead)
        {
            if (waitingForInput)
            {
                waitingForInput = false;
                tutorialText.SetBool("isStarting", true);
            }
            rb.velocity = new Vector2(0f, jumpForce);
            transform.rotation = forwardRotation;
            jump = false;
        }
    }



    void Rotate()
    {
        if (!dead && !waitingForInput) transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score_Trigger") && !dead)
        {
            score++;
            FindObjectOfType<AudioManager>().Play("Score");
            scoreText.text = (score.ToString());
        }
        if (collision.CompareTag("Pipe") || collision.CompareTag("Ground"))
        {
            FindObjectOfType<AudioManager>().Play("DeathSound");
            dead = true;
        }
    }

    void OnDeath()
    {
        if (dead)
        {
            
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            anim.enabled = false;
        }
        
    }
    void HighScoreUpdate()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }
    }
}
