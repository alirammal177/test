# QAInsight Local Development Guide

## Prerequisites

- .NET 8.0 SDK
- Docker Desktop
- Visual Studio 2022 or VS Code with C# extension
- Git

## Getting Started

1. Clone the repository:

```bash
git clone https://github.com/yourusername/QAInsight.git
cd QAInsight
```

2. Set up environment variables:
   Create a `.env` file in the root directory with:

```env
AI_API_KEY=your-openai-api-key
AI_BASE_URL=https://api.openai.com/v1
```

3. Start the development environment:

```bash
docker-compose up -d seq
dotnet run --project QAInsight.Web
```

Or using Visual Studio:

- Open `QAInsight.sln`
- Set `QAInsight.Web` as the startup project
- Press F5 to run

## Development Environment

- Web UI: https://localhost:5001
- Seq Dashboard: http://localhost:5341
- Swagger API: https://localhost:5001/swagger

## Testing Sample Code

1. Navigate to the `/samples` directory
2. Use the sample code files for testing:
   - `LongMethod.cs`: Example of code with high complexity
   - `DeadCode.cs`: Example with unused methods
   - `DuplicateCode.cs`: Example of code duplication

## Running Tests

```bash
dotnet test
```

For test coverage:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Debugging Tips

1. Enable Seq logging:

   - Set `Logging__EnableSeq=true` in environment variables
   - View logs at http://localhost:5341

2. Application Insights:

   - Set `Logging__EnableApplicationInsights=true`
   - Add your Application Insights key

3. Common Issues:
   - Port conflicts: Check if ports 5000/5001 are in use
   - Docker issues: Ensure Docker Desktop is running
   - AI API issues: Verify API key and rate limits

## Project Structure

```
QAInsight/
├── QAInsight.Web/           # Blazor + API endpoints
├── QAInsight.Application/   # Application logic, CQRS
├── QAInsight.Domain/        # Domain entities and interfaces
├── QAInsight.Infrastructure/# External services, Roslyn
├── QAInsight.Tests.Unit/    # Unit tests
├── QAInsight.Tests.Integration/# Integration tests
└── samples/                 # Sample code for testing
```

## Contributing

1. Create a feature branch
2. Make changes
3. Run tests and format check:

```bash
dotnet format
dotnet test
```

4. Create a pull request

## Support

For issues or questions:

1. Check the GitHub issues
2. Review logs in Seq
3. Contact the development team
