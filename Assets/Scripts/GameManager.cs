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
    public int cloudCount = 0;

    public float skyTransitionY = 59f;

    public GameObject starPrefab;
    public int starCount = 0;
    public bool starsOut = false;
    public bool initialStars = true;
    public int maxStars = 70;

    public GameObject carrotPrefab;
    public int carrotCount = 1;
    Vector3 carrotSpawnPosition = new Vector3();

    // TODO:
    // make transitions of sky and background
    // add moon
    // make stars
    // meteors
    // add score system

    // Start is called before the first frame update
    void Start()
    {
        starsOut = false;
        spawnPosition = new Vector3(0, 1f, 0);
        carrotSpawnPosition = new Vector3(0, 1f, 0);
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


        while (carrotCount < 30)
        {
            carrotSpawnPosition.y += Random.Range(1f, 4f);
            carrotSpawnPosition.x = Random.Range(-2.5f, 2.5f);
            Instantiate(carrotPrefab, carrotSpawnPosition, Quaternion.identity);
            carrotCount++;
        }
        if (!starsOut)
        {
                
            // Keep the cloud count at at least 3, and if it is over 3 then no more than 10 with a delay in spawn time
            if (cloudCount < 3 || (Time.time > cloudSpawnTime && cloudCount < 10))
            {
                Vector3 cloudSpawnPosition = new Vector3();
                
                // Choose whether it starts at the left or right
                int left = Random.Range(0, 2);
                if (left == 0)
                    cloudSpawnPosition.x = -4.5f;
                else
                    cloudSpawnPosition.x = 4.5f;

                // Choose a random y position
                cloudSpawnPosition.y = Camera.main.transform.position.y + Random.Range(-1f, 5f);
                Instantiate(cloudPrefab, cloudSpawnPosition, Quaternion.identity);

                // Set a timer
                cloudSpawnTime = Time.time + Random.Range(2f, 5f);
                cloudCount += 1;
            }
            if (skyTransitionY < Camera.main.transform.position.y)
            {
                starsOut = true;
                Color newColor = new Color(57f/255f, 28f/255f, 84f/255f);
                Camera.main.backgroundColor = newColor;
            }
        }
        else
        {
            if (starCount <= maxStars)
            {
                Vector3 starSpawnPosition = new Vector3();
                starSpawnPosition.y = Camera.main.transform.position.y + Random.Range(8f, 8.5f);

                if (initialStars)
                {
                    int initCount = 0;
                    while(initCount <= maxStars) {
                        starSpawnPosition.x = Random.Range(-2.8f, 2.8f);
                        starSpawnPosition.y = Camera.main.transform.position.y + Random.Range(-5f, 5f);
                        Instantiate(starPrefab, starSpawnPosition, Quaternion.identity);
                        initCount += 1;
                    }
                    initialStars = false;
                    print(starCount);
                    maxStars = 200;
                }
                else
                {
                    if (maxStars != starCount)
                    {
                        maxStars = Mathf.Max(200, starCount);
                    }
                    starSpawnPosition.x = Random.Range(-2.8f, 2.8f);
                    Instantiate(starPrefab, starSpawnPosition, Quaternion.identity);
                }
            }
        }
        
        // Camera.main.transform.position
    }
}
