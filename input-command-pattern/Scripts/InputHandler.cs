using System.Collections.Generic;
using Godot;

public partial class InputHandler : Node2D
{
	private Dictionary<string, ICommand> commandMap;
	private Player player;

	// Parameterless constructor
	public InputHandler()
	{
		commandMap = new Dictionary<string, ICommand>();
	}

	// Initialization method to set up the Player instance and commands
	public void Initialize(Player player)
	{
		this.player = player;
		
		// Initialize command mappings
		commandMap = new Dictionary<string, ICommand>
		{
			{ "ui_left", new MoveLeftCommand(player) },
			{ "ui_right", new MoveRightCommand(player) }
		};
	}
    // Method to handle input and execute the corresponding command
	public void HandleInput()
	{
		if (Input.IsActionJustPressed("ui_left"))
		{
			commandMap["ui_left"].Execute();
		}
		else if (Input.IsActionJustPressed("ui_right"))
		{
			commandMap["ui_right"].Execute();
		}
	}
}
