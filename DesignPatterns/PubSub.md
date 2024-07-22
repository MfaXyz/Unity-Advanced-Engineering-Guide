# Publisher / Subscribe Pattern

Definition: `Publish-Subscribe (pub/sub) pattern is a messaging pattern where senders (publishers) and receivers (subscribers) communicate through a central message broker or event bus.`

In the pub/sub pattern, the following components are involved:
- Publishers: Components that generate events or messages. They do not know who will receive these messages.
- Subscribers: Components that are interested in specific events or messages. They subscribe to the desired events and receive notifications when new messages are published.
- Message Broker or Event Bus: A central component that manages the communication between publishers and subscribers. It receives messages from publishers, stores them, and delivers them to the appropriate subscribers.

- 
The pub/sub pattern has several advantages, such as:
- Decoupling: Publishers and subscribers are decoupled, which means they do not need to know each other's existence or implementation details. This allows for easier maintenance, scalability, and flexibility.
- Asynchronous communication: Publishers and subscribers can communicate asynchronously, which improves performance and scalability.
- Flexibility: Subscribers can subscribe to multiple events or messages, allowing for a flexible and dynamic system.
- Load balancing: The message broker can distribute messages to multiple subscribers, allowing for load balancing and improved performance.

# Examples:

## Example 1:

> [!NOTE]
> This example doesn't have Event Bus.

### EmitterEntity.cs
```C#
using System;
using UnityEngine;

namespace SignalSystem
{
    public class EmitterEntity : MonoBehaviour
    {
        public static event Action<string> OnEmitSignal;
        [SerializeField] private string signalName;

        public void EmitTheEvent()
        {
            Debug.Log($"Signal sent! Signal name: {signalName}");
            OnEmitSignal?.Invoke(signalName);
        }
    }
}
```
### ReceiverEntity.cs
```C#
using UnityEngine;

namespace SignalSystem
{
    public class ReceiverEntity : MonoBehaviour
    {
        [SerializeField] private string signalName;
        private void OnEnable()
        {
            EmitterEntity.OnEmitSignal += ReceiveSignal;
        }

        private void OnDisable()
        {
            EmitterEntity.OnEmitSignal -= ReceiveSignal;
        }

        private void ReceiveSignal(string receivedSignalName)
        {
            if (signalName == receivedSignalName)
            {
                Debug.Log($"I'm a Receiver! My object name is {gameObject.name} and signal was {receivedSignalName}");
            }
        }
    }
}
```

## Example 2:

### Signal.cs
```C#
using System.Collections.Generic;
using UnityEngine;

namespace SignalSystem
{
    [CreateAssetMenu(menuName = "Xyz/Signal Object",fileName = "New Signal Object",order = 2)]
    public class Signal : ScriptableObject
    {
        public List<SignalListener> listeners;

        public void Raise(int outputNumber)
        {
            foreach (var listener in listeners)
            {
                listener.OnSignalRaised(outputNumber);
            }
        }
        public void RegisterListener(SignalListener listener)
        {
            listeners.Add(listener);
        }
        public void DeRegisterListener(SignalListener listener)
        {
            listeners.Remove(listener);
        }
    }
}
```

### SignalListener.cs
```C#
using System;
using UnityEngine;

namespace SignalSystem
{
    public class SignalListener : MonoBehaviour
    {
        public Signal signal;
        public event Action<int> SignalOutput;
        
        public void OnSignalRaised(int outputNumber)
        {
            SignalOutput?.Invoke(outputNumber);
        }
        

        private void OnEnable()
        {
            signal.RegisterListener(this);
        }
        private void OnDisable()
        {
            signal.DeRegisterListener(this);
        }
    }
}
```

### Usage Exameple Class:
```C#
using SignalSystem;
using UnityEngine;

public class SystemTester : MonoBehaviour
{
    public SignalListener signalListener;

    private void Start()
    {
        SubscribeMethodToEvent();
    }

    private void SubscribeMethodToEvent()
    {
        signalListener.SignalOutput += PrintEnumName;
    }

    private static void PrintEnumName(int outputNumber)
    {
        var enumMember = (TestEnum)outputNumber;
        Debug.Log($"Something Printed with Number Of {enumMember}");
    }
}

public enum TestEnum
{
    First = 1,
    Second = 2,
    Third = 4,
    Fourth = 8
}
```
![image](https://github.com/user-attachments/assets/0b071470-3611-4e47-8833-fe46f649dbca)

# References:
[Implementing the Publish-subscribe pattern in Unity](https://medium.com/@kunaltandon.kt/implementing-the-publish-subscribe-pattern-in-unity-knowledge-scoops-60ca0ac29884)

[Pub/Sub Messenger for Unity](https://github.com/supermax/pubsub)

[A typesafe, lightweight messaging lib for Unity](https://github.com/yankooliveira/signals)

[Unite Austin 2017 - Game Architecture with Scriptable Objects](https://youtu.be/raQ3iHhE_Kk?si=qJPChERmD1eRoGrc)

[Unite 2016 - Overthrowing the MonoBehaviour Tyranny in a Glorious Scriptable Object Revolution](https://youtu.be/6vmRwLYWNRo?si=v1nPAxOrkNhOW8jM)
