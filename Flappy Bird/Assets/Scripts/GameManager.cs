using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    BirdController bird;

    public GameObject endPopUp;
    public GameObject canvas;

    bool gameEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
        canvas = GameObject.FindGameObjectWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    void EndGame()
    {
        if (bird.dead && !gameEnded)
        {
            //show ui
            gameEnded = true;
        }
    }
}
