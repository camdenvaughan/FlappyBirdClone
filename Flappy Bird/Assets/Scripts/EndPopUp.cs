using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPopUp : MonoBehaviour
{
    // Button function to Re-load the scene
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<AudioManager>().Play("Button");
    }

    // Button function to Return to the Menu
    public void Menu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("Button");
    }
}
