

//Was ist ein Interface?
using System.Collections;

var intArray = new List<int> { 1, 2, 3 };
IEnumerable enumerable = null;
foreach (var item in enumerable)
{

}


//Interface vs. Abstracte Klasse?
//Was ist der Unterschied?


//SOLID
//- Single Responsabiliy
//- Open-Close
//- Liskov Substitution
//- Interface Segregation

public abstract class EnumerableBase
{
   public abstract IEnumerator GetEnumerator();
} 
