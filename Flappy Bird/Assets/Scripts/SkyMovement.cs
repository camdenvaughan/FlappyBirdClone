using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyMovement : MonoBehaviour
{
    // Variables for speed and timer, and refrence to BirdController
    readonly float moveSpeed = 0.3f;
    BirdController bird;
    public float timeTillSpawn;
    [SerializeField] float targetTime = 66.68f;


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
        if (bird.waitingForInput && Input.GetKeyDown(KeyCode.Space)) timeTillSpawn = 0f;
        // Moves the ground if the bird is alive and gameplay has started
        if (!bird.dead && !bird.waitingForInput) transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        // Updates timer
        timeTillSpawn += Time.deltaTime;

        // If the timer is finished and the bird is alive the ground is moved
        if (timeTillSpawn >= targetTime && !bird.dead)
        {
            transform.position = new Vector3(17f, 0f, 0f);
            timeTillSpawn = 0f;
        }
    }
}
