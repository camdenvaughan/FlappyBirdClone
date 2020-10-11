using UnityEngine;

public class GroundHandler : MonoBehaviour
{
    readonly float moveSpeed = 2.5f;
    BirdController bird;

    private void Awake()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
    }

    void Update()
    {
        
        if (!bird.dead) transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }

}
