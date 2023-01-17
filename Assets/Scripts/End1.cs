using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End1 : MonoBehaviour
{
    void Start()
    {
        Invoke("Call",5f);
    }

    void Call() {
        SceneManager.LoadScene("EndScene2");
}
}
