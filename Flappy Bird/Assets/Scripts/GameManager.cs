using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Holds the data and variables from the BirdController class
    BirdController bird;

    // Initilization of ui and score details
    public GameObject endPopUp;
    Text scoreDisplay;
    Text highScoreDisplay;
    bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        // Attaches bird to the current instantiation of the bird in the scene.
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    // Sets endpopup to active and saves and adjusts the highscore if necessary
    void EndGame()
    {
        if (bird.dead && !gameEnded)
        {
            endPopUp.SetActive(true);
            scoreDisplay = GameObject.FindGameObjectWithTag("Score_Display").GetComponent<Text>();
            highScoreDisplay = GameObject.FindGameObjectWithTag("High_Score_Text").GetComponent<Text>();
            scoreDisplay.text = bird.score.ToString();
            highScoreDisplay.text = ("highscore: " + bird.highScore.ToString());
            gameEnded = true;
            
        }
    }

}
