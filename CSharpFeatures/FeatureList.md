# C# List Features

## Lazy Initialization

#### Definition: 
Lazy Initialization is a performance optimization where you defer (potentially expensive) object creation until just before you actually need it. One good example is to not create a database connection up front, but only just before you need to get data from the database. The key reason for doing this is that (often) you can avoid creating the object completely if you never need it.

[Example](https://github.com/MfaXyz/Unity-Advanced-Engineering-Guide/blob/main/CSharpFeatures/LazyExample.cs)

#### References:
[Wikipedia](https://en.wikipedia.org/wiki/Lazy_initialization)
[Microsoft](https://learn.microsoft.com/en-us/dotnet/framework/performance/lazy-initialization)
