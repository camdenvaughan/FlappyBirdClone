using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    // Button function to start game
    public void StartClicked()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("Button");
    }

    // Button function to quit game
    public void QuitClicked()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Button");
    }
}
