using Godot;
using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

public partial class Skull : Area2D
{
        [Export]
        public float SpeedDown = 30.0f;
        [Export]
        public float Frequency = 2.0f;
        [Export]
        public float Amplitude = 50.0f;
        
        private float _timePassed =0.0f;

        private float _startX = 0.0f;
        private readonly PackedScene _enemyProjectile = GD.Load<PackedScene>("res://scenes/enemy_bullet.tscn");
        private Timer _shootTimer;

//inital position and setup timer to shoot bulelts
    public override void _Ready()
    {
        _startX = Position.X;
        _shootTimer = GetNode<Timer>("Timer");
        _shootTimer.Timeout += OnTimerTimeout;
    }
//shooting bullets
    private void OnTimerTimeout()
    {
        Node2D newBullet = _enemyProjectile.Instantiate<Node2D>();
        newBullet.GlobalPosition = this.GlobalPosition;
        AddSibling(newBullet);

        if (_shootTimer.WaitTime > 0.5)
        {
            _shootTimer.WaitTime -= 0.001;
        }
    }
//movement
    public override void _Process(double delta)
    {
       float fDelta = (float)delta;
       _timePassed += fDelta;
       Vector2 newPosition = Position;
       newPosition.Y += SpeedDown *fDelta;
       newPosition.X = _startX + (Mathf.Sin(_timePassed * Frequency) * Amplitude);
       Position = newPosition;
//apaga a caveira dps q ela sai da tela
        if( Position.Y >=750)
        {
            QueueFree();
        }
    }
//enemy dies when hit by spell
    private void OnAreaEntered(Area2D area)
    {
        if(area.IsInGroup("PlayerProjectile"))
        {
            area.QueueFree();
            QueueFree();
            if(GetTree().CurrentScene is World worldScript)
            {
                worldScript.AddScore(100);
            }
        }
    }
}
