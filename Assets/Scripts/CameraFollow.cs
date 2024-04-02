using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 temp = transform.position;
           temp.y = player.position.y;
            temp.x = player.position.x;
            transform.position = temp;
        }
    }
}
