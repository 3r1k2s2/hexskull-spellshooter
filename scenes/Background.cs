using Godot;
using System;

public partial class Background : Node2D
{
    public override void _Process(double delta)
    {
        Translate(Vector2.Down *30 *(float)delta);
    }

}
