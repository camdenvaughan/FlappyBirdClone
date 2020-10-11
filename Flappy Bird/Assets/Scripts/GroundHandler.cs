using UnityEngine;

public class GroundHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed;
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
