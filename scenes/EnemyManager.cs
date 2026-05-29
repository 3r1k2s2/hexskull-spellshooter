using Godot;
using System;

public partial class EnemyManager : Node2D
{
    [Export]
    private PackedScene EnemyScene;

    private Timer _spawnTimer;
    private Random _random = new Random();

    public override void _Ready()
    {
        _spawnTimer = GetNode<Timer>("Timer");

        _spawnTimer.Timeout += OnTimerTimeout;

    }

    private void OnTimerTimeout()
    {
        Node2D enemyInstance = EnemyScene.Instantiate<Node2D>();

        float randomX = _random.Next(30,370);

        enemyInstance.Position = new Vector2(randomX, -50.0f);
        AddChild(enemyInstance);

        if (_spawnTimer.WaitTime > 0.5)
        {
            _spawnTimer.WaitTime -= 0.025;
        }
    }
}
