// using System;
// using System.Collections;
// using System.Collections.Generic;
using System.Collections;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

enum RotateDirection
{
    Left,
    Right,
}
enum CarState
{
    Exploded,
    Alive,
}

class Car : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MaxSpeed;
    public float RotateSpeed;
    public CarState State = CarState.Alive;
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

    private IEnumerator Explode()
    {
        State = CarState.Exploded;
        MaxSpeed = 0;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("house"))
        {
            StartCoroutine(Explode());
            Debug.Log("hit_house");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            Rotate(Input.GetKey(KeyCode.A), Input.GetKey(KeyCode.D));

        if (Input.GetKeyDown(KeyCode.L))
            Debug.Log($"x: {rb.GetRelativeVector(Vector2.one)}, z: {transform.rotation.z}");
    }
}
