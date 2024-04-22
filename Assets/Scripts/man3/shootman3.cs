using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class shootman3 : MonoBehaviour
{

    public int damage;
    public float speed;
    
    public GameObject boomNo;
    public GameObject danNo;
    private Animator camAnim;

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.CompareTag("boss"))
        {
            
            camAnim = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
            camAnim.SetTrigger("shake");
            other.GetComponent<bossman3>().health -= damage;
         
            BoonNo();
            Destroy(gameObject);
            OnDestroy();
        }
    }
    void OnDestroy()
    {
      
        GameObject no = Instantiate(boomNo, transform.position, Quaternion.identity) as GameObject;
        Destroy(no, 0.05f);
    }
    void BoonNo()
    {
        GameObject danNo1 = Instantiate(danNo, transform.position, Quaternion.identity) as GameObject;
        Destroy(danNo1, 0.5f);
    }
}
