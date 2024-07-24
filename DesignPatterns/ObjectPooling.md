# Object Pooling Design Pattern

Definition: `Object Pooling is a great way to optimize your projects and lower the burden that is placed on the CPU when having to rapidly create and destroy GameObjects. It is a good practice and design pattern to keep in mind to help relieve the processing power of the CPU to handle more important tasks and not become inundated by repetitive create and destroy calls. In this tutorial, you will learn to use Object Pooling to optimize your projects.`

# Examples:

## Example 1:

```C#
using System.Collections.Generic;
using UnityEngine;

public class ParticleGuidePool : MonoBehaviour
{
    public static ParticleGuidePool sharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        CreatePool(amountToPool);
    }

    private void CreatePool(int amount)
    {
        pooledObjects = new List<GameObject>();
        for(var i = 0; i < amount; i++)
        {
            var tempObject = Instantiate(objectToPool, transform);
            tempObject.SetActive(false);
            pooledObjects.Add(tempObject);
        }
    }
    
    public GameObject GetPooledObject()
    {
        for(var i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
```

Just use `GetPooledObject` method to get an object for from the pool, after finishing the work, instead of destroying the GameObject, deactivate it to return it to the pool.
```C#
GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
  if (bullet != null) {
    bullet.transform.position = turret.transform.position;
    bullet.transform.rotation = turret.transform.rotation;
    bullet.SetActive(true);
  }
.
.
.
gameobject.SetActive(false);
```

## Example 2: (Best Choice - Unity Built-in System)

The ObjectPool uses a stack to hold a collection of object instances for reuse and is not thread-safe.

### ReturnToPool.cs
```C#
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ReturnToPool : MonoBehaviour
{
    public GameObject system;
    public IObjectPool<GameObject> Pool;
    
    private void Start()
    {
        system = gameObject;
    }

    private void OnObjectSystemStopped()
    {
        // Return to the pool
        Pool.Release(system);
    }

    private void OnEnable()
    {
        StartCoroutine(ReleaseObject());
    }

    private IEnumerator ReleaseObject()
    {
       yield return new WaitForSeconds(3);
       OnObjectSystemStopped();
    }
}
```
### PoolExample.cs

```C#
using UnityEngine;
using UnityEngine.Pool;

// This example spans a random number of GameObjects using a pool so that old systems can be reused.
public class PoolExample : MonoBehaviour
{
    public enum PoolType
    {
        Stack,
        LinkedList
    }

    public PoolType poolType;

    // Collection checks will throw errors if we try to release an item that is already in the pool.
    public bool collectionChecks = true;
    public int maxPoolSize;

    private IObjectPool<GameObject> _pool;

    private IObjectPool<GameObject> Pool
    {
        get
        {
            if (_pool == null)
            {
                if (poolType == PoolType.Stack)
                    _pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                else
                    _pool = new LinkedPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
            }

            return _pool;
        }
    }

    private GameObject CreatePooledItem()
    {
        var go = new GameObject("Pooled Object");
        // This is used to return GameObjects to the pool when they have stopped.
        var returnToPool = go.AddComponent<ReturnToPool>();
        returnToPool.Pool = Pool;
        return go;
    }

    // Called when an item is returned to the pool using Release
    private static void OnReturnedToPool(GameObject system)
    {
        system.SetActive(false);
    }
    
    // Called when an item is taken from the pool using Get
    private static void OnTakeFromPool(GameObject system)
    {
        system.SetActive(true);
    }
    // If the pool capacity is reached then any items returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    private static void OnDestroyPoolObject(GameObject system)
    {
        Destroy(system.gameObject);
    }

    private void OnGUI()
    {
        GUILayout.Label("Pool size: " + Pool.CountInactive);
        if (GUILayout.Button("Create Objects"))
        {
            var amount = Random.Range(1, 10);
            for (var i = 0; i < amount; i++)
            {
                var ps = Pool.Get();
                ps.transform.position = Random.insideUnitSphere * 10;
            }
        }
    }
}
```

# References:
[Introduction to Object Pooling by Unity](https://learn.unity.com/tutorial/introduction-to-object-pooling)

[Unity Built-in ObjectPool<T> system](https://docs.unity3d.com/ScriptReference/Pool.ObjectPool_1.html)
