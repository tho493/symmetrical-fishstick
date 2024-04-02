using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bornVat : MonoBehaviour
{

    public GameObject fabs;
    public float timeDuration;
    private float count;

    public Vector3 vector;
    public float x;
    public float y;
    public float z;
   

    void Start()
    {
        
        vector = new Vector3(x, y, z);
       


    }
    void Awake()
    {
        count = timeDuration;
       
    }
    void Update()
    {
        count -= Time.deltaTime;


        if (count <= 0)
        {


            Instantiate(fabs, vector, Quaternion.identity);
            count = timeDuration;

            
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Player" ))
        {


            Destroy(gameObject);


        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            
           
                Destroy(gameObject,1f);
            
           
        }
    }
}
