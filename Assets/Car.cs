using UnityEngine;

public class Car : MovingCar
{
    void HandleRotate()
    {
        bool isRightRotate = Input.GetKey(KeyCode.A);
        bool isLeftRotate = Input.GetKey(KeyCode.D);

        if (isRightRotate && isLeftRotate)
            return;

        if (isRightRotate)
            CurrentRotate += RotateSpeed * Time.deltaTime;
        if (isLeftRotate)
            CurrentRotate -= RotateSpeed * Time.deltaTime;

        Rotate();
    }

    void Update()
    {
        Move();
        HandleRotate();

        if (Input.GetKeyDown(KeyCode.L))
            Debug.Log($"x: {rb.GetRelativeVector(Vector2.one)}, z: {transform.rotation.z}");
    }
}
