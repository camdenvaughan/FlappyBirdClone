using UnityEngine;

public class PipeHandler : MonoBehaviour
{
    readonly float moveSpeed = 2.5f;
    Vector2 randRange;
    float randY;
    BirdController bird;

    private void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
    }


    private void Start()
    {
        randRange = new Vector2(3f, -1f);
        randY = Random.Range(randRange.x, randRange.y);
        transform.position = new Vector3(transform.position.x, randY, transform.position.z);
    }
    void Update()
    {
        if (!bird.dead) transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }


}