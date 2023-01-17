using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingGame : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        Invoke("Call",8f);
    }

    void Call() {
        SceneManager.LoadScene("SampleScene");
}
}