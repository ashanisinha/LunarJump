using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{   // further higher platforms go the more jump force changes
    // also can implement super jump here
    public float jumpForce = 10f;
    public GameObject platform;
    public GameManager manager;
    
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D (Collision2D collision) {

        if (collision.relativeVelocity.y <= 0f) {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null) {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }

        // print(Camera.main.transform.position.y);
        // print("My pos: " + transform.position.y);


    }
    void Update()
    {
        if (Camera.main.transform.position.y - transform.position.y > 7.5)
        {
            manager.platformCount--;
            Destroy(platform);
        }
    }
}
