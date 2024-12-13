using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    //Keep track of total picked carrots (Since the value is static, it can be accessed at "Carrot.totalCarrots" from any script)
    public static int totalCarrots = 0; 
    public GameManager manager;
    FMOD.Studio.EventInstance Collect;
    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
        Collect = FMODUnity.RuntimeManager.CreateInstance("event:/Collect");

    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the carrot if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            //Add carrot to counter
            totalCarrots++;
            //Test: Print total number of carrots
            // Debug.Log("You currently have " + Carrot.totalCarrots + " Coins.");
            manager.carrotCount--;
            Destroy(gameObject);
            Collect.start();
        }

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
