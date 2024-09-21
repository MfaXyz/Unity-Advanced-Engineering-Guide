# Bridge Design Pattern

intent: `separate an abstraction from its implementation, allowing the two to evolve independently. The main intent is to provide a way to decouple an interface from its implementation, enabling more flexible and maintainable code.`

When a class varies often, the features of object-oriented programming become very useful because changes to a program's code can be made easily with minimal prior knowledge about the program. The bridge pattern is useful when both the class and what it does vary often. The class itself can be thought of as the abstraction and what the class can do as the implementation. The bridge pattern can also be thought of as two layers of abstraction.

> [!NOTE]
> The bridge pattern is often confused with the adapter pattern, and is often implemented using the object adapter pattern.

## Example:

#### Problem Statement:
Imagine you are developing a game where different vehicles (like cars, boats, and airplanes) can have different controls (keyboard, gamepad). Using a bridge pattern, you can separate the vehicle abstraction from the control system, allowing flexibility in both without affecting each other.

#### Structure of Bridge Pattern:
- Abstraction: The high-level layer, such as `Vehicle`, that uses the `ControlSystem`.
- Implementor: The interface defining the `ControlSystem` behavior.
- Concrete Implementor: Specific implementations of the `ControlSystem`, like `KeyboardContro`l or `GamepadControl`.
- Concrete Abstraction: A concrete class like `Car`, `Boat`, or `Airplane`, inheriting from `Vehicle`.

#### IControlSystem.cs
```C#
// The 'Implementor' interface
public interface IControlSystem
{
    void Accelerate();
    void Steer();
}
```

#### KeyboardControl.cs


## References:
[Wikipedia](https://en.wikipedia.org/wiki/Bridge_pattern)
