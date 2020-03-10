# Shopping Cart

It is a sample shopping cart class that implements some methods such as Applycoupon(), ApplyCampaign(), AddProduct(), CalculateDeliveryCost().

When start application Program.cs runs first. And it will be used to do the setup and register the IOC container. It configures App.cs and appsettings.json and manages objects lifecycle.
The App.cs class will be used to run the application and will contain all of the running console application code. It requires IConfiguration interface and provides with constructure injection.
Some delivery cost variables stored in appsettings.json file. To access these variables the packages used below.

```
Microsoft.Extensions.DependencyInjection
Microsoft.Extensions.Configuration
Microsoft.Extensions.Configuration.Binder
Microsoft.Extensions.Configuration.Json
```

Software standards have been adhered to as much as possible in such as SOLID principles, OOP standarts, Design Patterns. 
This approach enables loosely coupled classes which make them testable, maintainable and extensible.  


## Project Infrastructure

- ShoppingCart
- ShoppingCart.Test

## Technologies
* .Net Core 2.1
* xUnit
* Moq
* Linq

## Prerequisites
```
.Net Core SDK 2.1
Visual Studio 2017
```
