using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerControllerPlatformer : MonoBehaviour
{
    public float speed = 10;
    float moveX;

    float jumpForce = 8.0f;
    bool jumping = false;

    Rigidbody2D rb;
    SpriteRenderer playerSprite;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // Movement

        move();
        //if (moveX > 0)
        //{
        //    playerSprite.flipX = false;
        //}

        //if (moveX < 0)
        //{
        //    playerSprite.flipX = true;
        //}

        // Jump Code
        if (!jumping && (Keyboard.current.spaceKey.wasPressedThisFrame || Keyboard.current.upArrowKey.wasPressedThisFrame))
        {
            jump();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restarts game 
        }
    }



    void move()
    {
        moveX = 0f;
        if (Keyboard.current != null)
        {
            // Simple left/right input
            if (Keyboard.current.leftArrowKey.isPressed)
                moveX = -speed * Time.deltaTime;
            else if (Keyboard.current.rightArrowKey.isPressed)
                moveX = speed * Time.deltaTime;
        }
        //moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);
        //rb.velocity = new Vector2 (moveX, rb.velocity.y);
    }

    void jump()
    {
        rb.linearVelocity = Vector2.up * jumpForce;
        jumping = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumping = false;
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            //gameObject.SetActive(false);
            playerSprite.color = Color.red;
        }
    }
}



