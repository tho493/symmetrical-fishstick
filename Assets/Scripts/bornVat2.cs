﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bornVat2 : MonoBehaviour
{
    public GameObject fabs;
    public float timeDuration;
    private float count;
    public GameObject player;
    public float x,y,z;
    private Vector3 vector;
    public float x1, y1,x2,y2;
   
    void Start()
    {
    }
    void Awake()
    {
        count = timeDuration;
        vector = new Vector3(x, y, z);

    }
    
    void Update()
    {
        count -= Time.deltaTime;
        if ((player.transform.position.y >= y1 && player.transform.position.y <= y2) && (player.transform.position.x >= x1 && player.transform.position.x <= x2) && (count <= 0))

        {

            Instantiate(fabs, vector, Quaternion.identity);
            

            count = timeDuration;
            

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject,0.3f);
            

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.3f);


        }
    }
}
