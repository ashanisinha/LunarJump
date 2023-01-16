using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Text gameOver;
   // public Text restartInstructions;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
       // gameOver.gameObject.SetActive(false);
      //  restartInstructions.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.y < -0.11) {
            gameOver.gameObject.SetActive(true);
           // restartInstructions.gameObject.SetActive(true);
        }
        
    }
}
