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
        s = "Score: 0";
    }

    void Update() {
        if(GameManager.endgame == false) {
        score = (int)(Camera.main.transform.position.y)+(Carrot.totalCarrots * 10);
        print(score);
        s = "Score: " + score.ToString();
        t.text = s;
        }
    }
}
