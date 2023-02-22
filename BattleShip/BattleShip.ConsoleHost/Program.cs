using BattleShip.Core;


namespace BattleShip.ConsoleHost;

internal class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        GameBoard board = new GameBoard();
        GameBoardFiller.FillGameBoard(board, new[] { 3, 4, 5, 2, 3, 2, 4, 6 });
        int counter = 0;
        while (!IsGameBoardFinished(board))
        {
            Shoot shoot = player.ShootRound(board);
            var readOnlyField = board[shoot.X, shoot.Y];
            GameField field = readOnlyField as GameField;
            field.IsShot = true;
            counter++;
        }
        Console.WriteLine(counter);
        PrintGameBoard(board);
        Console.WriteLine();
    }

    private static bool IsGameBoardFinished(GameBoard board)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                var field = board[x, y] as GameField;
                if (field.FieldType is FieldType.Ship && !field.IsShot)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private static void PrintGameBoard(GameBoard board)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                //Es wird ein ValueTuple erstellt, das wir über die switch expression auswerden
                (FieldType? FieldType, bool IsShot) fieldTuple = (board[x, y].FieldType, board[x, y].IsShot);
                Console.Write(fieldTuple switch
                {
                    (null, false) => " ~",
                    (FieldType.Water, false) => " ~",
                    (FieldType.Water, true) => " *",
                    (FieldType.Ship, false) => " s",
                    (FieldType.Ship, true) => " x",
                    _ => throw new InvalidOperationException()
                });


                //Alternativ ohne das ein Tuple erstellt wird, hier sogar etwas aussagekräftiger

                //Console.Write(board[x, y] switch
                //{
                //    { FieldType: FieldType.Water, IsShot: false } => " ~",
                //    { FieldType: FieldType.Water, IsShot: true } => " *",
                //    { FieldType: FieldType.Ship, IsShot: false } => " s",
                //    { FieldType: FieldType.Ship, IsShot: true } => " x",
                //    _ => throw new InvalidOperationException()
                //});
            }
            Console.WriteLine();
        }
    }

}
