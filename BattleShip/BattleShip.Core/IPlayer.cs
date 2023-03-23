namespace BattleShip.Core
{
    public interface IPlayer
    {
        Shoot ShootRound(IReadOnlyGameBoard board);
    }
}