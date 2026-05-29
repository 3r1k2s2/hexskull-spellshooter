using Godot;
using System;


public partial class Projectile : Area2D
{
    
    public float Speed = 320.0f;

    public override void _Process(double delta)
    {

        Translate(Vector2.Up * Speed * (float)delta);
        
    }
}
