using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI t;
    
    public string s;
    int score;

    void Start() {
        s = "score: 0";
    }

    void Update() {
        if(GameManager.endgame == false) {
            score = (int)(Camera.main.transform.position.y)+(Carrot.totalCarrots * 10); //calculating score
            s = "score: " + score.ToString();
            t.text = s; // setting score
        }
    }
}
