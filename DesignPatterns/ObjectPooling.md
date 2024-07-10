# Object Pooling Design Pattern

Definition: `Object Pooling is a great way to optimize your projects and lower the burden that is placed on the CPU when having to rapidly create and destroy GameObjects. It is a good practice and design pattern to keep in mind to help relieve the processing power of the CPU to handle more important tasks and not become inundated by repetitive create and destroy calls. In this tutorial, you will learn to use Object Pooling to optimize your projects.`

## Example:

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

### References:
[Introduction to Object Pooling by Unity](https://learn.unity.com/tutorial/introduction-to-object-pooling)
