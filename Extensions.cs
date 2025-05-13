using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QAInsight.Domain.Entities;
using QAInsight.Domain.Enums;
using QAInsight.Domain.ValueObjects;

namespace QAInsight.Application.Common;

public static class Extensions
{
    public static async Task<Result<T>> ToResultAsync<T>(this Task<T> task, string errorMessage = "Operation failed")
    {
        try
        {
            var result = await task;
            return Result<T>.Success(result);
        }
        catch (QAInsightException ex)
        {
            return Result<T>.Failure(ex.Message, ex.ErrorCode);
        }
        catch (Exception ex)
        {
            return Result<T>.Failure(errorMessage + ": " + ex.Message);
        }
    }

    public static Result<T> ToResult<T>(this T value, string errorMessage = "Operation failed")
    {
        if (value == null)
            return Result<T>.Failure(errorMessage);

        return Result<T>.Success(value);
    }

    public static IEnumerable<CodeIssue> FilterBySmellType(this IEnumerable<CodeIssue> issues, params SmellType[] smellTypes)
    {
        return issues.Where(i => smellTypes.Contains(i.Type));
    }

    public static IEnumerable<CodeIssue> FilterBySeverity(this IEnumerable<CodeIssue> issues, params Severity[] severities)
    {
        return issues.Where(i => severities.Contains(i.Severity));
    }

    public static IEnumerable<CodeIssue> FilterByConfidence(this IEnumerable<CodeIssue> issues, double minConfidence)
    {
        return issues.Where(i => i.Confidence >= minConfidence);
    }

    public static IEnumerable<RefactorSuggestion> FilterByConfidence(this IEnumerable<RefactorSuggestion> suggestions, double minConfidence)
    {
        return suggestions.Where(s => s.Confidence >= minConfidence);
    }

    public static async Task<IEnumerable<T>> WhenAllAsync<T>(this IEnumerable<Task<T>> tasks)
    {
        return await Task.WhenAll(tasks);
    }

    public static string ToErrorCode(this Exception ex)
    {
        return ex switch
        {
            QAInsightException qae => qae.ErrorCode,
            ArgumentException => QAInsightException.ErrorCodes.ValidationError,
            InvalidOperationException => QAInsightException.ErrorCodes.ValidationError,
            _ => QAInsightException.ErrorCodes.GeneralError
        };
    }
}