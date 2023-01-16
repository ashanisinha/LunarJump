using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // 0 and 1 move to the right, 2 and 3 move to the left
    public Sprite[] cloudSprites;
    public SpriteRenderer sr;

    public GameManager manager;

    public float distAway = 1.0f;
    public float xVel = 0f;
    public bool startedLeft = true;
    public float camStartY = 0f;
    public float startY = 0f;

    private float xThresh = 4.1f;

    public float fadeSpeed = 0.1f;

    void Start()
    {
        // Randomize the cloud sprite
        int cloudSprite = Random.Range(0,2);

        manager = FindObjectOfType<GameManager>();

        // Randomize the "distance away" from the screen
        distAway = 1.0f + Mathf.Pow(Random.Range(0.0f, 1.0f), 4) * 50.0f;

        // Randomize velocity, relative to distance away
        xVel = Random.Range(0.01f, 0.011f) / distAway;
        if (gameObject.transform.position.x > 0)
        {
            startedLeft = false;
            xVel *= -1;

            // Starting on the right side, so we want to access the two "left moving" cloud sprites
            cloudSprite += 2;
        }
        
        // Choose the random sprite
        sr.sprite = cloudSprites[cloudSprite];

        // Since these two are bigger, make it disappear after exiting
        if (cloudSprite % 2 == 1)
        {
            xThresh = 5.0f;
        }
        // NOTE: we can make the cloud disappear at a better time when exiting the screen 
        // using more math and the size of the cloud but I'm too lazy to do the math, if 
        // anyone wants to do it please do it

        // Scale the cloud so it looks smaller when further, bigger when closer
        Vector3 scale = gameObject.transform.localScale;
        // TODO: change the scale to be random, but more likely to be small when further away
        scale /= Mathf.Max(1.0f, Mathf.Log(distAway, 10)) / 2.0f;
        gameObject.transform.localScale = scale;

        // Record the starting y and the starting camera y (crucial to scale how much the y position changes)
        camStartY = Camera.main.transform.position.y;
        startY = gameObject.transform.position.y;
    }

    void LateUpdate()
    {
        // Update the position of the cloud (move left/right at a constant speed, and move "down" on the screen relative to the camera position)
        float camY = Camera.main.transform.position.y;
        transform.position = new Vector3(transform.position.x + xVel, camY + (startY - camStartY) - (camY - camStartY) / distAway, 0);
        
        // If on the edge of the screen, destroy the object
        if (camY - transform.position.y > 6.0f)
        {
            Destroy(gameObject);
            manager.cloudCount--;
        }
        else if (startedLeft)
        {
            if (transform.position.x > xThresh)
            {
                Destroy(gameObject);
                manager.cloudCount--;
            }
        }
        else if (transform.position.x < -xThresh)
        {
            Destroy(gameObject);
            manager.cloudCount--;
        }
        
        // fade out
        if (manager.starsOut)
        {
            Color objColor = this.GetComponent<SpriteRenderer>().material.color;
            this.GetComponent<SpriteRenderer>().material.color = new Color(objColor.r, objColor.g, objColor.b, objColor.a - (fadeSpeed * Time.deltaTime));

            if (this.GetComponent<SpriteRenderer>().material.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
