using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    Vector2 spawnPosition;

    private void Start()
    {
        spawnPosition = new Vector2(15.25f, -4.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            collision.transform.position = spawnPosition;
        }
    }
}
