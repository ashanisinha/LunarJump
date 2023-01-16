using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // 0 and 1 move to the right, 2 and 3 move to the left
    public Sprite[] starSprites;
    private int starSprite;
    public SpriteRenderer sr;

    public GameManager manager;

    public float distAway = 1.0f;
    public float camStartY = 0f;
    public float startY = 0f;

    private bool fadeIn = true;
    public float fadeSpeed = 0.1f;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        
        // Randomize the cloud sprite
        starSprite = Random.Range(0,17);
        // Choose the random sprite
        sr.sprite = starSprites[starSprite];
        /*
         *
         * Sprites  0 ~  5: tiny  stars
         * Sprites  6 ~  7: small stars
         * Sprites  8 ~ 11: med.  stars
         * Sprites 12 ~ 15: reg.  stars
         * Sprite       16: Big   stars
         *
        */
        // Randomize the "distance away" from the screen, based on the sprites
        // Tiny stars
        if (starSprite < 6)
        {
            distAway = 55.0f + Mathf.Pow(Random.Range(0.0f, 1.0f), 4) * 30.0f;
            manager.starCount += 1;
        }
        else if (starSprite < 8)
        {
            distAway = 50.0f + Mathf.Pow(Random.Range(0.0f, 1.0f), 4) * 20.0f;
            manager.starCount += 2;
        }
        else if (starSprite < 12)
        {
            distAway = 40.0f + Mathf.Pow(Random.Range(0.0f, 1.0f), 4) * 15.0f;
            manager.starCount += 3;
        }
        else if (starSprite < 15)
        {
            distAway = 35.0f + Mathf.Pow(Random.Range(0.0f, 1.0f), 4) * 15.0f;
            manager.starCount += 4;
        }
        else
        {
            distAway = 30.0f + Mathf.Pow(Random.Range(0.0f, 1.0f), 4) * 25.0f;
            manager.starCount += 5;
        }

        // Set the initial alpha to 0
        Color objColor = this.GetComponent<SpriteRenderer>().material.color;
        this.GetComponent<SpriteRenderer>().material.color = new Color(objColor.r, objColor.g, objColor.b, 0f);

        // // Scale the cloud so it looks smaller when further, bigger when closer
        // Vector3 scale = gameObject.transform.localScale;
        // // TODO: change the scale to be random, but more likely to be small when further away
        // scale /= Mathf.Max(1.0f, Mathf.Log(distAway, 10)) / 2.0f;
        // gameObject.transform.localScale = scale;

        // Record the starting y and the starting camera y (crucial to scale how much the y position changes)
        camStartY = Camera.main.transform.position.y;
        startY = gameObject.transform.position.y;
    }

    void LateUpdate()
    {
        // Update the position of the cloud (move left/right at a constant speed, and move "down" on the screen relative to the camera position)
        float camY = Camera.main.transform.position.y;
        transform.position = new Vector3(transform.position.x, camY + (startY - camStartY) - (camY - camStartY) / distAway, 0);
        
        // If on the edge of the screen, destroy the object
        if (camY - transform.position.y > 5.5f)
        {
            if (starSprite < 6)
            {
                manager.starCount -= 1;
            }
            else if (starSprite < 8)
            {
                manager.starCount -= 2;
            }
            else if (starSprite < 12)
            {
                manager.starCount -= 3;
            }
            else if (starSprite < 15)
            {
                manager.starCount -= 4;
            }
            else
            {
                manager.starCount -= 5;
            }
            Destroy(gameObject);
        }
        
        // fade in the stars once transition from earth to space
        if (fadeIn)
        {
            Color objColor = this.GetComponent<SpriteRenderer>().material.color;
            this.GetComponent<SpriteRenderer>().material.color = new Color(objColor.r, objColor.g, objColor.b, objColor.a + (fadeSpeed * Time.deltaTime));

            if (this.GetComponent<SpriteRenderer>().material.color.a >= 1)
            {
                fadeIn = false;
            }
        }
        
    }
}
