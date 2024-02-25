// using System;
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Rotate(bool isRightRotate, bool isLeftRotate)
    {
        if (isRightRotate && isLeftRotate)
            return;

        if (isRightRotate)
            CurrentRotate += RotateSpeed * Time.deltaTime;
        else
            CurrentRotate -= RotateSpeed * Time.deltaTime;

        rb.MoveRotation(CurrentRotate);
    }

    void Move()
    {
        transform.position += MaxSpeed * Time.deltaTime * transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            Move();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            Rotate(Input.GetKey(KeyCode.A), Input.GetKey(KeyCode.D));

        if (Input.GetKeyDown(KeyCode.L))
            Debug.Log($"x: {rb.GetRelativeVector(Vector2.one)}, z: {transform.rotation.z}");
    }
}
