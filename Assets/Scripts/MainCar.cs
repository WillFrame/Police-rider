using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

class MainCar : ExplodableCar
{
    protected override IEnumerator Explode()
    {
        StartCoroutine(base.Explode());
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
        yield return null;
    }

    void Update()
    {
        if (State == CarState.Alive)
        {
            Move();

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
                return;
            if (Input.GetKey(KeyCode.A))
                Rotate(RotateDirection.Left);
            if (Input.GetKey(KeyCode.D))
                Rotate(RotateDirection.Right);
        }
    }
}
