using BattleShip.Core;


namespace BattleShip.ConsoleHost;

internal class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();
        GameLoop gameLoop = new GameLoop();
        gameLoop.Start(player, new[] { 3, 3, 2, 2, 4,4,2,1,1 });

        PrintGameBoard(gameLoop.GameBoard as GameBoard);
        int counter = 0;
        while (!gameLoop.PlayRound())
        {
            counter++;
        }
        Console.WriteLine(counter);
        PrintGameBoard(gameLoop.GameBoard);
        Console.WriteLine();
    }

    private static void PrintGameBoard(IReadOnlyGameBoard board)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Console.Write(board[x, y] switch
                {
                    { FieldType: null } => " ~",
                    { FieldType: FieldType.Water, IsShot: false } => " ~",
                    { FieldType: FieldType.Water, IsShot: true } => " *",
                    { FieldType: FieldType.Ship, IsShot: false } => " s",
                    { FieldType: FieldType.Ship, IsShot: true } => " x",
                    _ => throw new InvalidOperationException()
                });
            }
            Console.WriteLine();
        }

    }

    private static void PrintGameBoard(GameBoard board)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Console.Write(board[x, y] switch
                {
                    { FieldType: FieldType.Water, IsShot: false } => " ~",
                    { FieldType: FieldType.Water, IsShot: true } => " *",
                    { FieldType: FieldType.Ship, IsShot: false } => " s",
                    { FieldType: FieldType.Ship, IsShot: true } => " x",
                    _ => throw new InvalidOperationException()
                });
            }
            Console.WriteLine();
        }
    }

}
