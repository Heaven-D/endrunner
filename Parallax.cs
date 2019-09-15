using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, respos;
    public GameObject cam;
    public float parallaxEffect;
    private GameObject backs;

    void Start()
    {
        backs = GameObject.FindGameObjectWithTag("BackGrounds");
        int playerNumber = PlayerPrefs.GetInt("CharacterSelected");
        Transform[] trs = backs.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            GameObject objSel = t.gameObject;
            if (t.name == "BackGround" + playerNumber || t.name == "BackGrounds" || t.name.Contains("player" + playerNumber))
            {
                objSel.SetActive(true);
            }
            else
            {
                objSel.SetActive(false);
            }
        }

        startpos = transform.position.x;
        respos = startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        if(temp > startpos + length)
        {
            startpos += length;
        }else if(temp < startpos - length)
        {
            startpos -= length;
        }
    }

    public void restartGame()
    {
        transform.position = new Vector3(respos, transform.position.y, transform.position.z);
    }
}
