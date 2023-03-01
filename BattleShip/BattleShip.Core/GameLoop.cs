namespace BattleShip.Core;

public class GameLoop
{
    private GameBoard _GameBoard;
    private Player _Player;

    public void Start(Player player, int[] ships)
    {
        _Player = player;
        _GameBoard = new GameBoard();
        GameBoardFiller.FillGameBoard(_GameBoard, ships);
    }


    public IReadOnlyGameBoard GameBoard
    {
        get
        {
            return _GameBoard;
        }
    }

    public bool PlayRound()
    {
        if (IsGameFinsihed())
        {
            return true;
        }

        var shoot = _Player.ShootRound(_GameBoard);
        _GameBoard[shoot.X, shoot.Y].IsShot = true;

        return IsGameFinsihed();
    }

    private bool IsGameFinsihed()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                var field = _GameBoard[x, y];
                if (field.FieldType is FieldType.Ship && !field.IsShot)
                {
                    return false;
                }
            }
        }

        return true;
    }

}
