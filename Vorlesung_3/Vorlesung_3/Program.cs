
//Merke in dem Array, das wir definiert haben, sind nur Referenzen auf Animals.
//Obwohl sich hinter den Animals Birds und Cats befinden..
AnimalsRuns(new Animal[]
{
    new Bird(),
    new Bird(),
    new Cat(),
});


void AnimalsRuns(Animal[] animals)
{
    foreach (var animal in animals)
    {
        //Um das Runs von Bird aufrufen zu können müssen wir erst aus dem Animal ein Bird machen.
        if (animal is Bird bird)
        {
            bird.Run();
        }
        else
        {
            
            animal.Run();
        }
    }
}
public abstract class Animal
{
    public abstract double NumbersOfEars { get; }

    //Eine virtuelle Methode die dem Entwickler ermöglicht
    //durch Vererben die funktionalität zu überschreiben.
    public virtual void Run()
    {
        Console.WriteLine("Animal runs");
    }
}

public class Bird : Animal
{
    public override double NumbersOfEars => 0;

    //Das ist eine überdeckung mit new,
    //diese Methode wird nur aufgerufen,
    //wenn die eine Referenz auf Bird vorhanden ist.
    public new void Run()
    {
        Console.WriteLine("Bird runs");
    }
}

public class Cat : Animal
{
    public override double NumbersOfEars => 2;
    public void Miau()
    {
        Console.WriteLine("Miau");
    }

    public override void Run()
    {
        Console.WriteLine("Cat runs");
    }
}

/*
   Multi line Comment
*/
//TestClass newClass = new TestClass(10, string.Empty);
//TestClass2 testClass2 = new TestClass2(11, "ABC");

//Console.WriteLine(testClass2);
//var myNewTestClass3 = testClass2 with { TestString = "ABe"};
//Console.WriteLine(myNewTestClass3);


//Die beiden Klassen sind nahezu gleich implementiert.
//Mit Records können Datenklassen einfach ohen viel Code erstellt werden.

public record RecordClass(int Test, string TestString);

public class ClassicClass
{
    public ClassicClass(int test, string testString)
    {
        Test = test;
        TestString = testString;
    }


    public int Test { get; }

    public string TestString { get; }
}