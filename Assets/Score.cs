using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI t;
    public string s;

    void Start() {
        s = "Score: 0";
    }

    void Update() {
        s = "Score: " + (SC_2DCoin.totalCoins * 10).ToString();
        t.text = s;
    }
}
