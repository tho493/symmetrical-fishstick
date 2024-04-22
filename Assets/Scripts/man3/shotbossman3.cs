using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class shotbossman3 : MonoBehaviour
{
    public GameObject gun;
    public GameObject dan;
    public float speedDan;
    public GameObject viTriBan;
  
    private float count;
    public float demNguoc;

   


    void Start()
    {
        count = demNguoc;
    }


    void Update()
    {
      
        count -= Time.deltaTime;
        if (count <= 0)
        {
            Shoot();
         
            count = demNguoc;
           
        }
      
        

    }
    public float danX, danY;
    void Shoot()
    {
        GameObject go = Instantiate(dan, gun.transform.position, viTriBan.transform.rotation);
         go.GetComponent<Rigidbody2D>().AddForce(new Vector2(danX, danY) * speedDan, ForceMode2D.Impulse);  
    }
    void OntriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(dan);
        }    
    }

}
