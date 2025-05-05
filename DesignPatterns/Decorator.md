# Decorator Design Pattern
Intent: The intent of the Decorator pattern is to dynamically add new behavior or responsibilities to individual objects without modifying their original class or using inheritance. It achieves this by wrapping the object with a series of decorator classes that implement the same interface and can enhance or override specific behavior. This allows for flexible, modular, and reusable code that can be extended at runtime, adhering to the Open/Closed Principle by enabling behavior extension without altering existing code.

The decorator pattern allows responsibilities to be added (and removed from) an object dynamically at run-time. It is achieved by defining Decorator objects that:
- implement the interface of the extended (decorated) object (Component) transparently by forwarding all requests to it.
- perform additional functionality before or after forwarding a request.

This allows working with different Decorator objects to extend the functionality of an object dynamically at run-time.

“Wrapper” is the alternative nickname for the Decorator pattern that clearly expresses the main idea of the pattern. A wrapper is an object that can be linked with some target object. The wrapper contains the same set of methods as the target and delegates to it all requests it receives. However, the wrapper may alter the result by doing something either before or after it passes the request to the target.

When does a simple wrapper become the real decorator? As I mentioned, the wrapper implements the same interface as the wrapped object. That’s why from the client’s perspective these objects are identical. Make the wrapper’s reference field accept any object that follows that interface. This will let you cover an object in multiple wrappers, adding the combined behavior of all the wrappers to it.

