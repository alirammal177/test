# Contributing to QAInsight

Thank you for your interest in contributing to QAInsight! This document provides guidelines and instructions for contributing to the project.

## Getting Started

1. Fork the repository
2. Clone your fork:

```bash
git clone https://github.com/yourusername/QAInsight.git
cd QAInsight
```

3. Install prerequisites:

- .NET 8.0 SDK
- Docker Desktop
- Visual Studio 2022 or VS Code with C# extension

4. Build the solution:

```bash
dotnet restore
dotnet build
```

5. Run tests:

```bash
dotnet test
```

## Development Workflow

1. Create a feature branch:

```bash
git checkout -b feature/your-feature-name
```

2. Make your changes
3. Run code formatting:

```bash
dotnet format
```

4. Run tests and ensure all pass
5. Commit your changes:

```bash
git commit -m "feat: your feature description"
```

6. Push to your fork and create a pull request

## Creating Plugins

QAInsight supports plugins for extending functionality. Here's how to create one:

1. Create a new class library project:

```bash
dotnet new classlib -n QAInsight.Plugins.YourPlugin
```

2. Add references:

```xml
<ItemGroup>
    <ProjectReference Include="..\QAInsight.Domain\QAInsight.Domain.csproj" />
</ItemGroup>
```

3. Implement the plugin interface:

```csharp
public class YourPlugin : ICodeAnalysisPlugin
{
    public string Name => "Your Plugin Name";
    public string Description => "Description of your plugin";
    public string Author => "Your Name";
    public string Version => "1.0.0";

    // Implement other interface members
}
```

4. Build and copy to plugins directory:

```bash
dotnet publish -o ../QAInsight.Web/plugins/YourPlugin
```

## Plugin Development Guidelines

1. Keep plugins focused and single-purpose
2. Include comprehensive XML documentation
3. Add unit tests for your plugin
4. Follow the existing code style
5. Handle errors gracefully
6. Log important operations
7. Support cancellation tokens
8. Include a README.md for your plugin

## Creating Workflow Steps

1. Implement IWorkflowStepHandler:

```csharp
public class YourStepHandler : IWorkflowStepHandler
{
    public string StepType => "your-step-type";

    public async Task<StepResult> ExecuteAsync(
        StepContext context,
        CancellationToken cancellationToken = default)
    {
        // Implement your step logic
    }
}
```

2. Register in DI:

```csharp
services.AddScoped<IWorkflowStepHandler, YourStepHandler>();
```

## Testing

1. Unit Tests:

- Test each component in isolation
- Use Moq for mocking dependencies
- Follow Arrange-Act-Assert pattern

2. Integration Tests:

- Test workflows end-to-end
- Use test data from samples/
- Test plugin loading and execution

3. UI Tests:

- Test Blazor components using bunit
- Test API endpoints using WebApplicationFactory

## Documentation

1. XML Documentation:

- Document all public APIs
- Include examples where appropriate
- Explain complex algorithms

2. README Updates:

- Update for new features
- Keep setup instructions current
- Document breaking changes

## Code Style

1. Follow C# conventions
2. Use meaningful names
3. Keep methods focused
4. Add comments for complex logic
5. Use dependency injection
6. Handle exceptions appropriately

## Pull Request Process

1. Update documentation
2. Add/update tests
3. Follow commit message convention
4. Ensure CI passes
5. Request review from maintainers
6. Address review feedback

## Getting Help

- Check existing issues
- Join discussions
- Ask questions in pull requests
- Contact maintainers

Thank you for contributing to QAInsight!
