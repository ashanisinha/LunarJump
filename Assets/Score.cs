using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI t;
    public Transform player;
    public string s;
    int score;

    void Start() {
        s = "Score: 0";
    }

    void Update() {
        score = (int)(player.position.y)+(SC_2DCoin.totalCoins * 10);
        s = "Score: " + score.ToString();
        t.text = s;
    }
}
