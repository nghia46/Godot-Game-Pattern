using Godot;
using static ScoreManager;

public partial class UIController : Node
{
	[Export] private Button IncrementButton;
	[Export] private Button DecrementButton;
	[Export] private Button BonusButton;
	[Export] private Button PenaltyButton;

	public override void _Ready()
	{
		IncrementButton.Connect("pressed", new Callable(this, nameof(OnIncrementButtonPressed)));
		DecrementButton.Connect("pressed", new Callable(this, nameof(OnDecrementButtonPressed)));
		BonusButton.Connect("pressed", new Callable(this, nameof(OnBonusButtonPressed)));
		PenaltyButton.Connect("pressed", new Callable(this, nameof(OnPenaltyButtonPressed)));
	}

	private void OnIncrementButtonPressed()
	{
		EventManager.Instance.StartScoreChangedEvent(ScoreTriggerType.Increment, 2);
	}
	private void OnDecrementButtonPressed()
	{
		EventManager.Instance.StartScoreChangedEvent(ScoreTriggerType.Decrement, 2);
	}
	private void OnBonusButtonPressed()
	{
		EventManager.Instance.StartScoreChangedEvent(ScoreTriggerType.Bonus, 2);
	}
	private void OnPenaltyButtonPressed()
	{
		EventManager.Instance.StartScoreChangedEvent(ScoreTriggerType.Penalty, 2);
	}
}
