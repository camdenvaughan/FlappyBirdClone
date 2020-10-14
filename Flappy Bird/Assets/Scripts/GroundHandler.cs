using UnityEngine;

public class GroundHandler : MonoBehaviour
{
    readonly float moveSpeed = 2.5f;
    BirdController bird;
    float timeTillSpawn;
    [SerializeField] float targetTime = 2f;
    

    private void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
    }

    private void Start()
    {
        timeTillSpawn = 0f;
    }

    void Update()
    {
        if (!bird.dead && !bird.waitingForInput) transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        timeTillSpawn += Time.deltaTime;
        if (timeTillSpawn >= targetTime && !bird.dead)
        {
            transform.position = new Vector3(3f, -4.5f, 0f);
            timeTillSpawn = 0f;
        }
    }

}
