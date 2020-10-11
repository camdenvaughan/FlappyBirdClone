using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    Rigidbody2D rb;
    bool jump;
    [SerializeField] float jumpForce;
    [SerializeField] float tiltSmooth;
    public int score = 0;

    public Text scoreText;

    Quaternion downRotation;
    Quaternion forwardRotation;

    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        rb = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0f, 0f, -90f);
        forwardRotation = Quaternion.Euler(0f, 0f, 35f);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        Rotate();
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

}
