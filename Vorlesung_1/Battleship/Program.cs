
for (int i = 0; i < 20; i++)
{
    var board = new char[][]
    {
    "~~~~~~~~~~".ToCharArray(),
    "~~~~~~O~~~".ToCharArray(),
    "~OO~~~O~~~".ToCharArray(),
    "~~~~~~O~~~".ToCharArray(),
    "~~~~~~~~O~".ToCharArray(),
    "~~~~~~~~O~".ToCharArray(),
    "~OOOO~~~~~".ToCharArray(),
    "~~~~~~~~~~".ToCharArray(),
    "~~~~OOO~~~".ToCharArray(),
    "~~~~~~~~~~".ToCharArray(),
    };

    int fieldCount = 14;
    int counter = 0;
    while (fieldCount != 0)
    {
        ShootOnBoard();
        //PrintFieldToConsole();
        counter++;
    }
    Console.WriteLine("Counter: " + counter);
    void ShootOnBoard()
    {
        var rnd = new Random();

        var y = rnd.Next(0, 10);
        var x = rnd.Next(0, 10);
        while (board[y][x] is 'X' or '*')
        {
            y = rnd.Next(0, 10);
            x = rnd.Next(0, 10);
        }
        if (board[y][x] is 'O')
        {
            fieldCount--;

            board[y][x] = 'X';
        }
        else
        {
            board[y][x] = '*';
        }
    }

    void PrintFieldToConsole()
    {
        Console.WriteLine();

        foreach (var line in board)
        {
            foreach (var field in line)
            {
                Console.Write(field + " ");
            }
            Console.WriteLine();
        }
    }
}

