namespace Mu;

public static partial class ResultExtensions
{
    public static async Task<Result<TResult>> Select<T, TResult>(this Task<Result<T>> result, Func<T, TResult> success)
        where T : notnull
        where TResult : notnull
    {
        Result<T> value = await result.ConfigureAwait(false);

        return value.Select(success);
    }

    public static async Task<Result<TResult>> Select<T, TResult>(this Task<Result<T>> result, Func<T, Task<TResult>> success)
        where T : notnull
        where TResult : notnull
    {
        Result<T> value = await result.ConfigureAwait(false);

        return await value
            .Select(success)
            .ConfigureAwait(false);
    }
}