namespace Aufgabe_Linq;


public static class HeroDummyData
{

    public static IEnumerable<Person> GetPersons()
    {
        yield return new Person("John", "Doe", 40_000, 20);
        yield return new Person("Marget", "Doe", 10_000, 25,
            new Person("Susi", "Mc Miller", 70_000));
        yield return new Hero("Tony", "Stark", "Ironman", HeroType.Technology, true, 10_000_000,
            new Hero("James", "Rhodes", "Warmachine", HeroType.Technology, true, 120_000));

        yield return new Hero("Bruce", "Wayne", "Batman", HeroType.Technology, false, 300_000,
            new Person("Alfred", "Pennyworth", 60_000));
        yield return new Hero("Wade", "Wilson", "Deadpool", HeroType.FailedExperiment, false, 0);
        yield return new Hero("Carl", "Lucas", "Luke Cage", HeroType.FailedExperiment, false, 15_000);
        yield return new Hero("Danny", "Rand", "Iron Fist", HeroType.Other, false, 0);
        yield return new JumpingHero("Superman", double.MaxValue, 0);
        yield return new JumpingHero("Mike Powell", 8.95, 200_000, 60);
        yield return new JumpingHero("Heike Gabriela Drechsler", 7.63, 150_000, 59);
        
    }
}


public enum HeroType { NuclearAccident, FailedExperiment, Alien, Mutant, Technology, Other };

public record Person(string FirstName,
    string LastName,
    int YearSalary,
    int? Age = null,
    Person? Assistant = null);

public record Hero(string FirstName,
    string LastName,
    string HeroName,
    HeroType Type,
    bool CanFly,
    int YearSalary,
    Person? Assistant = null) : Person(FirstName, LastName, YearSalary, Assistant: Assistant);

public record JumpingHero(string Name, double MaxJumpDistance, int YearSalary, int? Age = null)
    : Person(Name, "JumpingHero", YearSalary, Age);
