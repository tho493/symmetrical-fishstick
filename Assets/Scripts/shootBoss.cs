using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class shootBoss : MonoBehaviour
{
    public GameObject gun;
    public GameObject dan;
    public float speedDan;
    public GameObject viTriBan;

    void Start()
    {    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
           
        }

    }
    void Shoot()
    {

        GameObject go = Instantiate(dan, viTriBan.transform.position, gun.transform.rotation);
    
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * speedDan, ForceMode2D.Impulse);
        
    }
   
}
