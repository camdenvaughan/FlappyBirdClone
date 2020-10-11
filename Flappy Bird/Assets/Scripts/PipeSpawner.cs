using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    readonly float spawnX = 7f;
    Vector2 randRange;
    float randY;

    private void Start()
    {
        randRange = new Vector2(3f, -1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score_Trigger"))
        {
            randY = Random.Range(randRange.x, randRange.y);
            collision.transform.position = new Vector2(spawnX, randY);
        }
    }
}
