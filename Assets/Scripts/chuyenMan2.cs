﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class chuyenMan2 : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void scene()
    {

        SceneManager.LoadScene(3);

    }
}

