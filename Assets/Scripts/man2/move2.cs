using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class move2 : MonoBehaviour
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

    bool ground = false;
    bool bossGround = false;
    

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
        if (heath == 0)
        {
            GameOver();
           
        }
    }
    // ấn r để hiện key;
  
    private void Jump()
    {
        
        if (ground || bossGround )
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
            scale.x = 1.5f;
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
            scale.x = -1.5f;
            transform.localScale = scale;

            anim.SetBool("run2", true);

        }
        else if (h == 0)
        {
            anim.SetBool("run2", false);
        }



        rb.velocity = new Vector2(forceX, rb.velocity.y);
       
        ControGame();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public GameObject boxdieboss;
    public AudioClip no;
    private void OnCollisionEnter2D(Collision2D other)
    {
        // va chạm với đất
        if (other.gameObject.CompareTag("Ground"))
        {
            ground = true;
          
        }
        // va chạm với boss
        else if (other.gameObject.CompareTag("boss"))
        {
           
            bossGround = true;
            heath--;
            audioSource.PlayOneShot(die, 0.5f);

          

        }
       
        // cham vào đầu boss chết
        else if(other.gameObject.CompareTag("boxdieboss"))
        {
            Destroy(boxdieboss);
            audioSource.PlayOneShot(no, 0.5f);
        }
        else{
            ground = false;
        }

    }
   
    public GameObject cuaAi;
    public GameObject danNo;
    private int coutKey;
    public Text coutTextKey;
    private int coutRuby;
    public Text coutTextRuby;
    public GameObject gunMode;
    public GameObject showGunMode;
    public GameObject showBoxKnife;
    public GameObject playerdichchuyen;
 

    public GameObject showKey;
    public GameObject showBossBox2;
    public GameObject thang;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // đi qua màn
        if (other.gameObject.CompareTag("quanMan"))
        {
            if (count >= 20)
            {
                SceneManager.LoadScene(4);
            }
        }
         
        // va cham voi cua dịch chuyển tới chỗ khác
        else if(other.gameObject.CompareTag("dichchuyen"))
        {
            playerdichchuyen.transform.position = new Vector3(-50.61f, 6.6f, transform.position.z);
        }  
        else if(other.gameObject.CompareTag("dichchuyen1"))
        {
            playerdichchuyen.transform.position = new Vector3(-17.9f, 10.98f, transform.position.z);
        }    
        //va cham voi box
        else if(other.gameObject.CompareTag("box1"))
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(point, 0.5f);
        }
        // va cham box hien key;
        else if (other.gameObject.CompareTag("box3"))
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(point, 0.5f);
            thang.SetActive(true);
        }
        else if(other.gameObject.CompareTag("boxkey"))
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(point, 0.5f);
        }    
        // va cham voi hop de nhan sung
        else if(other.gameObject.CompareTag("box"))
        {
             other.gameObject.SetActive(false);
            GunMode();
            audioSource.PlayOneShot(point, 0.5f);

            showGunMode.SetActive(true);
                Destroy(showGunMode,3f);
        }
        // va cham voi box hien dao
        else if(other.gameObject.CompareTag("boxBoss"))
        {
            other.gameObject.SetActive(false);
            showBoxKnife.SetActive(true);
            Destroy(showBoxKnife, 0.3f);
        }    
      
        // ăn điểm
        else if (other.gameObject.CompareTag("coint"))
        {
            //anim.SetBool("blood", true);
            audioSource.PlayOneShot(point, 0.5f);
            count++;
            countText.text = count.ToString();
            other.gameObject.SetActive(false);
        }
        // chết load lại màn
        else if (other.gameObject.CompareTag("die"))
        {
            GameOver();
        }
        // chết bởi đạn boss
        else if (other.gameObject.CompareTag("danBoss"))
        {

            heath--;
            audioSource.PlayOneShot(die, 0.5f);
            other.gameObject.SetActive(false);
            danBossNo();
           
        }
        // va cham voi bom
        else if (other.gameObject.CompareTag("danBoss1"))
        {

            heath--;
            audioSource.PlayOneShot(die, 0.5f);
            danBossNo();
          
        }
        // va cham voi trai tim
        else if (other.gameObject.CompareTag("health"))
        {
            heath++;
            audioSource.PlayOneShot(point, 0.5f);
            other.gameObject.SetActive(false);
        }
        // va cham voi key
       else if (other.gameObject.CompareTag("key"))
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(point, 0.5f);
            coutKey++;
            coutTextKey.text = coutKey.ToString();
                showKey.SetActive(true);
            

        }
        
        //va cham voi ruby
        else if(other.gameObject.CompareTag("ruby"))
        {
            other.gameObject.SetActive(false);
            audioSource.PlayOneShot(point, 0.5f);
            coutRuby++;
            coutTextRuby.text = coutRuby.ToString();
        }
        //va cham voi box2 để hiện quái
        else if(other.gameObject.CompareTag("box2"))
        {
            audioSource.PlayOneShot(point, 0.5f);
            other.gameObject.SetActive(false);
            showBossBox2.SetActive(true);
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
        if (Input.GetKeyDown(KeyCode.B))
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            
        }
      
    }
    public GameObject gameOver;
    public AudioClip Over;
    private void GameOver()
    {

        gameOver.SetActive(true);
      
        Time.timeScale = 0;

    }
    private void GunMode()
    {
        gunMode.SetActive(true);
    }

   

}
