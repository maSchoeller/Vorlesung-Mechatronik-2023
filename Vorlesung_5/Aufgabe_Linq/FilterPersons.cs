using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_Linq;

public static class FilterPersons
{

    static FilterPersons()
    {
        ////Auszug aus den Linq methoden
        var list = new List<Person>();

        //Castet alle Personen zu JumpingHero,
        //falls nicht alle JumpingHeros sind wird eine exception geworfen.
        //var listCast = list.Cast<JumpingHero>();

        ////Filtert die Liste nach einem Kriterium
        //var filteredPersons = list.Where(p => p.YearSalary == 1000);

        ////Gibt das Alter jeder Person zurück
        //var selectedPersons =  list.Select(p => p.Age);

        ////Ordnet die Personen aufsteigend nach dem gehalt
        //var orderdPersons = list.OrderBy(p => p.YearSalary);

        ////Gibt die ersten 5 Personen zurück
        //var takePersons = list.Take(5);

        ////Gibt jeder Person auser den ersten 3 zurück
        //var skipPersons = list.Skip(3);

        ////Gibt die erste Person zurück die gefunden wird. Wirft eine Exception falls sie nicht existiert.
        //var firstPerson = list.First();
    }


    /// <summary>
    /// Gib alle Personen zurück die einen Assistenten besitzen.
    /// </summary>
    public static IEnumerable<Person> Task1(IEnumerable<Person> person)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gib den Vornamen jeder Person zurück die ein Jahresgehalt über 50_000 besitzt.
    /// </summary>
    public static IEnumerable<string> Task2(IEnumerable<Person> persons)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gib die letzten Helden in der Liste zurück der vom Typ Technologie ist.
    /// </summary>
    public static Hero Task3(IEnumerable<Person> persons)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gib den ersten Hero zurück der einen Assitenten besitzt der kein Held ist.
    /// </summary>
    public static Hero Task4(IEnumerable<Person> persons)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gib die Anzahl aller JumpingHeros in der Liste zurück
    /// </summary>
    public static int Task5(IEnumerable<Person> persons)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Berechne das Jahresdurchschnittsgehalt aller Personen
    /// </summary>
    public static int Task6(IEnumerable<Person> persons)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Berechne das Jahresdurchschnittsgehalt aller Helden die nicht Fliegen können.
    /// </summary>
    public static int Task7(IEnumerable<Person> persons)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gib alle JumpingHeros in der Liste zurück, die weiter als der Durchschnitt aller jumpingHeros springen können.
    /// </summary>
    public static IEnumerable<JumpingHero> Task8(IEnumerable<Person> persons)
    {
        throw new NotImplementedException();
    }


}
