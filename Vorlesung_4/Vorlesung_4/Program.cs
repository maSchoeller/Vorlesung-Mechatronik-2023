﻿
using System.Collections;
int i = 13;

var intArray = new int[] { 1, 2, 3, 4, 5, };
IEnumerable list = new List<int>() { 1, 2, 3, 4, 5, };

//list.Add(9);
//list.Add(10);
var enumerator = list.GetEnumerator();
while (enumerator.MoveNext())
{
    var item = enumerator.Current;

    //Code ...
}


foreach (var item in list)
{

}




//Interfaces
//Stellen nur einen Vertrag dar, der sicherstellt das eine Methode oder ein Property vorhanden ist.

public interface IRunable
{
    void Run();
    bool CanRun();
}

public interface IEatable
{
    bool TryEat();
}


public abstract class Animal : IRunable, IEatable
{
    #region Sichtbarkeiten

    //Wiederholung wir haben 4 Verschiedene Sichtbarkeiten:
    // - private
    // - protected
    // - internal
    // - public
    // Jedes Feld, Property und Methode kann mit diesen Sichtbarkeiten gekapselt werden.
    // Merke: Es sollte immer die geringst mögliche Sichtbarkeit gewählt werden!
    // Merke: Wenn nichts angegeben ist die Methode, das Feld oder das Property private

    /// <summary>
    /// Niemand außer die Klasse selbst kann diese Methode aufrufen
    /// </summary>
    private bool _IsSick;

    public void SetSick(bool isSick)
    {
        _IsSick = isSick;
    }

    /// <summary>
    /// Gleich wie private kann die Methode/das Property nicht von "außen" aufgerufen werden,
    /// allerdings können die Erben das Property trotzdem aufrufen.
    /// </summary>
    public bool WantsToEat { get; protected set; }

    /// <summary>
    /// Die Mehtode hat die gleiche Sichtbarkeit wie public mit der Einschränkung,
    /// dass die Methode nur innerhalb des Projektes aufgerufen werden kann.
    /// </summary>
    public void Run()
    {
        if (CanRun())
        {
            WantsToEat = true;
            Console.WriteLine("Animal runs!!");
        }
        else
        {
            throw new InvalidOperationException("Animal can't run, try it later again...");
        }
    }


    #endregion

    #region Vererbung

    // Bei der Vererbung gibt es 3 Möglichkeiten
    // - new (überdecken)
    // - abstract (überschreiben erzwingen)
    // - virtual (überschreiben oder überdecken optional ermöglichen)


    // Was ist der Unterschied zwischen überschreiben und überdecken?
    // Überschreiben ermöglicht polymorphes Verhalten während überdecken dies verhindert.
    // Eine Methode ist polymorph, wenn sie in verschiedenen Klassen die gleiche Signatur hat, jedoch unertschiedliches Verhalten zeigt.
    // Überdecken ermöglicht kein polymorphes Verhalten.

    /// <summary>
    /// Jeder Kann diese Methode aufrufen, so lange er eine Instanz von Animal besitzt.
    /// </summary>
    /// <summary>
    /// Eine abstrakte Methode, sobald das Schlüsselwort abstract in der Klasse vorkommt,
    /// muss die Klasse auch als abstract definiert sein.
    /// </summary>
    public abstract bool TryEat();

    public virtual bool CanRun()
    {
        return !_IsSick;
    }
    public void Drink()
    {
        Console.WriteLine("The animal drinks");
    }
    #endregion
}

public class Bird : Animal
{

    //Bird erbt von Animal, besitzt also alle Eigenschaften die auch Animal besitzt.
    //Bird kann jetzt die Eigenschaften von Animal überdecken oder überschreiben.
    //Dafür muss es die Methoden oder Properties erneut definieren und mit new oder override kennzeichenen.

    //Merke: new ist best practice aber optional,
    //wenn eine Methode die geleiche Sigantur besitzt wie die Basisklasse
    //wird die Methode oder das Property automatisch übdeckt.


    public override bool TryEat()
    {
        if (WantsToEat)
        {
            Console.WriteLine("the bird eats, the food is so delicious");
            //Merke: Durch protected kann auch der Erbe das Property setzen.
            WantsToEat = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public new void Drink()
    {
        Console.WriteLine("Now the bird drinks");
    }
}

public class Dog : Animal
{
    public override bool TryEat()
    {
        Console.WriteLine("The dog is always hungry and ignores 'WantsToEat'");
        return true;
    }

    public bool IsInLove { get; set; }

    public override bool CanRun()
    {
        return base.CanRun() && !IsInLove;
    }
}
