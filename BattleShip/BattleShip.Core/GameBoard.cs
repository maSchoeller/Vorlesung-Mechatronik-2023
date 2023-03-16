namespace BattleShip.Core
{
    public interface IReadOnlyGameBoard
    {
        IReadOnlyGameField this[int x, int y] { get; }

    }
    public class GameBoard : IReadOnlyGameBoard
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

        IReadOnlyGameField IReadOnlyGameBoard.this[int x, int y] => _Field[x, y];
    }
}