using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform generator;
    public Player player;

    private Vector2 platformStartPoint;
    private Vector2 playerStartPoint;
    private PlatformDestroyer[] platformList;
    private ScoreManager scoreManager;

    public DeathMenu deathMenu;

    void Start()
    {
        platformStartPoint = generator.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        scoreManager.scoreActive = false;
        player.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(true);
        int itemNumber = PlayerPrefs.GetInt("CharacterSelected");
        if (PlayerPrefs.GetFloat("Item" + itemNumber) != 0)
        {
            PlayerPrefs.SetFloat("Item" + itemNumber, PlayerPrefs.GetFloat("Item" + itemNumber) + scoreManager.itemCount);
        }
        else
        {
            PlayerPrefs.SetFloat("Item" + itemNumber, scoreManager.itemCount);
        }
        scoreManager.itemCount = 0;
        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        deathMenu.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            Destroy(platformList[i].gameObject);
        }
        player.transform.position = playerStartPoint;
        generator.transform.position = platformStartPoint;
        player.gameObject.SetActive(true);
        scoreManager.scoreActive = true;
        scoreManager.scoreCount = 0;
    }

   /* public IEnumerator RestartGameCo()
    {
        scoreManager.scoreActive = false;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            Destroy(platformList[i].gameObject);
        }
        player.transform.position = playerStartPoint;
        generator.transform.position = platformStartPoint;
        player.gameObject.SetActive(true);
        scoreManager.scoreActive = true;
        scoreManager.scoreCount = 0;
    }*/
}
