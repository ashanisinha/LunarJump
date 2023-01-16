using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingGame : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Invoke("Call",10f);
    }

    void Call() {
        SceneManager.LoadScene("SampleScene");
}
}