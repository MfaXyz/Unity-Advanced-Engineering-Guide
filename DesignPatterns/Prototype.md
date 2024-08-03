# Prototype Design Pattern

Intent: `The prototype pattern is a creational design pattern in software development. It is used when the types of objects to create is determined by a prototypical instance, which is cloned to produce new objects. This pattern is used to avoid subclasses of an object creator in the client application, like the factory method pattern does, and to avoid the inherent cost of creating a new object in the standard way (e.g., using the 'new' keyword) when it is prohibitively expensive for a given application.`

Overview:

The Prototype pattern delegates the cloning process to the actual objects that are being cloned. The pattern declares a common interface for all objects that support cloning. This interface lets you clone an object without coupling your code to the class of that object. Usually, such an interface contains just a single clone method.

The implementation of the clone method is very similar in all classes. The method creates an object of the current class and carries over all of the field values of the old object into the new one. You can even copy private fields because most programming languages let objects access private fields of other objects that belong to the same class.

An object that supports cloning is called a prototype. When your objects have dozens of fields and hundreds of possible configurations, cloning them might serve as an alternative to subclassing.

Here’s how it works: you create a set of objects, configured in various ways. When you need an object like the one you’ve configured, you just clone a prototype instead of constructing a new object from scratch.

> [!NOTE]
> Use the Prototype pattern when your code shouldn’t depend on the concrete classes of objects that you need to copy.

> [!NOTE]
> Use the pattern when you want to reduce the number of subclasses that only differ in the way they initialize their respective objects.

# Examples:

## Example 1:

### Person.cs
```C#
using System;
using UnityEngine;

namespace Prototype
{
    public class Person : MonoBehaviour
    {
        public int age;
        public DateTime BirthDate;
        public new string name;
        public IdInfo IDInfo;

        public Person ShallowCopy()
        {
            return (Person)MemberwiseClone();
        }

        public Person DeepCopy()
        {
            var clone = (Person)MemberwiseClone();
            clone.IDInfo = new IdInfo(IDInfo.IDNumber);
            clone.name = string.Copy(name);
            return clone;
        }
    }
}
```

### IdInfo.cs
```C#
namespace Prototype
{
    public class IdInfo
    {
        public readonly int IDNumber;

        public IdInfo(int idNumber)
        {
            IDNumber = idNumber;
        }
    }
}
```

### PrototypeProgram.cs
```C#
using System;
using UnityEngine;

namespace Prototype
{
    public class PrototypeProgram : MonoBehaviour
    {
        private void Start()
        {
            var p1 = gameObject.AddComponent<Person>();
            p1.age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.name = "Mfa Xyz";
            p1.IDInfo = new IdInfo(666);
            
            // Perform a shallow copy of p1 and assign it to p2.
            var p2 = p1.ShallowCopy();
            // Make a deep copy of p1 and assign it to p3.
            var p3 = p1.DeepCopy();
            
            // Display values of p1, p2 and p3.
            Debug.Log("Original values of p1, p2, p3:");
            Debug.Log(" p1 instance values: ");
            DisplayValues(p1);
            Debug.Log(" p2 instance values: ");
            DisplayValues(p2);
            Debug.Log(" p3 instance values: ");
            DisplayValues(p3);
        }

        private static void DisplayValues(Person p)
        { 
            Debug.Log(p.name + p.age + p.BirthDate);
            Debug.Log(p.IDInfo.IDNumber);
        }
    }
}
```

# References:

[Prototype Pattern in Wikipedia](https://en.wikipedia.org/wiki/Prototype_pattern)

[Prototype Pattern in Refactoring Guru](https://refactoring.guru/design-patterns/prototype)
