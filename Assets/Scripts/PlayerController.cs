using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rb;

    private float moveX;
    bool facingRight = true;

    public Animator animator;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        // Move the character horizontally based on input ('a' and 'd' or left and right arrow keys)
        moveX = Input.GetAxis("Horizontal") * moveSpeed;

    }

    private void FixedUpdate()
    {
        // Set velocity
        Vector2 velocity = rb.velocity;
        velocity.x = moveX;
        rb.velocity = velocity;

        animator.SetFloat("yVel", rb.velocity.y);

        // Depending on which way player is moving, flip the player
        if (moveX > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveX < 0 && facingRight)
        {
            Flip();
        }
        
        // If on the edge of the screen, move the player to the other side
        if (transform.position.x < -3.1f)
        {

            Vector3 temp = new Vector3(3.1f,transform.position.y,transform.position.z);
            gameObject.transform.position = temp;
        }
        else if (transform.position.x > 3.1f)
        {
            Vector3 temp = new Vector3(-3.1f,transform.position.y,transform.position.z);
            gameObject.transform.position = temp;
        }

    }

    // Function for flipping the player sprite
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
