using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    Text scoreText;


    readonly float jumpForce = 5f;
    readonly float tiltSmooth = 1f;
    bool jump;


    Quaternion downRotation;
    Quaternion forwardRotation;


    [HideInInspector] public int score = 0;


    public bool dead = false;

    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score_Text").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dead = false;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        downRotation = Quaternion.Euler(0f, 0f, -90f);
        forwardRotation = Quaternion.Euler(0f, 0f, 35f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        Rotate();
        OnDeath();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !dead)
        {
            jump = true;
        }
    }

    void Jump()
    {
        if (jump && !dead)
        {
            rb.velocity = new Vector2(0f, jumpForce);
            transform.rotation = forwardRotation;
            jump = false;
        }
    }

    void Rotate()
    {
        if (!dead) transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score_Trigger") && !dead)
        {
            score++;
            scoreText.text = (score.ToString());
        }
        if (collision.CompareTag("Pipe"))
        {
            dead = true;
        }
    }

    void OnDeath()
    {
        if (dead)
        {
            anim.enabled = false;
        }
        
    }
}
