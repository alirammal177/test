using System;

namespace QAInsight.Application.Common;

public class QAInsightException : Exception
{
    public string ErrorCode { get; }

    public QAInsightException(string message) : base(message)
    {
        ErrorCode = "QA001";
    }

    public QAInsightException(string message, string errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }

    public QAInsightException(string message, string errorCode, Exception innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
    }

    public static class ErrorCodes
    {
        public const string GeneralError = "QA001";
        public const string InvalidConfiguration = "QA002";
        public const string AIServiceError = "QA003";
        public const string CodeAnalysisError = "QA004";
        public const string RefactoringError = "QA005";
        public const string TestGenerationError = "QA006";
        public const string DocumentationError = "QA007";
        public const string ValidationError = "QA008";
        public const string FileSystemError = "QA009";
        public const string GitError = "QA010";
    }
}