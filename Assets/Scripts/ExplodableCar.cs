using System.Collections;
using UnityEngine;

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

class ExplodableCar : MonoBehaviour
{
    public float Speed;
    public float RotateSpeed;
    protected float CurrentRotate = 0;
    protected Rigidbody2D rb;
    protected CarState State = CarState.Alive;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Rotate(RotateDirection Direction)
    {
        if (Direction == RotateDirection.Left)
            CurrentRotate += RotateSpeed * Time.deltaTime;
        else
            CurrentRotate -= RotateSpeed * Time.deltaTime;

        rb.MoveRotation(CurrentRotate);
    }

    protected void Move()
    {
        transform.position += Speed * Time.deltaTime * transform.up;
    }

    protected virtual IEnumerator Explode()
    {
        State = CarState.Exploded;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    // тут можем убрать параметры в функции?
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Explode());
    }
}
