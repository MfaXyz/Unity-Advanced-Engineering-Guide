# Singleton Design Pattern

intent: `For some components it only makes sense to have one in the system, we call this Singleton (e.g., Database repository, and Object factory). We only do it once. We provide everyone with the same instance and want to prevent anyone creating additional copies.`

Just like a global variable, the Singleton pattern lets you access some object from anywhere in the program. However, it also protects that instance from being overwritten by other code. Use the Singleton pattern when a class in your program should have just a single instance available to all clients; for example, a single database object shared by different parts of the program. The Singleton pattern disables all other means of creating objects of a class except for the special creation method. This method either creates a new object or returns an existing one if it has already been created.

## Example:

### SingletonClass.cs
```C#
using UnityEngine;

public class SingletonClass : MonoBehaviour
{
    public static SingletonClass Instance { get; private set; }

    public float testVariable;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } else {
            Instance = this;
        }

        testVariable = Random.Range(0, 10);
    }
}
```

### TestClass.cs
```C#
using UnityEngine;

public class TestClass : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(SingletonClass.Instance.testVariable);
    }
}

```


## Resources:
(Singleton pattern)[https://en.wikipedia.org/wiki/Singleton_pattern]

(Singleton refactoring.guru)[https://refactoring.guru/design-patterns/singleton]

(Stack Exchange)[https://gamedev.stackexchange.com/questions/116009/in-unity-how-do-i-correctly-implement-the-singleton-pattern]
