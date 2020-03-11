using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private int NextSceneToLoad;

    public void PlayGame()
    {
        //FindObjectOfType<AudioManager>().Play("Button");
        FindObjectOfType<AudioManager>().Play("Click");
        // Gets The Next Scene for the Play Mode
        SceneManager.LoadScene(1);
    }

    public void ReturnToMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        NextSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(NextSceneToLoad);
    }

    public void EndGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }
}
