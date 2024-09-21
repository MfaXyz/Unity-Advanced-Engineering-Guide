# Composite Design Pattern

intent: `Composite is a structural design pattern that lets you compose objects into tree structures and then work with these structures as if they were individual objects.`

In game programming, this pattern is commonly applied to organize groups of related game objects, for example, in a real-time strategy game, where units, squads, and armies all behave similarly but have different hierarchical roles.

## Example:

In this example, we will create a structure where individual soldiers form squads, and multiple squads form an army. The goal is to make sure we can command both a single soldier or an entire army using the same interface.

#### IUnit.cs

1 - We define a Unit interface to declare common methods for both individual soldiers and composite units like squads and armies.

```C#
public interface IUnit
{
    void Move(Vector3 destination);
    void Attack(Vector3 target);
    int GetHealth();
}
```

#### Soldier.cs

2 - We implement the Soldier class that represents individual units in the game.

```C#
public class Soldier : IUnit
{
    private int health;
    
    public Soldier(int health)
    {
        this.health = health;
    }
    
    public void Move(Vector3 destination)
    {
        Debug.Log("Soldier moving to: " + destination);
        // Add logic to move the soldier
    }
    
    public void Attack(Vector3 target)
    {
        Debug.Log("Soldier attacking target at: " + target);
        // Add logic to attack the target
    }
    
    public int GetHealth()
    {
        return health;
    }
}
```

#### Squad.cs

We implement the Squad class, which can contain multiple soldiers or other units.

```C#
public class Squad : IUnit
{
    private List<IUnit> units = new List<IUnit>();

    public void AddUnit(IUnit unit)
    {
        units.Add(unit);
    }

    public void RemoveUnit(IUnit unit)
    {
        units.Remove(unit);
    }

    public void Move(Vector3 destination)
    {
        foreach (IUnit unit in units)
        {
            unit.Move(destination);
        }
    }

    public void Attack(Vector3 target)
    {
        foreach (IUnit unit in units)
        {
            unit.Attack(target);
        }
    }

    public int GetHealth()
    {
        int totalHealth = 0;
        foreach (IUnit unit in units)
        {
            totalHealth += unit.GetHealth();
        }
        return totalHealth;
    }
}
```

#### ArmyController.cs

Now, we can create individual soldiers, add them to a squad, and command them as a group.

```C#
public class ArmyController : MonoBehaviour
{
    void Start()
    {
        // Create individual soldiers
        IUnit soldier1 = new Soldier(100);
        IUnit soldier2 = new Soldier(100);
        
        // Create a squad and add soldiers to it
        Squad squad = new Squad();
        squad.AddUnit(soldier1);
        squad.AddUnit(soldier2);
        
        // Command the squad to move and attack
        squad.Move(new Vector3(10, 0, 10));
        squad.Attack(new Vector3(20, 0, 20));
        
        // Check total health of the squad
        Debug.Log("Total squad health: " + squad.GetHealth());
    }
}

```

## References:

[Wikipedia](https://en.wikipedia.org/wiki/Composite_pattern)

[Guru](https://refactoring.guru/design-patterns/composite)
