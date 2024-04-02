using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class shoot : MonoBehaviour
{
    public GameObject gun;
    public GameObject dan;
    public float speedDan;
    public GameObject viTriBan;
    public float tocDoc;
    private float timeShoot;
    public GameObject player;

    public AudioClip shot;
    private AudioSource audioSource;
   

    public float scaleX;
   
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       

    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
            audioSource.PlayOneShot(shot, 0.1f);
        }
       
        
    }
    void Shoot()
    {
        GameObject go = Instantiate(dan, viTriBan.transform.position, gun.transform.rotation);
       
        if (player.transform.localScale.x == scaleX)
        {
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0) * speedDan, ForceMode2D.Impulse);
        }
        else {
            go.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * speedDan, ForceMode2D.Impulse);
        }
    }
   
  
}
