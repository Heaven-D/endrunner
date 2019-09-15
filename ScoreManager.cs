using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    public Text highScore;
    public Text itemScore;

    public float scoreCount;
    public float itemCount;
    public float highScoreCount;

    public bool scoreActive;
    private GameObject player;

    void Start()
    {
        if(PlayerPrefs.GetFloat("HighScore") != 0)
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        player = GameObject.FindGameObjectWithTag("Player");
        scoreCount = player.transform.position.x;
    }

    void Update()
    {
        if (scoreActive)
        {
            if(player.transform.position.x > 0)
            {
                float points = Mathf.Round(player.transform.position.x);
                scoreCount = points;
            }
            else
            {
                scoreCount = 0;
            }
            
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        score.text = "Score: " + Mathf.Round(scoreCount);
        highScore.text = "High Score: " + Mathf.Round(highScoreCount);
        int itemNumber = PlayerPrefs.GetInt("CharacterSelected");
        itemScore.text = "Item" + itemNumber + ": " + Mathf.Round(itemCount);
    }

    public void AddItem(int amount)
    {
        itemCount += amount;
    }
}
