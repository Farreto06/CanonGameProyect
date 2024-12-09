using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("DayLevel");
    }

    public void QuitGame()
    {
        // Cierra la aplicación
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
