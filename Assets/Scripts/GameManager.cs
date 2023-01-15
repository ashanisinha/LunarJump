using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int platformCount = 30;
    Vector3 spawnPosition = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        // print(Camera.main.transform.position);
        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(.5f, 2f);
            spawnPosition.x = Random.Range(-2.2f, 2.2f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        while (platformCount < 30)
        {
            spawnPosition.y += Random.Range(.5f, 2f);
            spawnPosition.x = Random.Range(-2.2f, 2.2f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platformCount += 1;
            print(platformCount);
        }
        
        print(platformCount);
        // Camera.main.trasnform.position
    }
}
