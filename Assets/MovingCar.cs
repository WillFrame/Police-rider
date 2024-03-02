using UnityEngine;

public class MovingCar : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected float CurrentRotate = 0;
    public float MaxSpeed;
    public float RotateSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Move()
    {
        transform.position += MaxSpeed * Time.deltaTime * transform.up;
    }

    protected void Rotate()
    {
        rb.MoveRotation(CurrentRotate);
    }
}
