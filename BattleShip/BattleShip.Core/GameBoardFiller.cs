using System;

namespace BattleShip.Core
{
    public static class GameBoardFiller
    {
        public static void FillGameBoard(GameBoard board, int[] ships)
        {
            //NOTE: Die Schiffe werden absteigend sortiert, dadurch ist der Algorithmus stabiler.
            //      Da die kleinsten Schiffe zum Schluss gesetzt werden
            //ships = ships.OrderByDescending(s => s).ToArray();


            int xLength, yLength, xStart, xEnd, yStart, yEnd;
            Random rnd = new Random();
            foreach (int shipLength in ships)
            {
                int calcCounter = 0;
                bool isHorizontal;
                do
                {
                    if (calcCounter > 300)
                    {
                        throw new InvalidOperationException("Unable to generate GameField, try again...");
                    }
                    calcCounter++;

                    //Zufällig bestimmen ob das Schiff horizontal oder vertikal gesetzt wird.
                    isHorizontal = rnd.Next(0, 2) % 2 == 1;

                    xLength = rnd.Next(0, isHorizontal ? 10 - shipLength : 10);
                    yLength = rnd.Next(0, !isHorizontal ? 10 - shipLength : 10);

                    //Zwei Punkte generieren in denen die Fläche frei sein muss,
                    //diese dürfen nicht außerhalb des Feldes sein.
                    xStart = (xLength == 0) ? xLength : xLength - 1;
                    yStart = (yLength == 0) ? yLength : yLength - 1;



                    if (isHorizontal)
                    {
                        xEnd = (xLength + shipLength == 10) ? xLength + shipLength - 1 : xLength + shipLength;
                        yEnd = (yLength == 9) ? yLength : yLength + 1;
                    }
                    else
                    {
                        xEnd = (xLength == 9) ? xLength : xLength + 1;
                        yEnd = (yLength + shipLength == 10) ? yLength + shipLength - 1 : yLength + shipLength;
                    }
                } while (!AreFieldsFreeForPlaceShip(board, xStart, yStart, xEnd, yEnd));



                //Es wurde eine freie Feldreihe gefunden.
                //Felder mit dem Schiff füllen.
                if (isHorizontal)
                {
                    for (int xOffset = 0; xOffset < shipLength; xOffset++)
                    {
                        if (board[xLength + xOffset, yLength] is GameField field)
                        {
                            field.FieldType = FieldType.Ship;
                        }

                    }
                }
                else
                {
                    for (int yOffset = 0; yOffset < shipLength; yOffset++)
                    {
                        if (board[xLength, yLength + yOffset] is GameField field)
                        {
                            field.FieldType = FieldType.Ship;
                        }
                    }
                }
            }
        }

        private static bool AreFieldsFreeForPlaceShip(GameBoard board, int xStart, int yStart, int xEnd, int yEnd)
        {
            for (int x = xStart; x <= xEnd; x++)
            {
                for (int y = yStart; y <= yEnd; y++)
                {
                    if (board[x, y].FieldType == FieldType.Ship)
                        return false;
                }
            }
            return true;
        }
    }
}