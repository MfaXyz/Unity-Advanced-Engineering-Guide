/// <summary>
/// The instance of SomeClass is not initialized until it is first needed by the SomeClassSingleton consumer.
/// </summary>

public class SomeClassSingleton
{
    private static SomeClass _instance = null;

    private SomeClassSingleton()
    {
    }

    public static SomeClass GetInstance()
    {
        if(_instance == null)
            _instance = new SomeClassSingleton();

        return _instance;
    }
}
