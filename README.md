# RapidLaunch

A quick and simple way to catapult your application's persistence.

![TempIcon](https://i.imgur.com/UrmaPkW.jpg)

![build-status](https://github.com/mjbradvica/RapidLaunch/workflows/main/badge.svg) ![downloads](https://img.shields.io/nuget/dt/RapidLaunch) ![downloads](https://img.shields.io/nuget/v/RapidLaunch) ![activity](https://img.shields.io/github/last-commit/mjbradvica/RapidLaunch/master)

## Overview

The advantages of RapidLaunch are:

- :rocket: Add and remove methods with just an interface
- :gear: Modify and override almost anything
- :dvd: EF, ADO.NET, Mongo, and Dapper support
- :bento: Full Interface Segregation
- :purse: Cancellation Token support

## Table of Contents

- [RapidLaunch](#rapidlaunch)
  - [Overview](#overview)
  - [Samples](#samples)
  - [Dependencies](#dependencies)
  - [Installation](#installation)
  - [Setup](#setup)
    - [Registering A Different Publisher](#registering-a-different-publisher)

## Samples

If you like code samples for RapidLaunch, they may be found [here](https://github.com/mjbradvica/RapidLaunch/tree/master/samples).

## Dependencies

RapidLaunch has a dependency on [ClearDomain](https://github.com/mjbradvica/ClearDomain).

This is required because RapidLaunch needs a constraint for an entity identifier and domain events for publishing.

If you are new to ClearDomain I recommend using it as the core foundation for your domain. It only takes 5 minutes to learn.

Each respective RapidLaunch package for a specific persistence method has a dependency on the said framework.

## Installation

The easiest way to get started is to: [Install with Nuget](https://www.nuget.org/packages/RapidLaunch/)

Install the base package in your application layer with:

```bash
Install-Package ChainStrategy
```

Install the persistence-specific package in your infrastructure layer with:

```bash
Install-Package ChainStrategy."PackageType"
```

## Setup

RapidLaunch provides a built-in method for easy Dependency Injection with any DI container that is Microsoft compatible.

RapidLaunch automatically registers any repository that uses a base rapid launch repository class as well as any domain event handlers you define if you choose to use the default publisher.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRapidLaunch(Assembly.GetExecutingAssembly());

        // Continue setup below
    }
}
```

The method also accepts params of Assemblies to register from if you need to add handlers and profiles from multiple assemblies.

```csharp
builder.Services.AddRapidLaunch(Assembly.Load("FirstProject"), Assembly.Load("SecondProject"));
```

### Registering A Different Publisher

By default, RapidLaunch will automatically register the standard domain event publisher.

If you would like to use a different publisher, simply pass the type of the customer publisher to the registration method.

Your customer publisher must inherit from the [IPublishingBus](https://github.com/mjbradvica/RapidLaunch/blob/master/source/RapidLaunch/Common/IPublishingBus.cs) interface.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRapidLaunch<MyCustomPublisher>(Assembly.GetExecutingAssembly());

        // Continue setup below
    }
}
```

> See the detailed section for more information on using a customer publisher.

## Defining Persistence Models

### Quick Start for Defining Persistence Models

All models you wish to designate for persistence must originate from the [IAggregateRoot](https://github.com/mjbradvica/ClearDomain/blob/master/source/ClearDomain/Common/IAggregateRoot.cs) interface.

We recommend utilizing the [AggregateRoot](https://github.com/mjbradvica/ClearDomain/blob/master/source/ClearDomain/Common/AggregateRoot.cs) base class using the namespace (Guid, Int, Long, or String) of your choosing.

```csharp
using ClearDomain.GuidPrimary;

public class MyModel : AggregateRoot
{
    // Id will be of type Guid.
}
```

> Note: The namespace indicates the type of the identifier. This paradigm will repeat itself when you choose which base repository to inherit from.

Create the interface for each persistence model you wish to utilize:

```csharp
public interface IMyModelRepository
{
}
```

Inherit from each interface you wish to have implemented. Make sure to import from the same namespace as your identifier.

```csharp
using RapidLaunch.GuidPrimary;

public interface IMyModelRepository :
    IAddEntityAsync<MyModel>,
    IGetByIdAsync<MyModel>,
    IDeleteEntityAsync<MyModel>
{
}
```

> RapidLaunch supports both synchronous and asynchronous versions of each method.

Why does RapidLaunch make you inherit each interface individually?

RapidLaunch purposely forces you to inherit individual interfaces to force [interface segregation](https://en.wikipedia.org/wiki/Interface_segregation_principle). Your persistence methods should only implement what you want, not give clients the burden of methods they will never use. Interface Segregation is a core tenant of [SOLID](https://en.wikipedia.org/wiki/SOLID), and will transform your application for the better.

### Defining Default DomainEvent Handlers

> This section only applies if you are utilizing the default domain event publisher.

For each domain event, create a handler that inherits from the [IDomainEventHandler](https://github.com/mjbradvica/RapidLaunch/blob/master/source/RapidLaunch/Common/IDomainEventHandler.cs) interface.

Assuming you have a domain event like so:

```csharp
public class MyDomainEvent : IDomainEvent
{
    // properties in here.
}
```

```csharp
public class MyEventHandler : IDomainEventHandler<MyDomainEvent>
{
    Task HandleDomainEvent(MyDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        // implement necessary logic.
    }
}
```

## Defining Data Access

### Quick Start for Defining Data Access for Entity Framework

### Quick Start for Defining Data Access for ADO.NET

### Quick Start for Defining Data Access for MongoDB
