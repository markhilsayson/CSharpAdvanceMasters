public class Horse
{
    public string Name { get; }
    public int Speed { get; set; }
    public int Position { get; set; }

    public Horse(string name)
    {
        Name = name;
    }

    public void SetSpeed(int speed)
    {
        Speed = speed;
    }

    public void Move()
    {
        var random = new Random();
        Position += Speed * random.Next(1, 4);
    }
}