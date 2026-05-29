using Godot;
using System;

using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;



public partial class Player : Area2D
{
	[Export]
    public float Speed = 150.0f;
    public int MaxHealth = 3;
    private int CurrentHealth;
    private ProgressBar _HealthBar;
    private readonly PackedScene _projectileScene = GD.Load<PackedScene>("res://scenes/projectile.tscn");

    public override void _Ready()
    {
        _HealthBar = GetNode<ProgressBar>("CanvasLayer/ProgressBar");
        CurrentHealth = MaxHealth;

        _HealthBar.MaxValue = MaxHealth;
        _HealthBar.Value = CurrentHealth;
    }


    public override void _Process(double delta)
    {
        Vector2 move = Input.GetVector("left","right","up","down");
        if (move != Vector2.Zero)
        {
            Position += move * Speed *(float)delta;
        } 
        


        if (Input.IsActionJustPressed("shoot"))
        {
            Node2D newProjectile = _projectileScene.Instantiate<Node2D>();
            
            newProjectile.GlobalPosition = this.GlobalPosition;

            AddSibling(newProjectile);
        }

    }
//takes damage
    public void TakeDamage()
    {
        CurrentHealth--;
        CurrentHealth = Mathf.Max(CurrentHealth, 0);
        _HealthBar.Value = CurrentHealth;
        if( CurrentHealth <=0)
            {
                QueueFree();
            }
    }
    private void OnAreaEntered2(Area2D area)
    {
        if(area.IsInGroup("Enemy"))
        {
            area.QueueFree();
            TakeDamage();
            
        }
    }
}
