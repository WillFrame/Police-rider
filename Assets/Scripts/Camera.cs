using UnityEngine;

class Camera : MonoBehaviour
{
    private Quaternion CurrentRotation;

    // Запоминаем нужный поворот камеры
    void Start()
    {
        CurrentRotation = transform.rotation;
    }

    // На каждый апдейт оставляем камеру в нужном положении разворота
    void Update()
    {
        transform.rotation = CurrentRotation;

    }
}