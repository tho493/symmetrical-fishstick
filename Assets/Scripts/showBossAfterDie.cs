using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showBossAfterDie : MonoBehaviour
{
    public GameObject bornBoss;
    public GameObject bossdie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!bossdie )
        {
            bornBoss.SetActive(true) ;
        }    
    }
}
