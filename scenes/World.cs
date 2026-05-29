using Godot;
using System;

public partial class World : Node2D
{

    private int _score = 0;
    private Label _scoreLabel;
// o score inicial eh 0
    public override void _Ready()
    {
        _scoreLabel = GetNode<Label>("CanvasLayer/ScoreLabel");
        UpdateScore();
    }

    public void AddScore(int points)
    {
        _score +=points ;
        UpdateScore();

    }
    private void UpdateScore()
    {
        if (_scoreLabel != null)
        {
            _scoreLabel.Text = $"pts: {_score}";
        }
    }
}
