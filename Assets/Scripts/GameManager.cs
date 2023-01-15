using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int platformCount = 30;
    Vector3 spawnPosition = new Vector3();
    
    public GameObject cloudPrefab;
    public float cloudSpawnTime = 1.0f;
    private int cloudCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        // Spawn 30 platforms
        for (int i = 0; i < platformCount; i++)
        {
            spawnPosition.y += Random.Range(.5f, 2f);
            spawnPosition.x = Random.Range(-2.2f, 2.2f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        // Spawn 5 clouds
        while (cloudCount < 5) 
        {
            Vector3 cloudSpawnPosition = new Vector3();
            
            cloudSpawnPosition.x = Random.Range(-4f, 4f);
            cloudSpawnPosition.y = Camera.main.transform.position.y + Random.Range(0f, 5f);
            Instantiate(cloudPrefab, cloudSpawnPosition, Quaternion.identity);
            cloudSpawnTime = Time.time + Random.Range(3f, 10f);
            cloudCount += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        // Keep the platform count at at least 30
        while (platformCount < 30)
        {
            spawnPosition.y += Random.Range(.5f, 2f);
            spawnPosition.x = Random.Range(-2.2f, 2.2f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            platformCount += 1;
        }

        // Keep the cloud count at at least 3, and if it is over 3 then no more than 10 with a delay in spawn time
        if (cloudCount < 3 || (Time.time > cloudSpawnTime && cloudCount < 10))
        {
            Vector3 cloudSpawnPosition = new Vector3();
            
            // Choose whether it starts at the left or right
            int left = Random.Range(0, 2);
            if (left == 0)
                cloudSpawnPosition.x = -4.0f;
            else
                cloudSpawnPosition.x = 4.0f;

            // Choose a random y position
            cloudSpawnPosition.y = Camera.main.transform.position.y + Random.Range(-1f, 5f);
            Instantiate(cloudPrefab, cloudSpawnPosition, Quaternion.identity);

            // Set a timer
            cloudSpawnTime = Time.time + Random.Range(2f, 5f);
            cloudCount += 1;
        }
        
        // Camera.main.transform.position
    }
}
