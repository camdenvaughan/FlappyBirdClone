using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] Vector2 spawnPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            collision.transform.position = spawnPosition;
        }
    }
}
