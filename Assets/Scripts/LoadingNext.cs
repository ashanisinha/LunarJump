using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingNext : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Invoke("Calls",7f);
    }

    void Calls() {
        SceneManager.LoadScene("1.1cutscne");
    }
}
