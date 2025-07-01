//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy specific variables
    public float speed;
    public Vector2 pointA;      // First point
    public Vector2 pointB;      // Second Point
    Vector2 target;             // Point to move towards 

    public void Start()
    {
        target = pointA;
    }
    public void Update()
    {
        float step = speed * Time.deltaTime;                                         // Calculate distance to move
        transform.position = Vector2.MoveTowards(transform.position, target, step);  // Move towards target

        if (Vector2.Distance(transform.position, target) < 0.001f)
        {
            if (target == pointA)
            {
                target = pointB;
            }
            else if (target == pointB)
            {
                target = pointA;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }
}