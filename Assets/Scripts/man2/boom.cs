using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class boom : MonoBehaviour
{
   
    public Vector3 target;
    public float moveBom = 4;
    void Start()
    {
       

    }

    void Update()
    {
        transform.Translate((transform.position - target) * moveBom * Time.deltaTime * -1);
        
       
    }
    public GameObject boomNo;
    void OnDestroy()
    {
        
        GameObject no = Instantiate(boomNo, transform.position, Quaternion.identity) as GameObject;
        Destroy(no,0.6f);
    }
    
    
}
