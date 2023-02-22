namespace BattleShip.Core;

public class ReadOnlyGameField
{
    protected FieldType _FieldType;
    public FieldType? FieldType
    {
        get
        {
            if (IsShot)
            {
                return _FieldType;
            }
            else
            {
                return null;
            }
        }
    }

    public bool IsShot { get; protected set; }
}




public class GameField : ReadOnlyGameField
{

    public new FieldType FieldType
    {
        get
        {
            return _FieldType;
        }
        set
        {
            _FieldType = value;
        }
    }

    public new bool IsShot
    {
        get
        {
            return base.IsShot;
        }
        set
        {
            base.IsShot = value;
        }
    }

    //public void SetFieldType(FieldType fieldType)
    //{
    //    FieldType = fieldType;
    //}

    //public void SetIsShot(bool isShot)
    //{
    //    IsShot = isShot;
    //}
}



