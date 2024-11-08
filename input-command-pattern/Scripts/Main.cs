// Main.cs
using Godot;

public partial class Main : Node2D
{
    private Player player;
    private InputHandler inputHandler;

    public override void _Ready()
    {
        player = GetNode<Player>("/root/Main/Player");
        inputHandler = new InputHandler();
        inputHandler.Initialize(player);
    }

    public override void _Process(double delta)
    {
        inputHandler.HandleInput();
    }
}
