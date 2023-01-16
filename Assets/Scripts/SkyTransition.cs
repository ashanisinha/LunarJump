using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyTransition : MonoBehaviour
{
    public float transitionStart = 118000f/2000f;

    public GameManager manager;

    public float cameraOffset = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.31f, 0.31f, 1);
        transform.position = new Vector3(0, transitionStart, 0);
        manager = FindObjectOfType<GameManager>();
        manager.skyTransitionY = transitionStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (transitionStart < Camera.main.transform.position.y + cameraOffset)
        {
            transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y + cameraOffset
             - (Camera.main.transform.position.y - transitionStart + cameraOffset) / 2f, 0);
            manager.skyTransitionY = transform.position.y;
        }
    }
}
