using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerControllerPlatformer : MonoBehaviour
{
<<<<<<< Updated upstream
    public float speed = 3;
=======
    public float speed = 2;

    public Animator animator;
>>>>>>> Stashed changes
    float moveX;

    float jumpForce = 8.0f;
    bool jumping = false;
    bool death = false;

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
        animator.SetFloat("Speed", Mathf.Abs(moveX));
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
        if (Keyboard.current.shiftKey.isPressed)
<<<<<<< Updated upstream
            speed = 100;
=======
            speed = 10;
>>>>>>> Stashed changes
        else
            speed = 9;
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
            death = true;
        }
    }
}






