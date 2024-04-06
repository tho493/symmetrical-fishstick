using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bomNo : MonoBehaviour
{


    public float timeDuration;
    private float count;
    public float  d;
    private GameObject boss;
    public GameObject bomm;

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Player");
    }
    void Awake()
    {
        count = timeDuration;
       
    }
    void Update()
    {



        count -= Time.deltaTime;

        if (count <= 0)
        {


          
            GameObject bom = Instantiate(bomm, transform.position, Quaternion.identity);
            bom.GetComponent<boom>().target = boss.transform.position;
            count = timeDuration;


        }
       

      
    }
   
}
