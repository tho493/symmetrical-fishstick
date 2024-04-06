using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDa: MonoBehaviour
{


    public float move = 5f;
    public GameObject fabs;
    public float timeDuration;
    private float count;
    public float x, y,d;
   
    void Start()
    {

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


            Instantiate(fabs, new Vector3(x, y, 0f), transform.rotation);
            count = timeDuration;



        }
        transform.position += new Vector3(-move * Time.deltaTime, 0.0f, 0.0f);
       
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {


            Destroy(gameObject, d);
         

        }
    }
   
}
