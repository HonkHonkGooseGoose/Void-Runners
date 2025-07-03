using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float length;
    Transform startObject;
    Transform endObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the start and end objects of the obstacle

        startObject = transform.Find("Start");
        endObject = transform.Find("End");
        CalculateLength();
    }

    void CalculateLength()
    {
        // Calculate the length of the obstacle based on its size
        length = Vector3.Distance(startObject.position, endObject.position);
    }
}