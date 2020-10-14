using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundMovement : MonoBehaviour
{
    // Summary: Moves all of the background assets on the menu
    readonly float skyMoveSpeed = .3f;
    readonly float groundSpeed = 2.5f;
    float timeTillGroundSpawn;
    float timeTillSkySpawn;
    readonly float targetGroundTime = 2f;
    readonly float targetSkyTime = 66.68f;

    private void Start()
    {
        timeTillGroundSpawn = 0f;
    }

    void Update()
    {
        // Moves anything with the "Sky" tag
        if (this.CompareTag("Sky"))
        {
            transform.position = new Vector3(transform.position.x - skyMoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            // Updates timer
            timeTillSkySpawn += Time.deltaTime;

            // If the timer is finished and the bird is alive the ground is moved
            if (timeTillSkySpawn >= targetSkyTime)
            {
                transform.position = new Vector3(17f, 0f, 0f);
                timeTillSkySpawn = 0f;
            }
        }

        // Moves anything with the "Ground" tag
        else if (this.CompareTag("Ground"))
        {
            transform.position = new Vector3(transform.position.x - groundSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            timeTillGroundSpawn += Time.deltaTime;
            if (timeTillGroundSpawn >= targetGroundTime)
            {
                transform.position = new Vector3(3f, -4.5f, 0f);
                timeTillGroundSpawn = 0f;
            }
        }
    }

}
