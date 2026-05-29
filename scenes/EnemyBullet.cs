using Godot;
using System;

public partial class EnemyBullet : Area2D
{
    public float Speed = 300.0f;

    public override void _Process(double delta)
    {

        Translate(Vector2.Down * Speed * (float)delta);
        
    }

}
