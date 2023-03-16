using System;

namespace BattleShip.Core
{
    public class Player
    {
        private readonly Random _Random = new Random();

        public Shoot ShootRound(IReadOnlyGameBoard board)
        {
            while (true)
            {
                var x = _Random.Next(0, 10);
                var y = _Random.Next(0, 10);

                if (!board[x, y].IsShot)
                {
                    return new Shoot(x, y);
                }
            }
        }
    }
}