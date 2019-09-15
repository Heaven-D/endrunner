using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class ObjectGenerator : MonoBehaviour
{
    public List<GameObject> objectsList;
    public int objectsLength;

    public void genItem(float posX, float posY, Quaternion rotation)
    {
        int itemNumber = PlayerPrefs.GetInt("CharacterSelected");
        transform.position = new Vector2(posX, posY + 1);
        GameObject obj = Instantiate(objectsList[itemNumber - 1], transform.position, rotation);
    }
}

