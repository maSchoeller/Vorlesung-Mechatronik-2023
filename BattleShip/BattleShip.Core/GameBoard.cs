namespace BattleShip.Core;

public class GameBoard
{
    private GameField[,] _Field;

    public GameBoard()
    {
        _Field = new GameField[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int ii = 0; ii < 10; ii++)
            {
                _Field[i, ii] = new GameField();
            }
        }
    }

    public GameField this[int x, int y] => _Field[x, y];

}
