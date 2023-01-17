using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        // Set initial position
        transform.position = new Vector3(0f, GameManager.distToMoon, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        // Check collision and make player jump up
        if (collision.relativeVelocity.y <= 0f) {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null) {
                Vector2 velocity = rb.velocity;
                velocity.y = 0;
                rb.velocity = velocity;
            }
        }

        Invoke("LoadEndScene", 5f);

        // print(Camera.main.transform.position.y);
        // print("My pos: " + transform.position.y);


    }

    void LoadEndScene() {
        SceneManager.LoadScene("EndScene1");
    }
}
