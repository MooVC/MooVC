namespace Mu;

using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

public record Result<T>
    where T : notnull
{
    private Result(T value)
        : this([], true, value)
    {
    }

    private Result(params IEnumerable<ValidationResult> failures)
        : this([.. failures], false, default)
    {
        if (Failures.Length == 0)
        {
            throw new ArgumentException("At least one failure must be provided for an unsuccessful result.", nameof(failures));
        }
    }

    [JsonConstructor]
    private Result(ImmutableArray<ValidationResult> failures, bool isSuccessful, T? value)
    {
        Failures = failures;
        IsSuccessful = isSuccessful;
        Value = value;
    }

    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccessful { get; }

    public ImmutableArray<ValidationResult> Failures => IsSuccessful
        ? throw new InvalidOperationException("There are no failures associated with a successful result.")
        : field;

    public T? Value => IsSuccessful
        ? field
        : throw new InvalidOperationException("There is no value associated with an unsuccessful result.");

    public static implicit operator Result<T>(T value)
    {
        return new(value);
    }

    public static implicit operator Result<T>(ValidationResult failure)
    {
        return new(failure);
    }

    public static implicit operator Result<T>(ImmutableArray<ValidationResult> failures)
    {
        return new(failures, false, default);
    }

    public Result<T> When(Action<ImmutableArray<ValidationResult>>? failure = default, Action<T>? success = default)
    {
        failure ??= _ => { };
        success ??= _ => { };

        if (IsSuccessful)
        {
            success(Value);
        }
        else
        {
            failure(Failures);
        }

        return this;
    }

    public async Task<Result<T>> When(Func<ImmutableArray<ValidationResult>, Task>? failure = default, Func<T, Task>? success = default)
    {
        failure ??= _ => Task.CompletedTask;
        success ??= _ => Task.CompletedTask;

        Task action = IsSuccessful
            ? success(Value)
            : failure(Failures);

        await action.ConfigureAwait(false);

        return this;
    }

    public Result<TResult> Select<TResult>(Func<T, TResult> success)
        where TResult : notnull
    {
        ArgumentNullException.ThrowIfNull(success);

        if (IsSuccessful)
        {
            return success(Value);
        }

        return Failures;
    }

    public async Task<Result<TResult>> Select<TResult>(Func<T, Task<TResult>> success)
        where TResult : notnull
    {
        ArgumentNullException.ThrowIfNull(success);

        if (IsSuccessful)
        {
            return await success(Value)
                .ConfigureAwait(false);
        }

        return Failures;
    }

    public TResult Select<TResult>(Func<ImmutableArray<ValidationResult>, TResult> failure, Func<T, TResult> success)
    {
        ArgumentNullException.ThrowIfNull(success);
        ArgumentNullException.ThrowIfNull(failure);

        return IsSuccessful
            ? success(Value)
            : failure(Failures);
    }

    public Task<TResult> Select<TResult>(Func<ImmutableArray<ValidationResult>, Task<TResult>> failure, Func<T, Task<TResult>> success)
    {
        ArgumentNullException.ThrowIfNull(success);
        ArgumentNullException.ThrowIfNull(failure);

        return IsSuccessful
            ? success(Value)
            : failure(Failures);
    }
}