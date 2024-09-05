# Adapter Design Pattern

intent: `The Adapter pattern is a software design pattern that allows the interface of an existing class to be used as another interface. It is often used to make existing classes work with others without modifying their source code.`

The adapter design pattern solves problems like:
- How can a class be reused that does not have an interface that a client requires?
- How can classes that have incompatible interfaces work together?
- How can an alternative interface be provided for a class?


## Example:
```C#
public interface ILightningPhone
{
	void ConnectLightning();
	void Recharge();
}

public interface IUsbPhone
{
	void ConnectUsb();
	void Recharge();
}

public sealed class AndroidPhone : IUsbPhone
{
	private bool isConnected;
	
	public void ConnectUsb()
	{
		this.isConnected = true;
		Console.WriteLine("Android phone connected.");
	}

	public void Recharge()
	{
		if (this.isConnected)
		{
			Console.WriteLine("Android phone recharging.");
		}
		else
		{
			Console.WriteLine("Connect the USB cable first.");
		}
	}
}

public sealed class ApplePhone : ILightningPhone
{
	private bool isConnected;
	
	public void ConnectLightning()
	{
		this.isConnected = true;
		Console.WriteLine("Apple phone connected.");
	}

	public void Recharge()
	{
		if (this.isConnected)
		{
			Console.WriteLine("Apple phone recharging.");
		}
		else
		{
			Console.WriteLine("Connect the Lightning cable first.");
		}
	}
}

public sealed class LightningToUsbAdapter : IUsbPhone
{
	private readonly ILightningPhone lightningPhone;
	
	private bool isConnected;
	
	public LightningToUsbAdapter(ILightningPhone lightningPhone)
	{
		this.lightningPhone = lightningPhone;
	}
	
	public void ConnectUsb()
	{
		this.lightningPhone.ConnectLightning();
	}

	public void Recharge()
	{
		this.lightningPhone.Recharge();
	}
}

public void Main()
{
	ILightningPhone applePhone = new ApplePhone();
	IUsbPhone adapterCable = new LightningToUsbAdapter(applePhone);
	adapterCable.ConnectUsb();
	adapterCable.Recharge();
}
```

## References:

[Wikipedia](https://en.wikipedia.org/wiki/Adapter_pattern)

[Refactoring.guru](https://refactoring.guru/design-patterns/adapter)
