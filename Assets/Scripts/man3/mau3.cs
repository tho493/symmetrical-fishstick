using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mau3 : MonoBehaviour
{
    public Sprite[] Heartsprite;

    public Player player1;
    public Image Heart;

   
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      


    }

   
    void Update()
    {
       
        Heart.sprite = Heartsprite[player1.heath];
    }
}