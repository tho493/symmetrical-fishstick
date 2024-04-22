using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class chuyenman3 : MonoBehaviour
{
   
    void Start()
    {
        Time.timeScale = 1;
    }

   
    void Update()
    {
        
    }
    public void scene()
    {

        SceneManager.LoadScene(4);

    }

}
