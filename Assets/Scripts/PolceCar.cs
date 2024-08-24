class PoliceCar : ExplodableCar
{
    void Update()
    {
        if (State == CarState.Alive)
            Move();
        // тут нужно добавить разворот в сторону главной машинки
    }
}
