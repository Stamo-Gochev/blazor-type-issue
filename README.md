# blazor-type-issue

Related to https://github.com/dotnet/aspnetcore/issues/37871

### Describe the bug
Blazor wasm project reports an incorrect variable type. The type is correctly reported for blazor server (.NET 5.0 and .NET 6.0) as well as blazor wasm .NET 5.0 apps, but not for blazor wasm .NET 6.0 project.

### To Reproduce

A repository that reproduces the issue can be found at:
https://github.com/Stamo-Gochev/blazor-type-issue

It contains a [component](https://github.com/Stamo-Gochev/blazor-type-issue/blob/master/BlazorTypeIssue/RazorClassLibrary1/Component1.razor.cs) in a [razor class library](https://github.com/Stamo-Gochev/blazor-type-issue/tree/master/BlazorTypeIssue/RazorClassLibrary1) that is used by all project types to compare the output. 

The component uses a [generic argument](https://github.com/Stamo-Gochev/blazor-type-issue/blob/master/BlazorTypeIssue/RazorClassLibrary1/Component1.razor.cs#L16-L23) for its `Data` parameter and checks if the type of it is contained in a [list of predefined types](https://github.com/Stamo-Gochev/blazor-type-issue/blob/master/BlazorTypeIssue/RazorClassLibrary1/Component1.razor.cs#L25-L41) and renders the [result](https://github.com/Stamo-Gochev/blazor-type-issue/blob/4654c39b67a84b6457c872dc4a63659892328f58/BlazorTypeIssue/RazorClassLibrary1/Component1.razor#L13).

Steps to reproduce:
1. Clone the repo
2. Run the [BlazorWasmAppNet60](https://github.com/Stamo-Gochev/blazor-type-issue/tree/master/BlazorTypeIssue/BlazorWasmAppNet60) project
3. Open the [Index.razor](https://github.com/Stamo-Gochev/blazor-type-issue/blob/master/BlazorTypeIssue/BlazorWasmAppNet60/Client/Pages/Index.razor#L5) page and observe its output.

> **Note:** The repo also contains [tests projects](https://github.com/Stamo-Gochev/blazor-type-issue/tree/master/BlazorTypeIssue) for blazor server .NET 5.0 and .NET 6.0 apps as well as a blazor wasm .NET 5.0 app. You can use them to compare the output by looking at their `/Pages/Index.razor` file. 

### Expected behavior
The [Index.razor](https://github.com/Stamo-Gochev/blazor-type-issue/blob/master/BlazorTypeIssue/BlazorWasmAppNet60/Client/Pages/Index.razor) page is expected to print:

> BlazorWasmAppNet60
item has predefined type: True

This is also the output for **all** other project types - blazor server .NET 5.0, blazor server .NET 6.0 and blazor wasm .NET 5.0.

> BlazorServerAppNet50
item has predefined type: True

> BlazorServerAppNet60
item has predefined type: True

> BlazorWasmAppNet50
item has predefined type: True

### Actual behavior
The [Index.razor](https://github.com/Stamo-Gochev/blazor-type-issue/blob/master/BlazorTypeIssue/BlazorWasmAppNet60/Client/Pages/Index.razor) page returns:

> BlazorWasmAppNet60
item has predefined type: False <- this should be True as in all other projects

### Further technical details
- ASP.NET Core version - .NET 6.0 RC 2
- Visual Studio 2022 Preview 7
- Include the output of `dotnet --info`:

