using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    public float xMin, xMax, zMim, zMax;
    public float tiltH, tiltV;
    public float moveHorizontal;
    public float moveVertical;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
    }
    private void FixedUpdate()
    {
        moveHorizontal = joystick.Horizontal;
        moveVertical = joystick.Vertical;

        rb.rotation = Quaternion.Euler(rb.velocity.y * -tiltV, 0f, rb.velocity.x * -tiltH);

        rb.velocity = new Vector3(moveHorizontal, moveVertical, 0f) * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, xMin, xMax), Mathf.Clamp(rb.position.y, zMim, zMax), 0f);
    }
}
