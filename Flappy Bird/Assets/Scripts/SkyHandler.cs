using UnityEngine;

public class SkyHandler : MonoBehaviour
{
    // Speed variable and refrence to BirdController
    readonly float moveSpeed = 0.3f;
    BirdController bird;

    private void Awake()
    {
        // Gets current bird in the scene
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
    }

    // Checks if bird is dead and moves if it is alive
    void Update()
    {
        if (!bird.dead && !bird.waitingForInput) transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
