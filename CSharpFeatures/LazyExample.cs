public sealed class Singleton
{
    // Because Singleton's constructor is private, we must explicitly
    // give the Lazy<Singleton> a delegate for creating the Singleton.
    private static readonly Lazy<Singleton> instanceHolder =
        new Lazy<Singleton>(() => new Singleton());

    private Singleton()
    {
        ...
    }

    public static Singleton Instance
    {
        get { return instanceHolder.Value; }
    }
}

// Before the Lazy was part of the framework, we would have done it this way:

private static object lockingObject = new object();
public static LazySample InstanceCreation()
{
    if (lazilyInitObject == null)
    {
         lock (lockingObject)
         {
              if (lazilyInitObject == null)
              {
                   lazilyInitObject = new LazySample();
              }
         }
    }
    return lazilyInitObject;
}

/// <summary>
/// I agree strongly on considering an IoC container for this.
/// If however you want a simple lazy initialized object singleton also consider that if you do not need this to be thread safe doing it
/// manually with an If may be best considering the performance overhead of how Lazy handles itself. 
/// </summary>
