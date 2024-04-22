using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]

public class bossman3 : MonoBehaviour
{

    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;


    public Animator camAnim;
    public Slider healthBar;
    private Animator anim;
    public bool isDead;

    public AudioClip boom;
   
    private AudioSource audioSource;

    

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public GameObject cuaAi;
    private void Update()
    {

     


        healthBar.value = health;
        if(health <= 0)
        {
            Destroy(gameObject);
            BoonNo();
           cuaAi.SetActive(true);
            

        }    
    }
    public GameObject danNo;
    void BoonNo()
    {
        GameObject danNo1 = Instantiate(danNo, transform.position, Quaternion.identity) as GameObject;
        Destroy(danNo1, 0.5f);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player") && isDead == false)
        {
            if (timeBtwDamage <= 0)
            {
                camAnim.SetTrigger("shake");
                other.GetComponent<Player>().heath -= damage;
            }
        }
        else if(other.CompareTag("dan"))
            {
            audioSource.PlayOneShot(boom, 0.5f);
        }
    }
}
