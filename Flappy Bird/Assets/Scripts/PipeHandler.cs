using UnityEngine;

public class PipeHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 randRange;
    float randY;
    BirdController bird;

    private void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
    }


    private void Start()
    {
        randY = Random.Range(randRange.x, randRange.y);
        transform.position = new Vector3(transform.position.x, randY, transform.position.z);
    }
    void Update()
    {
        if (!bird.dead) transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }


}