using UnityEngine;

public class SkySpawner : MonoBehaviour
{
    Vector2 spawnPosition;

    private void Start()
    {
        spawnPosition = new Vector2(25f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Sky"))
        {
            collision.transform.position = spawnPosition;
        }
    }
}
