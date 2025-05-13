# QAInsight

QAInsight is an AI-powered quality assurance assistant for legacy codebases. It helps developers analyze, refactor, test, and document their code using advanced static analysis and generative AI techniques.

## 🎯 Features

- **Static Code Analysis**: Leverages Roslyn to detect code smells and quality issues
- **AI-Powered Refactoring**: Suggests intelligent code improvements with explanations
- **Automated Test Generation**: Creates unit tests for untested code paths
- **Documentation Generation**: Produces comprehensive documentation in XML and Markdown
- **Modern Web Interface**: Clean UI for code analysis and refactoring workflows
- **REST API**: Programmatic access to all features

## 🏗️ Architecture

QAInsight follows Clean Architecture principles with these layers:

- **Domain**: Core business logic and entities
- **Application**: Use cases and service interfaces
- **Infrastructure**: External integrations and implementations
- **Web**: API endpoints and Blazor UI

## 🚀 Getting Started

### Prerequisites

- .NET 8 SDK
- Node.js (for web UI development)
- Git

### Installation

1. Clone the repository:

```bash
git clone https://github.com/yourusername/QAInsight.git
cd QAInsight
```

2. Build the solution:

```bash
dotnet build
```

3. Run the web application:

```bash
cd QAInsight.Web
dotnet run
```

4. Access the web interface at `https://localhost:5001`

## 🔧 Configuration

Configure the application in `appsettings.json`:

```json
{
  "AIProvider": {
    "Type": "CursorAgent", // or "OpenAI"
    "ApiKey": "your-api-key"
  },
  "Analysis": {
    "MaxFileSize": 1048576, // 1MB
    "ExcludePatterns": ["bin/*", "obj/*"]
  }
}
```

## 🧪 Testing

Run the test suite:

```bash
dotnet test
```

## 📚 API Documentation

Access the Swagger UI at `https://localhost:5001/swagger`

Key endpoints:

- `POST /api/analyze`: Analyze a codebase
- `POST /api/refactor`: Get refactoring suggestions
- `POST /api/tests/generate`: Generate unit tests
- `POST /api/docs/generate`: Generate documentation

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- [Roslyn](https://github.com/dotnet/roslyn) - The .NET Compiler Platform
- [Cursor](https://cursor.sh) - AI-powered code editor
- [OpenAI](https://openai.com) - GPT models for code analysis
