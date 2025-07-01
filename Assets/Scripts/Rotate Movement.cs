using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;

    private bool autoRotate = false;


    // Update is called once per frame 
     void Update()
    {
     
            this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
      
    }

}
