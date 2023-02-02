
//Primitive Datentypen
int i = 0;
char c = 'c';
double d = 3.0d;
bool b = false;

//String ist ein Referenztyp lebt am Head und nicht am Stack!
string s = "test";

//Int Array mit vereinfachter Initializierung
int[] myInts = { 1, 2, 3, 4, 5 };

// 2 dimensionales Array symetrisch
int[,] array2 = new int[3, 3];

// 2 dimensionales Array asymetrisch
int[][] array = new int[6][];
array[0] = new int[8];
array[1] = new int[10];


if (b)
{
    var color = Console.BackgroundColor;
    Console.BackgroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("b = true");
    Console.BackgroundColor = color;
}
else
{
    Console.WriteLine("b != true");
}


// switch expression, für keine Statements aus sondern gibt einen Wert zurück
string colorStr = Console.BackgroundColor switch
{
    ConsoleColor.Red => "Red",
    _ => "unkown"
};

//Schleifen im Vergleich
while (true)
{
    Console.WriteLine("test");
    break;
}
for (int test = 0; test < myInts.Length; test++)
{
    Console.WriteLine(myInts[test]);
}

foreach (int item in myInts)
{
    //item = 0;
    Console.WriteLine(item);
}
