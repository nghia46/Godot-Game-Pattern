using System;
using Godot;
using static ScoreManager;

public partial class EventManager : Node
{
	public static EventManager Instance { get; private set; }
	// Events
	public event Action<ScoreTriggerType, int> OnScoreChanged;

	public override void _Ready()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			//Destroy the new instance
			QueueFree();
		}
	}
	public void StartScoreChangedEvent(ScoreTriggerType triggerType, int scoreChange)
	{
		OnScoreChanged?.Invoke(triggerType, scoreChange);
	}
}
