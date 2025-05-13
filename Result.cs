using System.Collections.Generic;

namespace QAInsight.Application.Common;

public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string? Error { get; }
    public string? ErrorCode { get; }
    public List<string> Warnings { get; } = new();

    private Result(bool isSuccess, T? value, string? error = null, string? errorCode = null)
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
        ErrorCode = errorCode;
    }

    public static Result<T> Success(T value) => new(true, value);

    public static Result<T> Failure(string error, string errorCode = QAInsightException.ErrorCodes.GeneralError)
        => new(false, default, error, errorCode);

    public Result<T> AddWarning(string warning)
    {
        Warnings.Add(warning);
        return this;
    }

    public Result<TNew> Map<TNew>(System.Func<T, TNew> mapper)
        where TNew : class
    {
        if (!IsSuccess)
            return Result<TNew>.Failure(Error!, ErrorCode);

        return Result<TNew>.Success(mapper(Value!));
    }
}