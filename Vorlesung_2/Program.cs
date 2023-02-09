
//MyFirstClass Sample
MyFristClass class1 = new MyFristClass();
class1.MyFirstInteger = 10;
System.Console.WriteLine(class1.MyFirstInteger);

//TcpOption Sample
var options = new TcpOption()
{
    IpAdress = "10.10.0.1",
};
options.Port = 80;
System.Console.WriteLine(options.IpAdressAndPort);

//Static Sample
MyFirstStaticClass.SetMyMessage(" Marvin");
MyFirstStaticClass.WriteOnConsole("Hello World");

Console.ReadKey();



//Das ist eine statische Klasse es kann keine Instanz dieser Klasse erzeugt werden!
//Grund dafür ist das static Schlüsselwort
//      ||
//      \/
public static class MyFirstStaticClass
{

    //Note: Schlechter Code der zu Seiteneffekten führen kann, weil jeder SetMyMessage aufrufen kann.
    //      Besser eine Version der Klasse ohne static erstellen und eine Instanz dieser Klasse erzeugen.
    //      Nur wer die Instanz kennt kann jetzt SetMyMessage aufrufen.

    private static string _MyMessage = "Test";

    public static void SetMyMessage(string message)
    {
        _MyMessage = message;
    }

    public static void WriteOnConsole(string message)
    {
        Console.WriteLine(message + _MyMessage);
    }

}

public class MyFristClass
{
    private int _MyFirstInteger;

    public int MyFirstInteger
    {
        get => _MyFirstInteger;
        set
        {
            if (value != 10)
            {
                _MyFirstInteger = value;
            }
        }
        //Auch möglich falls der Wert gesetzt werden soll..
        //set => _MyFirstInteger = value;
    }

    public string MyString3
    {
        get
        {
            return nameof(MyFristClass.MyString3);
        }
    }
    //Auch möglich als Einzeiler.
    //public string MyString3 => nameof(MyFristClass.MyString3);
}

class TcpOption
{
    public string IpAdress { get; set; }
    public int Port { get; set; }
    public string IpAdressAndPort => $"{IpAdress}:{Port}"; //IpAdress + ":" + Port

    //Alternativ nicht über ein Property sondern über eine Methode.
    public string GetIpAdressAndPort()
    {
        //Anstatt dem string Format mit $"{..}" kann der String auch einfach konkateniert werden.
        return IpAdress + ":" + Port;
    }
}