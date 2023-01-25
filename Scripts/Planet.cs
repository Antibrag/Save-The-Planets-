using Godot;
using System;

public class Planet : Sprite
{
    [Export]
    public float planetRotationSpeed = 100;

    RandomNumberGenerator rnd = new RandomNumberGenerator();

    public override void _Process(float delta)
    {
        GetNode<Sprite>(".").RotationDegrees += planetRotationSpeed * delta;
        base._Process(delta);
    }

    public void GeneratePlanet()
    {
        rnd.Randomize();
        Vector2 textureLocation = new Vector2(rnd.RandiRange(0, 3) * 32, rnd.RandiRange(0, 3) * 32);
        GetNode<Sprite>(".").RegionRect = new Rect2(textureLocation, new Vector2(32, 32));
    }
}