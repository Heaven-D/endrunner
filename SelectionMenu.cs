using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionMenu : MonoBehaviour
{
    public string MainMenuLevel;
    public string StartLevel;
    private float amountItem;
    public Text itemAmount;

    public void PlayGame()
    {
        SceneManager.LoadScene(StartLevel);
    }

    public void SelectCharacter(int PlayerSelected)
    {
        PlayerPrefs.SetInt("CharacterSelected", PlayerSelected);
    }

    public void ShowItems()
    {
        int itemNumber = PlayerPrefs.GetInt("CharacterSelected");
        amountItem = PlayerPrefs.GetFloat("Item"+ itemNumber);
        itemAmount.text = ""+amountItem;
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(MainMenuLevel);
    }
}
