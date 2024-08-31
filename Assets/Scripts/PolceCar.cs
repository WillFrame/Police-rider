class PoliceCar : ExplodableCar
{
    void FixedUpdate()
    {
        if (State == CarState.Alive)
            Move();
        // тут нужно добавить разворот в сторону главной машинки
    }
}
