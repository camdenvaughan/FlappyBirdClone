using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundMovement : MonoBehaviour
{
    // Summary: Moves all of the background assets on the menu
    readonly float skyMoveSpeed = .3f;
    readonly float groundSpeed = 2.5f;
    float timeTillSpawn;
    readonly float targetTime = 2f;

    private void Start()
    {
        timeTillSpawn = 0f;
    }

    void Update()
    {
        // Moves anything with the "Sky" tag
        if (this.CompareTag("Sky")) transform.position = new Vector3(transform.position.x - skyMoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        // Moves anything with the "Ground" tag
        else if (this.CompareTag("Ground"))
        {
            transform.position = new Vector3(transform.position.x - groundSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            timeTillSpawn += Time.deltaTime;
            if (timeTillSpawn >= targetTime)
            {
                transform.position = new Vector3(3f, -4.5f, 0f);
                timeTillSpawn = 0f;
            }
        }
    }

}
