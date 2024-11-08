public class MoveRightCommand : ICommand
{
    private Player player;

    public MoveRightCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.MoveRight();
    }
}
