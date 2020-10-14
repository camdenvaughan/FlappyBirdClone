using UnityEngine;

public class PipeHandler : MonoBehaviour
{
    // Variables for speed, randomness, and refrence to BirdController
    readonly float moveSpeed = 2.5f;
    Vector2 randRange;
    float randY;
    BirdController bird;

    private void Awake()
    {
        // Gets current bird in the scene
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
    }

    // Gives random heights to the pipes
    private void Start()
    {
        randRange = new Vector2(3f, -1f);
        randY = Random.Range(randRange.x, randRange.y);
        transform.position = new Vector3(transform.position.x, randY, transform.position.z);
    }

    // Checks if bird is dead and moves if it is alive
    void Update()
    {
        if (!bird.dead && !bird.waitingForInput) transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }


}