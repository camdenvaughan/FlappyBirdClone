using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{

    public void StartClicked()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("Button");
    }

    public void QuitClicked()
    {
        Application.Quit();
        FindObjectOfType<AudioManager>().Play("Button");
    }
}
