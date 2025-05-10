# Decorator Design Pattern
Intent: The intent of the Decorator pattern is to dynamically add new behavior or responsibilities to individual objects without modifying their original class or using inheritance. It achieves this by wrapping the object with a series of decorator classes that implement the same interface and can enhance or override specific behavior. This allows for flexible, modular, and reusable code that can be extended at runtime, adhering to the Open/Closed Principle by enabling behavior extension without altering existing code.

The decorator pattern allows responsibilities to be added (and removed from) an object dynamically at run-time. It is achieved by defining Decorator objects that:
- implement the interface of the extended (decorated) object (Component) transparently by forwarding all requests to it.
- perform additional functionality before or after forwarding a request.

This allows working with different Decorator objects to extend the functionality of an object dynamically at run-time.

“Wrapper” is the alternative nickname for the Decorator pattern that clearly expresses the main idea of the pattern. A wrapper is an object that can be linked with some target object. The wrapper contains the same set of methods as the target and delegates to it all requests it receives. However, the wrapper may alter the result by doing something either before or after it passes the request to the target.

When does a simple wrapper become the real decorator? As I mentioned, the wrapper implements the same interface as the wrapped object. That’s why from the client’s perspective these objects are identical. Make the wrapper’s reference field accept any object that follows that interface. This will let you cover an object in multiple wrappers, adding the combined behavior of all the wrappers to it.

## Example

#### abstract class ComponentDecorator
```C#
// The base Component interface defines operations that can be altered by decorators.

public abstract class ComponentDecorator
{
    public abstract string Operation();
}
```

#### class ConcreteComponent : ComponentDecorator
```C#
public class ConcreteComponent : ComponentDecorator
{
    public override string Operation()
    {
        return "ConcreteComponent";
    }
}
```

#### abstract class Decorator : ComponentDecorator
```C#
// The base Decorator class follows the same interface as the other
// components. The primary purpose of this class is to define the wrapping
// interface for all concrete decorators. The default implementation of the
// wrapping code might include a field for storing a wrapped component and
// the means to initialize it.

public abstract class Decorator : ComponentDecorator
{
    protected ComponentDecorator _component;

    protected Decorator(ComponentDecorator component)
    {
        this._component = component;
    }

    public void SetComponent(ComponentDecorator component)
    {
        this._component = component;
    }
    
    // The Decorator delegates all work to the wrapped component.
    public override string Operation()
    {
        return this._component != null ? this._component.Operation() : string.Empty;
    }
}
```

#### class ConcreteDecoratorA : Decorator
```C#
public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(ComponentDecorator component) : base(component)
    {
    }
    
    // Decorators may call parent implementation of the operation, instead
    // of calling the wrapped object directly. This approach simplifies
    // extension of decorator classes.
    public override string Operation()
    {
        return $"ConcreteDecoratorA({_component.Operation()})";
    }
}
```

#### class Client
```C#
using UnityEngine;

public class Client
{
    // The client code works with all objects using the Component interface.
    // This way it can stay independent of the concrete classes of
    // components it works with.
    public void ClientCode(ComponentDecorator component)
    {
        Debug.Log("RESULT: " + component.Operation());
    }
}
```

#### class ConcreteDecoratorB : Decorator
```C#
// Decorators can execute their behavior either before or after the call to
// a wrapped object.

internal class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(ComponentDecorator  comp) : base(comp)
    {
    }

    public override string Operation()
    {
        return $"ConcreteDecoratorB({base.Operation()})";
    }
}
```

#### class MainProgramDecorator : MonoBehaviour
```C#
using UnityEngine;

public class MainProgramDecorator : MonoBehaviour
{
    private void Start()
    {
        var client = new Client();

        var simple = new ConcreteComponent();
        Debug.Log("Client: I get a simple component:");
        client.ClientCode(simple);

        // ...as well as decorated ones.
        //
        // Note how decorators can wrap not only simple components but the
        // other decorators as well.
        var decorator1 = new ConcreteDecoratorA(simple);
        var decorator2 = new ConcreteDecoratorB(decorator1);
        Debug.Log("Client: Now I've got a decorated component:");
        client.ClientCode(decorator2);
    }
}
```

#### RESULT:
![image](https://github.com/user-attachments/assets/965280d6-2394-4306-aa3b-46eb545c1939)


## Applicability
- Use the Decorator pattern when you need to be able to assign extra behaviors to objects at runtime without breaking the code that uses these objects.
- Use the pattern when it’s awkward or not possible to extend an object’s behavior using inheritance.
