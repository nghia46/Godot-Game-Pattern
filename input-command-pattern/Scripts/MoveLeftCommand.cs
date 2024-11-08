public class MoveLeftCommand : ICommand
{
    private Player player;

    public MoveLeftCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.MoveLeft();
    }
}
