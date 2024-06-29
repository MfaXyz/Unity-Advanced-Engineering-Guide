# Unity-Software-Engineering-Guide

# Software Engineering:
[Related repositories](https://github.com/stars/MfaXyz/lists/design-architectural-patterns)

[High-level software development topics like domain driven design, design patterns, and antipatterns.](https://deviq.com/)

### Books:
[Level up your programming with game programming patterns By Unity](https://unity.com/resources/level-up-your-code-with-game-programming-patterns)

## SOLID Principles:

#### Single Responsiblity Principle:
`A Module should be responsible for one thing and has one reason to change.`
#### Open Closed Principle: 
`A module should be open for extention but closed for modification. We can solve this problem by using interfaces.`
#### Liskov Substitution Principle: 
`An Object(Such as class) may be replaced by a sub-object(such as a class that extends the first class) without breaking the program.
Derived classes should extend without replacing the functionality of old classes.`
#### Interface Segregation Principle: 
`Classes should not be forced to depend on methods they do not use.`

#### Dependency Inversion Principle:
`High level parts of the system should not depend on low level parts of the system directly, instead they should depend on some kind of abstraction(interfaces)` 
##### Note: 
So what is Dependency Injection? DI is a subtype of IoC (We will talk about it later) and is implemented by constructor injection, setter injection, or method injection. It’s a more specific implementation that focuses on the way objects obtain their dependencies. DI talks about how one object acquires dependency on another object through abstraction. DIP is a principle of the SOLID principles in Object-Oriented Programming. It’s about decoupling dependencies between high-level and low-level layers through shared abstractions. Dependency Injection is a form of Inversion of Control, but it doesn’t necessarily achieve much decoupling. Dependency Inversion is what achieves the decoupling, and is facilitated by using Dependency Injection with an Inversion of Control Container.


### Articles:
[SOLID C# Series' Articles](https://dev.to/bytehide/series/22559)

### Youtube:

[SOLID Unity3D by Jason Weimann](https://www.youtube.com/playlist?list=PLB5_EOMkLx_WjcjrsGUXq9wpTib3NCuqg)

[Unite Austin 2017 - S.O.L.I.D. by Unity](https://youtu.be/eIf3-aDTOOA?si=ChavzshqEoKFUUML)

[Practical Game Development by Infallible Code](https://www.youtube.com/playlist?list=PLKERDLXpXl_jmiWBfkcM4mSCa9MvdGpf9)

[S.O.L.I.D Design Patterns by Dapper Dino](https://youtube.com/playlist?list=PLS6sInD7ThM21gSGGFC1mQBL9nqlmUQOo&si=_TASVT7cDi_mqJZd)

## Design Patterns:
Design pattern list:

Creational Design Patterns: 1-Deal with creation(construction) of objects 2-Explicit (constructor) VS Implicit (DI, Reflection, etc) | Example: [Builder](https://github.com/MfaXyz/Unity-Advanced-Engineering-Guide/blob/main/DesignPatterns/Builder.md), Factories ([Factory Method](https://github.com/MfaXyz/Unity-Advanced-Engineering-Guide/blob/main/DesignPatterns/FactoryMethod.md) and Abstract Factory), Prototype and Singleton

Structrural Design Patterns: 1- Concerned with structure (e.g, Class Members) 2- Many patterns are wrappers that mimic the underlying class interface. 3- Stress the importance of good API design | Example: Adapter, Bridge, Composite, Decorator, Façade, Flyweight and Proxy

Behavioral Design Patterns: 1- They are all different: No central theme | Example: Chain of Responsibility, Command, Interpreter, Iterator, Mediator, Memento, Null Object, Observer, State, Strategy, Template Method, Visitor, Blackboard

Related Udemy Course: https://www.udemy.com/course/design-patterns-csharp-dotnet/

C# Design patterns by dofactory: https://www.dofactory.com/net/design-patterns

### Youtube:
[Game Programming Patterns by Infallible Code](https://www.youtube.com/playlist?list=PLKERDLXpXl_hN_3tPJdLgjWJ12VH6igy1)

[Game Programming Patterns Tutorials by Unity](https://www.youtube.com/playlist?list=PLX2vGYjWbI0TmDVbWNA56NbKKUgyUAQ9i)

[Game Programming Patterns by Jason Weimann](https://www.youtube.com/playlist?list=PLB5_EOMkLx_VOmnIytx37lFMiajPHppmj)

### 18 Key Design Patterns Every Developer Should Know:
![18-oo-patterns](https://github.com/MfaXyz/Unity-Booster/assets/76481805/2d97ad67-1ce8-4ef8-aabd-cc0a403b861a)


## Architectural Patterns:
Architectural pattern list: service locator, layered, hexagonal, MVC, MVVM

## Concurrency:

### Multithreading:
#### Parallel Programming:
Related Udemy Course: [Learn Parallel Programming with C# and .NET](https://www.udemy.com/course/parallel-dotnet/)

### Asynchronous Programming (vs Synchronous):

## Clean Code:
[C# Coding Standards](https://www.dofactory.com/csharp-coding-standards)

### Youtube:
[Clean Code - Uncle Bob - all lessons](https://youtube.com/playlist?list=PLmmYSbUCWJ4x1GO839azG_BBw8rkh-zOj&si=ZpFGKBTFG1guYTVH)

## Test Driven Development:
### Youtube:
[Test-Driven Development (TDD) in Unity by Infallible Code](https://www.youtube.com/playlist?list=PLKERDLXpXl_jJQiQOHDLimnulasAK3T5b)

## Inversion of Control (IoC)
It’s a programming principle that inverts the flow of control in an application. Instead of the programmer controlling the flow of a program, the external sources (framework, services, other components) take control of it. In the context of service containers, IoC is achieved by allowing the framework to do the binding and instantiation of dependencies.

[Zenject by Infallible Code](https://youtube.com/playlist?list=PLKERDLXpXl_jNJPY2czQcfPXW4BJaGZc_&si=Ar8vTmZIvcr-wfTC)

## Miscs:

### Youtube:
[Live Tutorials & Coding Sessions by Infallible Code](https://www.youtube.com/playlist?list=PLKERDLXpXl_jyhY9wh8deByUuwz2W6y-P)

[Productivity Assets for Unity by Infallible Code](https://youtube.com/playlist?list=PLKERDLXpXl_i5fEUdMo4bvn5-Nqh9aAcX&si=cY94QdKAxkSJ4Pqr)

[Programming For Production iHeartGameDev](https://www.youtube.com/playlist?list=PLwyUzJb_FNeTR1Q7edAQuWkTKo_Ncq9ck)
