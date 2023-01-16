using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    //Keep track of total picked carrots (Since the value is static, it can be accessed at "SC_2DCoin.totalCarrots" from any script)
    public static int totalCarrots = 0; 
    public GameManager manager;

    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            //Add coin to counter
            totalCarrots++;
            //Test: Print total number of coins
            Debug.Log("You currently have " + Carrot.totalCarrots + " Coins.");
            //Destroy coin
            manager.carrotCount--;
            Destroy(gameObject);
        }
        // //Destroy the coin if Object tagged Platform comes in contact with it
        // if (c2d.CompareTag("Platform"))
        // {
        //     Destroy(gameObject);
        // }
    }

    void Update() 
    {
        // If the platform is far enough below the screen, delete the platform
        if (Camera.main.transform.position.y - transform.position.y > 7.5)
        {
            manager.carrotCount--;
            Destroy(gameObject);
        }
    }
}