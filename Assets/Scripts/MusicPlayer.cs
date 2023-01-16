using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    public static float distToMoon = 382500f/2f;
    public GameObject Player;
    FMOD.Studio.EventInstance Music;

    public float currentDistance()
    {
        return (Player.transform.position.y- distToMoon);
    }

    // Start is called before the first frame update
    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        Music.start();
    }

    // Update is called once per frame
    void Update()
    {
        float progress = (currentDistance() / distToMoon) * 100;
        //progress is negative... so I'll just do this lmao
        progress += 100;
        Debug.Log($"progress: {progress}");
        Music.setParameterByName("Player Progress", progress);
    }
}
