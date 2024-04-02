using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mau : MonoBehaviour
{
    public Sprite[] Heartsprite;

    public move player;
    public Image Heart;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<move>();
       
    
    }

    void Update()
    {
       
        Heart.sprite = Heartsprite[player.heath];
    }
}