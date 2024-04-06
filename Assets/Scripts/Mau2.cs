using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mau2 : MonoBehaviour
{
    public Sprite[] Heartsprite;

    
     public move2 player1;
    public Image Heart;

   
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<move2>();


    }

    void Update()
    {
       
        Heart.sprite = Heartsprite[player1.heath];
    }
}