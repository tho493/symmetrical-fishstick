using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveForce;
    public float jumpForce;
    public float maxVelocity;
    private int demNhay;

    public AudioClip jump;
    public AudioClip die;

    private AudioSource audioSource;

    private Animator anim;

    public int heath = 5;

    bool ground = false;
    bool bossGround = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        mauDead();
        ControGame();
    }

    // hàm máu = 0;
    void mauDead()
    {
        if (heath == 0)
        {
            GameOver();
           
        }
    }
    

    private void Jump()
    {
       
        if (ground || bossGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                audioSource.PlayOneShot(jump, 1f);
                demNhay++;
                if (demNhay == 3)
                {
                    ground = false;
                    bossGround = false;
                    demNhay = 0;
                }
            }
        }
        else
        {
            
        }

    }
    private void Move()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(rb.velocity.x);
        float h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            if (vel < maxVelocity)
            {

                forceX = moveForce;
            }
            else
            {
                forceX = moveForce * 1.1f;
            }

            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;

            anim.SetBool("run2", true);

        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {

                forceX = -moveForce;

            }
            else
            {
                forceX = -moveForce * 1.1f;
            }

            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool("run2", true);

        }
        else if (h == 0)
        {
            anim.SetBool("run2", false);
        }



        rb.velocity = new Vector2(forceX, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    public GameObject gameOver;
    private void GameOver()
    {

        gameOver.SetActive(true);
       
        Time.timeScale = 0;

    }
    public GameObject danNo;
   
    void danBossNo()
    {
        GameObject danNo1 = Instantiate(danNo, transform.position, Quaternion.identity) as GameObject;
        Destroy(danNo1, 0.5f);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // va chạm với đất
        if (other.gameObject.CompareTag("Ground"))
        {
            ground = true;
           
        }
        else if(other.gameObject.CompareTag("boss1"))
        {

            heath--;
            audioSource.PlayOneShot(die, 0.5f);
            danBossNo();
        }    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("boss"))
        {
            heath--;
            audioSource.PlayOneShot(die, 0.5f);
            danBossNo();
            
        } 
        else if (other.gameObject.CompareTag("danBoss1")){
            heath--;
            audioSource.PlayOneShot(die, 0.5f);
            danBossNo();
            
        }
        else if (other.gameObject.CompareTag("quanMan"))
        {
            SceneManager.LoadScene(5);
        }
    }

    public GameObject pause;
    private void ControGame()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
           
            pause.SetActive(true);
            Time.timeScale = 0;

        }
      
    }





}
