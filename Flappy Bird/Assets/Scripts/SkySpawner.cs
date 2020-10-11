using UnityEngine;

public class SkySpawner : MonoBehaviour
{
    [SerializeField] Vector2 spawnPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sky"))
        {
            collision.transform.position = spawnPosition;
        }
    }
}
