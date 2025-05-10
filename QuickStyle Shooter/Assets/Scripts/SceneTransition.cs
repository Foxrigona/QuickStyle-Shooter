using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
  
    public static void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public static void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
