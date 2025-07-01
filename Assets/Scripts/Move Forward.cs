using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void FixedUpdate() // Use FixedUpdate for physics-based movement
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y); // Set the X velocity
    }
}

