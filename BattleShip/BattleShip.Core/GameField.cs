namespace BattleShip.Core;

public interface IReadOnlyGameField
{
    FieldType? FieldType { get; }
    bool IsShot { get; }
}

public class GameField : IReadOnlyGameField
{
    public FieldType FieldType { get; set; }

    FieldType? IReadOnlyGameField.FieldType
    {
        get
        {
            if (IsShot)
            {
                return FieldType;
            }
            return null;
        }
    }

    public bool IsShot { get; set; }
}



