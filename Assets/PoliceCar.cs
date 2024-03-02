using UnityEngine;

public class PoliceCar : MovingCar
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
    }
}
