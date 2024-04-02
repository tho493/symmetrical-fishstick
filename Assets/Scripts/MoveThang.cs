using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThang : MonoBehaviour
{
    private float move;
    private float speed = 3f;
    private bool isThang;
    private bool isClim;

   [SerializeField] private Rigidbody2D rb;
    

    // Update is called once per frame
    void Update()
    {
        
        if(isThang )
        {
            isClim= true;
            move = Input.GetAxis("Vertical");
        }
        else
        {
            return;
        }
       
    }
    private void FixedUpdate()
    {
        if(isClim)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, move * speed);

        }
        else
        {
            rb.gravityScale = 1f;   
        }
    }
    private void OnTriggerEnter2D ( Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isThang = true;
        }
        
    }
    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Ladder"))
            {
            isThang = false;
            isClim = false;
           
        }
    }
}
