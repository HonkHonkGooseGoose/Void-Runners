using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update() 
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
    }
}


