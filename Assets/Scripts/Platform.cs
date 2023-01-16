using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{   // further higher platforms go the more jump force changes
    // also can implement super jump here
    public float jumpForce = 10f;
    public GameManager manager;
    FMOD.Studio.EventInstance Jump;
    
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        Jump = FMODUnity.RuntimeManager.CreateInstance("event:/Jump");
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        // Check collision and make player jump up
        if (collision.relativeVelocity.y <= 0f) {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null) {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                Jump.start();
            }
        }

        // print(Camera.main.transform.position.y);
        // print("My pos: " + transform.position.y);


    }
    void Update()
    {
        // If the platform is far enough below the screen, delete the platform
        if (Camera.main.transform.position.y - transform.position.y > 7.5)
        {
            manager.platformCount--;
            Destroy(gameObject);
        }
    }
}
