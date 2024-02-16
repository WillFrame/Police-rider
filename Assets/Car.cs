using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

enum RotateDirection
{
    Left,
    Right,
}

public class Car : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MaxSpeed;
    public float RotateSpeed;
    protected float CurrentRotate = 0;
    private bool isMoving = false;
    private RotateDirection? rotateDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void MoveCurrentRotate()
    {
        if (rotateDirection == RotateDirection.Left)
            CurrentRotate += RotateSpeed;
        if (rotateDirection == RotateDirection.Right)
            CurrentRotate -= RotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            isMoving = true;

        if (Input.GetKeyUp(KeyCode.W))
            isMoving = false;

        if (Input.GetKeyDown(KeyCode.A) && rotateDirection != RotateDirection.Left)
            rotateDirection = RotateDirection.Left;

        if (Input.GetKeyUp(KeyCode.A))
            rotateDirection = null;

        if (Input.GetKeyDown(KeyCode.D) && rotateDirection != RotateDirection.Right)
            rotateDirection = RotateDirection.Right;

        if (Input.GetKeyUp(KeyCode.D))
            rotateDirection = null;

        if (Input.GetKeyDown(KeyCode.L))
            Debug.Log(transform.position);

        if (rotateDirection != null)
            MoveCurrentRotate();

        if (isMoving)
            rb.MovePosition(transform.position + MaxSpeed * Time.fixedDeltaTime * Vector3.up);

        rb.MoveRotation(CurrentRotate);
    }
}
