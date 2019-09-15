using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestrucPoint;

    void Start()
    {
        platformDestrucPoint = GameObject.Find("PlatformDestroyPoint");
    }

    void Update()
    {
        if (transform.position.x < platformDestrucPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
