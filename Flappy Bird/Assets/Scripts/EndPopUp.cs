using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPopUp : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Play("Button");
    }
}
