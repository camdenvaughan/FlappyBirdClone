using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    BirdController bird;

    public GameObject endPopUp;
    Text scoreDisplay;
    Text highScoreDisplay;
    bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Player").GetComponent<BirdController>();
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
            endPopUp.SetActive(true);
            scoreDisplay = GameObject.FindGameObjectWithTag("Score_Display").GetComponent<Text>();
            highScoreDisplay = GameObject.FindGameObjectWithTag("High_Score_Text").GetComponent<Text>();
            scoreDisplay.text = bird.score.ToString();
            highScoreDisplay.text = ("highscore: " + bird.highScore.ToString());
            gameEnded = true;
            
        }
    }

}
