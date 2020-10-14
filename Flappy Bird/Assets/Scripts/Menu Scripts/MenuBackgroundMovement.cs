using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackgroundMovement : MonoBehaviour
{
    readonly float skyMoveSpeed = .3f;
    readonly float pipeGroundSpeed = 2.5f;
    float timeTillSpawn;
    readonly float targetTime = 2f;

    private void Start()
    {
        timeTillSpawn = 0f;
    }

    void Update()
    {
        if (this.CompareTag("Sky")) transform.position = new Vector3(transform.position.x - skyMoveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        else if (this.CompareTag("Ground"))
        {
            transform.position = new Vector3(transform.position.x - pipeGroundSpeed * Time.deltaTime, transform.position.y, transform.position.z);

            timeTillSpawn += Time.deltaTime;
            if (timeTillSpawn >= targetTime)
            {
                transform.position = new Vector3(3f, -4.5f, 0f);
                timeTillSpawn = 0f;
            }
        }
    }

}
