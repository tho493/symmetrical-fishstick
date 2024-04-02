using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continute : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pause;
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void tiep()
    {
        pause.SetActive(false); 
        Time.timeScale = 1;
    }
}
