using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showKey : MonoBehaviour
{   
        public GameObject key;  

    void Update()
    {
        show();
    }
    private void show()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            key.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.T))
        {
            key.SetActive(false);
        }
    }
}
