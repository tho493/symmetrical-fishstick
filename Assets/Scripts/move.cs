using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveForce;
    public float jumpForce;
    public float maxVelocity;
    private int demNhay;

    public AudioClip jump;
    public AudioClip die;
    public AudioClip point;
    public AudioClip run;
  


    private int count;
    public Text countText;
   
    private AudioSource audioSource;

    private Animator anim;

    public int heath = 5;

    bool ground = false ;


   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1;

    }

   
    void Update()
    {
        Move();
        Jump();
        mauDead();
       
    }
    // hàm máu = 0;
    void mauDead()
    {
        if(heath == 0)
        {
            GameOver(); 
           
        }    
    }
    private void Jump()
    {
      
        if (ground )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
             
                rb.velocity = new Vector2(rb.velocity.x,  jumpForce);
                audioSource.PlayOneShot(jump, 1f);
                demNhay++;
               if ( demNhay == 3)
                {
                    ground = false; 
                    demNhay = 0;
                }
            }
        }
        else
        {
            anim.SetBool("jump", false);
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

            anim.SetBool("run", true);

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

            anim.SetBool("run", true);

        }
        else if (h == 0)
        {
            anim.SetBool("run", false);
        }



        rb.velocity = new Vector2(forceX, rb.velocity.y);
       
        ControGame();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void  OnCollisionEnter2D ( Collision2D other)
    {
        // va chạm với đất
        if(other.gameObject.CompareTag("Ground"))
        {
            ground = true;
            anim.SetBool("jump", false);
        }
        // va chạm với boss
        else if (other.gameObject.CompareTag("boss"))
        {
           
            heath--;
            audioSource.PlayOneShot(die, 0.5f);
            
           
            
        }
        else 
        {
            ground = false;
        } 
        
    }
    private int coutDan = 0;
    public GameObject cuaAi;
    public GameObject danNo;
    private void OnTriggerEnter2D ( Collider2D other)
    {
        // đi qua màn
        if (other.gameObject.CompareTag("quanMan"))
        {
            if (count >= 10 )
            {     
                    SceneManager.LoadScene(2); 
            }
        }
        // ấn button
        if(other.gameObject.CompareTag("button"))
        {
            audioSource.PlayOneShot(point, 0.5f);
            Destroy(cuaAi);
        }    
        // ăn điểm
        else if (other.gameObject.CompareTag("coint"))
        {
           
            audioSource.PlayOneShot(point, 0.5f);
            count++;
            countText.text = count.ToString();
            other.gameObject.SetActive(false);
        }
        // chết load lại màn
        else if (other.gameObject.CompareTag("die"))
        {
            SceneManager.LoadScene(1);
        }
        // chết bởi đạn boss
        else if(other.gameObject.CompareTag("danBoss"))
        {

            heath--;
            audioSource.PlayOneShot(die, 0.5f);
            other.gameObject.SetActive(false);
            danBossNo();
            coutDan++;
          
            if (coutDan == 100)
            {
               
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.CompareTag("health"))
        {
            heath++;
            audioSource.PlayOneShot(point, 0.5f);
            other.gameObject.SetActive(false);
        }
        else
        {

        }
    }
    void danBossNo()
    {
        GameObject danNo1 = Instantiate(danNo, transform.position, Quaternion.identity) as GameObject;
        Destroy(danNo1, 0.5f);
    }
    public GameObject pause;
    private void ControGame()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        }    
        else if ( Input.GetKeyDown(KeyCode.V))
        {
            pause.SetActive(false) ;       
            Time.timeScale = 1;
        }    
    }
    public GameObject gameOver;
    public AudioClip Over;
    private void GameOver()
    {
        
        gameOver.SetActive(true);
       
        Time.timeScale = 0;

    }


}
