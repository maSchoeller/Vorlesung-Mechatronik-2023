//Generics
//Was wäre wenn wir einen DatenTyp als Variable beschreiben könnten?
//List<T> --> wie ein Array nur flexibler
//Dictionary<TKey,TValue>
//Stack<T>
//Queue<T>


//Erste eigene generische Klasse...


//Delegates
//Was wäre wenn wir eine Funktion als Variable beschreiben könnten?
//var i = new int[] { 1, 2 };
//var l = new List<int>();

//var dic = new Dictionary<string, Animal>();
//var animal = new Animal();

//dic.Add("Cat", animal);

//if (dic.ContainsKey("Cat"))
//{
//    Animal animal2 = dic["Cat"];

//}


//var c = new MyFristGenericClass<int>();
////c.SetValue("t");
//var c2 = new MyFristGenericClass<string>();
//c2.SetValue("t");

//public class Animal : IComparable
//{
//    public int CompareTo(object? obj)
//    {

//        //...
//        return 0;
//    }
//}


//public class MyFristGenericClass<TValue> where TValue : IComparable
//{
//    private TValue _Value;


//    public void SetValue(TValue value)
//    {
//        if (value.CompareTo(_Value) > 0)
//        {
//            _Value = value;
//        }
//    }

//    public TValue GetValue()
//    {
//        return _Value;
//    }
//}



#region later
IEnumerable<Person> data = GetPersons();

Console.WriteLine(data.Count());

var filterPersons = Filter(data, p => p is Hero);

Console.WriteLine(filterPersons.Count());

bool FilterIfDoe(Person person)
{
    return person is Hero;
}

IEnumerable<T> Filter<T>(IEnumerable<T> persons, Func<T, bool> filter)
{
    var herolist = new List<T>();
    foreach (var person in persons)
    {
        if (filter(person))
        {
            herolist.Add(person);
        }
    }


    return herolist;
}






IEnumerable<Person> GetPersons()
{
    yield return new Person("John", "Doe", 40_000, 20);
    yield return new Person("Margret", "Doe", 10_000, 25,
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


public enum HeroType
{
    NuclearAccident,
    FailedExperiment,
    Alien,
    Mutant,
    Technology,
    Other
};


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

//var call = TestMethode;

////call = TestMethode2;

//call("Message");



//void TestMethode(string message)
//{
//    Console.WriteLine(message);
//}


//void TestMethode2()
//{
//    Console.WriteLine("Hello World2");
//}


//var methode = MyTestMethode;
//methode(10);

////Action<T>
////Func<TArg, TResult>


////Delegate schreibweise
////Lambda funktionen
////Mit und ohne geschwiffenen Klammern

////Linq einführung


//void MyTestMethode(int argument)
//{
//    Console.WriteLine(argument);
//}
#endregion