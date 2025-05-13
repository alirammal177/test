using System;
using System.Collections.Generic;
using System.Linq;
using QAInsight.Domain.Entities;
using QAInsight.Domain.ValueObjects;

namespace QAInsight.Application.Common;

public static class Validator
{
    public static void ValidateCodeBase(CodeBase codeBase)
    {
        if (codeBase == null)
            throw new QAInsightException("CodeBase cannot be null", QAInsightException.ErrorCodes.ValidationError);

        if (string.IsNullOrWhiteSpace(codeBase.Name))
            throw new QAInsightException("CodeBase name cannot be empty", QAInsightException.ErrorCodes.ValidationError);

        if (string.IsNullOrWhiteSpace(codeBase.LocalPath) && string.IsNullOrWhiteSpace(codeBase.RepositoryUrl))
            throw new QAInsightException("Either LocalPath or RepositoryUrl must be specified", QAInsightException.ErrorCodes.ValidationError);
    }

    public static void ValidateCodeIssue(CodeIssue codeIssue)
    {
        if (codeIssue == null)
            throw new QAInsightException("CodeIssue cannot be null", QAInsightException.ErrorCodes.ValidationError);

        if (string.IsNullOrWhiteSpace(codeIssue.FilePath))
            throw new QAInsightException("FilePath cannot be empty", QAInsightException.ErrorCodes.ValidationError);

        if (codeIssue.StartLine < 1 || codeIssue.EndLine < codeIssue.StartLine)
            throw new QAInsightException("Invalid line numbers", QAInsightException.ErrorCodes.ValidationError);
    }

    public static void ValidateRefactorSuggestion(RefactorSuggestion suggestion)
    {
        if (suggestion == null)
            throw new QAInsightException("RefactorSuggestion cannot be null", QAInsightException.ErrorCodes.ValidationError);

        if (string.IsNullOrWhiteSpace(suggestion.Title))
            throw new QAInsightException("Title cannot be empty", QAInsightException.ErrorCodes.ValidationError);

        if (string.IsNullOrWhiteSpace(suggestion.OriginalCode) || string.IsNullOrWhiteSpace(suggestion.RefactoredCode))
            throw new QAInsightException("Both original and refactored code must be specified", QAInsightException.ErrorCodes.ValidationError);
    }

    public static void ValidateTestCase(TestCase testCase)
    {
        if (testCase == null)
            throw new QAInsightException("TestCase cannot be null", QAInsightException.ErrorCodes.ValidationError);

        if (string.IsNullOrWhiteSpace(testCase.Name))
            throw new QAInsightException("Name cannot be empty", QAInsightException.ErrorCodes.ValidationError);

        if (string.IsNullOrWhiteSpace(testCase.MethodUnderTest))
            throw new QAInsightException("MethodUnderTest cannot be empty", QAInsightException.ErrorCodes.ValidationError);
    }

    public static void ValidateDocumentationBlock(DocumentationBlock block)
    {
        if (block == null)
            throw new QAInsightException("DocumentationBlock cannot be null", QAInsightException.ErrorCodes.ValidationError);

        if (string.IsNullOrWhiteSpace(block.Title))
            throw new QAInsightException("Title cannot be empty", QAInsightException.ErrorCodes.ValidationError);

        if (string.IsNullOrWhiteSpace(block.Content))
            throw new QAInsightException("Content cannot be empty", QAInsightException.ErrorCodes.ValidationError);
    }
}