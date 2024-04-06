using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class key : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip point;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public GameObject cuaKey;
    public GameObject showkey1;
    public GameObject deletekey;
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("openKey"))
        {
           
            Destroy(deletekey);
            showkey1.SetActive(true);
            
            Destroy(cuaKey,2f);
            audioSource.PlayOneShot(point, 0.5f);
        }
        else
        {


        }
    }
}
