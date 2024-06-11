# Hello World.

Builder: set up component-based entity one component at a time, based on data
Factory Method: create NPCs or GUI widgets based on a string read from a file
Prototype: store one generic 'Elf' character with initial properties and create Elf instances by cloning it.
Singleton: this space deliberately left blank.
Adapter: incorporate an optional 3rd party library by wrapping it in a layer that looks like your existing code. Very useful with DLLs.
Composite: make a scene graph of renderable objects, or make a GUI out of a tree of Widgets
Facade: simplify complex 3rd party libraries by providing a simpler interface to make your life easier later.
Flyweight: store the shared aspects of an NPC (eg. models, textures, animations) separately from the individual aspects (eg. position, health) in a mostly transparent way
Proxy: Create small classes on a client that represent larger, more complex classes on a server, and forward requests via the network.
Chain of responsibility: handle input as a chain of handlers, eg. global keys (eg. for screen shots), then the GUI (eg. in case a text box is focused or a menu is up), then the game (eg. for moving a character)
Command: encapsulate game functionality as commands which can be typed into a console, stored and replayed, or even scripted to help test the game
Mediator: implement game entities as a small mediator class that operates on different components (eg. reading from the health component in order to pass the data to the AI component)
Observer: have the renderable representation of a character listen to events from the logical representation, in order to change the visual presentation when necessary without the game logic needing to know anything about rendering code
State: store NPC AI as one of several states, eg. Attacking, Wandering, Fleeing. Each can have its own update() method and whatever other data it needs (eg. storing which character it is attacking or fleeing from, the area in which it is wandering, etc.)
Strategy: switch between different heuristics for your A* search, depending on what sort of terrain you're in, or perhaps even to use the same A* framework to do both pathfinding and more generic planning
Template method: set up a generic 'combat' routine, with various hook functions to handle each step, eg. decrement ammo, calculate hit chance, resolve hit or miss, calculate damage, and each type of attack skill will implement the methods in their own specific way
