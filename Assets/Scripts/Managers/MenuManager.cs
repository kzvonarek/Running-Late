using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    // main menus
    public void playGame()
    {
        SceneManager.LoadScene("House");
    }

    public void controlsButton()
    {
        SceneManager.LoadScene("Controls");
    }

    public void closeGame()
    {
        Application.Quit();
    }

    // during gameplay
    public void menuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
