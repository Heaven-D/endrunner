using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{

    private ScoreManager scoreManager;
    public string itemName;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            int itemAmount = Random.Range(1, 3);
            scoreManager.AddItem(itemAmount);
            Destroy(gameObject);
        }
    }
}
