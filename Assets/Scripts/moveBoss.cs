﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveBoss : MonoBehaviour
{

   
    public float move = 1f;
   
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(-move * Time.deltaTime, 0.0f,0.0f);
      
    }
    void quay()
    {
        move *=- 1;
        transform.localScale = new Vector3(transform.localScale.x *- 1, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("moc"))
        {
            quay();
        }    
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("moc"))
        {
            quay();
        }    
    }
  
}
