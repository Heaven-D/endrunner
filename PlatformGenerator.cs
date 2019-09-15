using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;
    public float distanceMin;
    public float distanceMax;
    private int platformSelector;
    public GameObject[] platforms;
    private float[] platformWidths;
    private ObjectGenerator objectGenerator;

    private float maxHeight;
    private float minHeight;
    public Transform maxHeightPoint;
    public float maxHeightChange;
    public float heightChange;

    void Start()
    {
        objectGenerator = FindObjectOfType<ObjectGenerator>();
        platformWidths = new float[platforms.Length];
        for(int i = 0; i < platforms.Length; i++)
        {
            platformWidths[i] = platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceMin, distanceMax);

            platformSelector = Random.Range(0, platforms.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }else if(heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector2(transform.position.x + platformWidths[platformSelector] + distanceBetween, heightChange);

            Instantiate(platforms[platformSelector], transform.position, transform.rotation);
            float positionPlatformX = transform.position.x;
            float positionPlatformY = transform.position.y;
            Quaternion rotationPlatform = transform.rotation;
            int itemSpawn = Random.Range(0, 6);
            if(itemSpawn > 3)
            {
                objectGenerator.genItem(positionPlatformX, positionPlatformY, rotationPlatform);
            }
        }
    }
}
