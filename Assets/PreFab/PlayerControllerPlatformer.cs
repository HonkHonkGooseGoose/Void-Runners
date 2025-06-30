using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
        moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);

        //if (moveX > 0)
        //{
        //    playerSprite.flipX = false;
        //}

        //if (moveX < 0)
        //{
        //    playerSprite.flipX = true;
        //}

        //Jump Code
        if (jumping == false && Input.GetButtonDown("Jump") || jumping == false && Input.GetKeyDown(KeyCode.W))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            jumping = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restarts game 
        }

        void OnCollisionEnter2D(Collision collision) { 
            if (collision.gameObject.tag == "Ground")
            {
                jumping = false;
            }

        }
    }
}





       