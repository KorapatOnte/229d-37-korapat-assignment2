using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; 
    public float rotationSpeed = 90f; 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        MovePlayer(movement);
        RotatePlayer(horizontal);
    }

    void MovePlayer(Vector3 direction)
    {
        Vector3 newPosition = rb.position + transform.TransformDirection(direction) * speed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }

    void RotatePlayer(float horizontalInput)
    {
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);

        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
