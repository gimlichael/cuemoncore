﻿---
uid: Cuemon.Extensions.AspNetCore.Http.Throttling
summary: *content
---
The Cuemon.Extensions.AspNetCore.Http.Throttling namespace contains both types and extension methods that complements the Cuemon.AspNetCore.Http.Throttling namespace. Provides an in-memory implementation of a throttling cache for ASP.NET Core.

Availability: NET Standard 2.0, NET Core 3.0, .NET 5.0

Complements: [Cuemon.AspNetCore.Http.Throttling namespace](https://docs.cuemon.net/api/aspnet/Cuemon.AspNetCore.Http.Throttling.html) 🔗

## Github branches 🖇️

[development](https://github.com/gimlichael/Cuemon/tree/development/src/Cuemon.Extensions.AspNetCore/Http/Throttling) 🧪\
[release](https://github.com/gimlichael/Cuemon/tree/release/src/Cuemon.Extensions.AspNetCore/Http/Throttling) 🎬\
[master](https://github.com/gimlichael/Cuemon/tree/master/src/Cuemon.Extensions.AspNetCore/Http/Throttling) 🛡️

## NuGet packages

📦 Focus Pack\
[Cuemon.Extensions.AspNetCore (CI)](https://nuget.cuemon.net/packages/Cuemon.Extensions.AspNetCore)\
[Cuemon.Extensions.AspNetCore (Stable and Preview)](https://www.nuget.org/packages/Cuemon.Extensions.AspNetCore)\
![NuGet Version](https://img.shields.io/nuget/v/Cuemon.Extensions.AspNetCore?logo=nuget) ![NuGet Preview Version](https://img.shields.io/nuget/vpre/Cuemon.Extensions.AspNetCore?logo=nuget) ![NuGet Downloads](https://img.shields.io/nuget/dt/Cuemon.Extensions.AspNetCore?color=blueviolet&logo=nuget)
\
\
🏭 Productivity Pack\
[Cuemon.AspNetCore.App (CI)](https://nuget.cuemon.net/packages/Cuemon.AspNetCore.App)\
[Cuemon.AspNetCore.App (Stable and Preview)](https://www.nuget.org/packages/Cuemon.AspNetCore.App)\
![NuGet Version](https://img.shields.io/nuget/v/Cuemon.AspNetCore.App?logo=nuget) ![NuGet Preview Version](https://img.shields.io/nuget/vpre/Cuemon.AspNetCore.App?logo=nuget) ![NuGet Downloads](https://img.shields.io/nuget/dt/Cuemon.AspNetCore.App?color=blueviolet&logo=nuget)

### Extension Methods

|Type|Ext|Methods|
|--:|:-:|---|
|IServiceCollection|⬇️|`AddThrottlingCache{T}`, `AddMemoryThrottlingCache`|