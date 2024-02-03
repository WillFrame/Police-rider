using System;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MaxSpeed = 5f;
    public Vector3 RotateSpeed = new(0.0f, 0.0f, 15.0f);
    // protected int MaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.MovePosition(transform.position + MaxSpeed * Time.fixedDeltaTime * Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(RotateSpeed);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(-RotateSpeed);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(RotateSpeed);
        }
    }

}
