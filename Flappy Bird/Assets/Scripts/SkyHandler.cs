using UnityEngine;

public class SkyHandler : MonoBehaviour
{
    readonly float moveSpeed = 0.3f;
    BirdController bird;

    private void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
    }

    void Update()
    {
        if (!bird.dead && !bird.waitingForInput) transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
