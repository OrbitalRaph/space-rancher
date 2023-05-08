using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Didacticiel()
    {
        SceneManager.LoadScene("Didacticiel");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Option()
    {
        SceneManager.LoadScene("Option");
    }

    public void QuitGame()
    {
        Application.Quit();
    }   
}
