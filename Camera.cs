using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Player player;
    private Vector3 playerPosition;
    private float distanceToMove;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerPosition = player.transform.position;
    }

    void Update()
    {
        distanceToMove = player.transform.position.x - playerPosition.x;
        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
        playerPosition = player.transform.position;
    }
}
