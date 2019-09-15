using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string SelectionMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene(SelectionMenu);
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
