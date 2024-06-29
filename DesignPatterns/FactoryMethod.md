# Factory Method Design Pattern
`It deals with the problem of creating objects without having to specify their exact class. Rather than by calling a constructor. This is done by calling a factory method to create an object. Factory methods can either be specified in an interface and implemented by child classes, or implemented in a base class and optionally overridden by derived classes.`

> "Define an interface for creating an object, but let subclasses decide which class to instantiate. The Factory method lets a class defer instantiation it uses to subclasses." (Gang Of Four)

### Definition/Intent:
Creating an object often requires complex processes not appropriate to include within a composing object. The object's creation may lead to a significant duplication of code, may require information not accessible to the composing object, may not provide a sufficient level of abstraction, or may otherwise not be part of the composing object's concerns. The factory method design pattern handles these problems by defining a separate method for creating the objects, which subclasses can then override to specify the derived type of product that will be created.

The factory method pattern relies on inheritance, as object creation is delegated to subclasses that implement the factory method to create objects.

### Examples:
#### Person Factory:

IPerson Interface:
```C#
namespace DesignPatterns.Factory_Method
{
    public interface IPerson
    {
        string GetName();
        void Land();
    }
}
```

PersonType Enum:
```C#
namespace DesignPatterns.Factory_Method
{
    public enum PersonType
    {
        Rural,
        Urban
    }
}
```

Villager Class:
```C#
using UnityEngine;

namespace DesignPatterns.Factory_Method
{
    public class Villager : IPerson
    {
        public string GetName()
        {
            return "Village Person";
        }

        public void Land()
        {
            Debug.Log($"I Land as Villager person.");
        }
    }
}
```

CityPerson Class:
```C#
using UnityEngine;

namespace DesignPatterns.Factory_Method
{
    public class CityPerson : IPerson
    {
        public string GetName()
        {
            return "City Person";
        }
        public void Land()
        {
            Debug.Log($"I Land as City person.");
        }
    }
}
```

PersonFactory Class:
```C#
using System;

namespace DesignPatterns.Factory_Method
{
    public abstract class PersonFactory
    {
        public static IPerson GetPerson(PersonType type)
        {
            return type switch
            {
                PersonType.Rural => new Villager(),
                PersonType.Urban => new CityPerson(),
                _ => throw new NotSupportedException()
            };
        }
    }
}
```

PersonManagement Class:
```C#
using System;

namespace DesignPatterns.Factory_Method
{
    public abstract class PersonFactory
    {
        public static IPerson GetPerson(PersonType type)
        {
            return type switch
            {
                PersonType.Rural => new Villager(),
                PersonType.Urban => new CityPerson(),
                _ => throw new NotSupportedException()
            };
        }
    }
}
```

Result:

![image](https://github.com/MfaXyz/Unity-Advanced-Engineering-Guide/assets/76481805/36dbaed3-635b-4dae-94fc-1d41ff4aaaf0)


## References & Resources:
[Wikipedia](https://en.wikipedia.org/wiki/Factory_method_pattern)
