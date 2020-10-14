using UnityEngine;

public class GroundHandler : MonoBehaviour
{
    // Variables for speed and timer, and refrence to BirdController
    readonly float moveSpeed = 2.5f;
    BirdController bird;
    float timeTillSpawn;
    [SerializeField] float targetTime = 2f;
    

    private void Awake()
    {
        // Gets current bird in the scene
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
    }

    private void Start()
    {
        // Resets timer
        timeTillSpawn = 0f;
    }

    void Update()
    {
        // Moves the ground if the bird is alive and gameplay has started
        if (!bird.dead && !bird.waitingForInput) transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        // Updates timer
        timeTillSpawn += Time.deltaTime;

        // If the timer is finished and the bird is alive the ground is moved
        if (timeTillSpawn >= targetTime && !bird.dead)
        {
            transform.position = new Vector3(3f, -4.5f, 0f);
            timeTillSpawn = 0f;
        }
    }

}
