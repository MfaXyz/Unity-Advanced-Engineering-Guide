# Builder Design Pattern
`The builder pattern is a design pattern designed to provide a flexible solution to various object creation problems in object-oriented programming. The intent of the builder design pattern is to separate the construction of a complex object from its representation. It is one of the Gang of Four design patterns.`
## Resources:
[Refactoring Guru](https://refactoring.guru/design-patterns/builder)

[Wikipedia](https://en.wikipedia.org/wiki/Builder_pattern)


## Example:

### Program Class:
```C#
using UnityEngine;

namespace Builder
{
    /// <summary>
    /// The main entry point for the Unity application.
    /// </summary>
    public class Program : MonoBehaviour
    {
        /// <summary>
        /// Unity's Start method. This method is called when the script instance is being loaded.
        /// </summary>
        private void Start()
        {
            // Create a new Director instance
            var director = new Director();

            // Create a new ConcreteBuilder instance
            var builder = new ConcreteBuilder();

            // Assign the builder to the director
            director.Builder = builder;

            // Build a minimal viable product
            print("basic:");
            director.BuildMinimalViableProduct();
            print(builder.GetProduct().ListParts());

            // Build a full-featured product
            print("Full:");
            director.BuildFullFeaturedProduct();
            print(builder.GetProduct().ListParts());

            // Build a custom product
            print("Custom:");
            builder.BuildPartA();
            builder.BuildPartB();
            print(builder.GetProduct().ListParts());
        }
    }
}
```

### Director Class:
```C#
namespace Builder
{
    /// <summary>
    /// The Director class is responsible for constructing products using a builder object.
    /// </summary>
    public class Director
    {
        private IBuilder _builder;

        /// <summary>
        /// Sets the builder object to be used for constructing products.
        /// </summary>
        /// <param name="value">The builder object.</param>
        public IBuilder Builder
        {
            set => _builder = value;
        }

        /// <summary>
        /// Constructs a minimal viable product using the builder object.
        /// </summary>
        public void BuildMinimalViableProduct()
        {
            _builder.BuildPartA();
        }

        /// <summary>
        /// Constructs a full-featured product using the builder object.
        /// </summary>
        public void BuildFullFeaturedProduct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }
}
```
### IBuilder Interface:
```C#
namespace Builder
{
    public interface IBuilder
    {
        void BuildPartA();

        void BuildPartB();

        void BuildPartC();
    }
}
```
### ConcerteBuilder Class:
```C#
namespace Builder
{
    /// <summary>
    /// ConcreteBuilder class implements the IBuilder interface and constructs a complex object using a step-by-step approach.
    /// </summary>
    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcreteBuilder"/> class.
        /// Resets the internal state of the builder.
        /// </summary>
        public ConcreteBuilder()
        {
            Reset();
        }

        /// <summary>
        /// Resets the internal state of the builder.
        /// </summary>
        private void Reset()
        {
            _product = new Product();
        }

        /// <summary>
        /// Adds a part A to the product being constructed.
        /// </summary>
        public void BuildPartA()
        {
            _product.Add("PartA1");
        }

        /// <summary>
        /// Adds a part B to the product being constructed.
        /// </summary>
        public void BuildPartB()
        {
            _product.Add("PartB1");
        }

        /// <summary>
        /// Adds a part C to the product being constructed.
        /// </summary>
        public void BuildPartC()
        {
            _product.Add("PartC1");
        }

        /// <summary>
        /// Retrieves the constructed product and resets the internal state of the builder.
        /// </summary>
        /// <returns>The constructed product.</returns>
        public Product GetProduct()
        {
            var result = _product;
        
            Reset();

            return result;
        }
    }
}
```
### Product Class:
```C#
using System.Collections.Generic;

namespace Builder
{
    /// <summary>
    /// Represents a product with its parts.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Holds the parts of the product.
        /// </summary>
        private readonly List<object> _parts = new();

        /// <summary>
        /// Adds a part to the product.
        /// </summary>
        /// <param name="part">The part to be added.</param>
        public void Add(string part)
        {
            _parts.Add(part);
        }

        /// <summary>
        /// Lists all parts of the product.
        /// </summary>
        /// <returns>A string representation of the product's parts.</returns>
        public string ListParts()
        {
            var str = string.Empty;

            for (var i = 0; i < _parts.Count; i++)
            {
                str += _parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Product parts: " + str + "\n";
        }
    }
}
```
