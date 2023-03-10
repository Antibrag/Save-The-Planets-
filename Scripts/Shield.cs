using Godot;
using System;

public class Shield : Node2D
{
    [Export]
    public float rotationForce;

    public override void _Ready()
    {
        GetNode<Sprite>("Shield/ShieldSprite").FlipH = true;
        base._Ready();
    }

    public override void _Process(float delta)
    {
        ResizeShield();
        GetNode<Area2D>("Shield").LookAt(GetNode<Node2D>(".").Position);
        Movement(delta);
        base._Process(delta);
    }

    public void OnShieldBodyEntered(Danger body)
    {
        body.Destroy();
        Data.money++;
    }

    private void Movement(float delta)
    {
        if (Input.IsActionPressed("ui_down")) GetNode<Node2D>(".").RotationDegrees += rotationForce * delta;
        if (Input.IsActionPressed("ui_up")) GetNode<Node2D>(".").RotationDegrees -= rotationForce * delta;
    }

    public void ResizeShield()
    {
        Vector2 sizeScreen = GetViewportRect().Size;
        Position = sizeScreen / 2;
    }

}
