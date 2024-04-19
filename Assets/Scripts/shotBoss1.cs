using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class shotBoss1 : MonoBehaviour
{
    public GameObject gun;
    public GameObject dan;
    public float speedDan;
    public GameObject viTriBan;
    public GameObject boss;
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
    void Shoot()
    {
        GameObject go = Instantiate(dan, viTriBan.transform.position, gun.transform.rotation);
        if (boss.transform.localScale.x == -0.5 || boss.transform.localScale.x == -1 ) 
        {
           

            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * speedDan, ForceMode2D.Impulse);
        }
        else 
        {
           

            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * speedDan, ForceMode2D.Impulse);
        }

    }

}
