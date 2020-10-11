using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] float spawnX;
    [SerializeField] Vector2 randRange;
    float randY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score_Trigger"))
        {
            randY = Random.Range(randRange.x, randRange.y);
            collision.transform.position = new Vector2(spawnX, randY);
        }
    }
}
