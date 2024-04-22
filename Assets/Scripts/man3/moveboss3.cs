using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveboss3 : MonoBehaviour
{

    public GameObject player;
    public float move = 1f ;
   
    void Start()
    {
       

    }

  
    void Update()
    {
       
        transform.position += new Vector3(0.0f, -move * Time.deltaTime, 0.0f);
    }
    void quay()
    {
        move *= -1;
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("moc"))
        {
            quay();
        }
    }
   
}
