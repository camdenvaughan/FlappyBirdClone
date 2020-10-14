using UnityEngine;
using UnityEngine.UIElements;

public class SkySpawner : MonoBehaviour
{
    // Position to spawn the sky at if needed
    Vector2 spawnPosition;

    private void Start()
    {
        spawnPosition = new Vector2(25f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the sky collides with the trigger the position is moved back to its spawnpositon
        if (collision.CompareTag("Sky"))
        {
            collision.transform.position = spawnPosition;
        }
    }
}
