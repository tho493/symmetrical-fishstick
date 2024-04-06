using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class boss1 : MonoBehaviour
{
    private int count = 0;
    public AudioClip boom;
    private AudioSource audioSource;
    public GameObject boomNo;
    public GameObject danNo;
    public GameObject da;

    public int demDan;

    public GameObject showBoss;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }
    public GameObject coint;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("dan"))
        {
            other.gameObject.SetActive(false);
            BoonNo();
            count++;
            audioSource.PlayOneShot(boom, 0.1f);
            if (count == demDan)
            {
                BoonNo();
                Destroy(gameObject);
                OnDestroy();
                showBoss.SetActive(true);
              
               
            }

        }

        void OnDestroy()
        {
            GameObject no = Instantiate(boomNo, transform.position, Quaternion.identity) as GameObject;
            Destroy(no, 1f);
        }
        void BoonNo()
        {
            GameObject danNo1 = Instantiate(danNo, transform.position, Quaternion.identity) as GameObject;
            Destroy(danNo1, 0.5f);
        }

    }
}
