using Godot;

public partial class ScoreManager : Node
{
    [Export] private Label ScoreLabel { get; set; }
    private int score = 0;

    public enum ScoreTriggerType
    {
        Increment,
        Decrement,
        Bonus,
        Penalty
    }

    public override void _Ready()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnScoreChanged += UpdateScore;
        }

        ScoreLabel.Text = score.ToString();
    }

    private void UpdateScore(ScoreTriggerType scoreTriggerType, int scoreChange)
    {
        // Update score based on trigger type
        switch (scoreTriggerType)
        {
            case ScoreTriggerType.Increment:
                score += scoreChange;
                break;
            case ScoreTriggerType.Decrement:
                score -= scoreChange;
                break;
            case ScoreTriggerType.Bonus:
                score += scoreChange * 2;
                break;
            case ScoreTriggerType.Penalty:
                score -= scoreChange * 2;
                break;
            default:
                GD.Print("Invalid Score Trigger Type");
                break;
        }

        // Ensure score doesn't go below zero
        if (score < 0) score = 0;

        // Update the label only when score changes
        ScoreLabel.Text = score.ToString();

        // Check if score has reached a threshold
        CheckScoreThreshold();
    }

    private void CheckScoreThreshold()
    {
        if (score >= 100)
        {
            GD.Print("Reached 100 points");
        }
    }

    public override void _ExitTree()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnScoreChanged -= UpdateScore;
        }
    }
}
