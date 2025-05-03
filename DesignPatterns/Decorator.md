# Decorator Design Pattern
Intent: The intent of the Decorator pattern is to dynamically add new behavior or responsibilities to individual objects without modifying their original class or using inheritance. It achieves this by wrapping the object with a series of decorator classes that implement the same interface and can enhance or override specific behavior. This allows for flexible, modular, and reusable code that can be extended at runtime, adhering to the Open/Closed Principle by enabling behavior extension without altering existing code.

The decorator pattern allows responsibilities to be added (and removed from) an object dynamically at run-time. It is achieved by defining Decorator objects that:
- implement the interface of the extended (decorated) object (Component) transparently by forwarding all requests to it.
- perform additional functionality before or after forwarding a request.

This allows working with different Decorator objects to extend the functionality of an object dynamically at run-time.
