namespace Mu;

public static partial class ResultExtensions
{
    public static async Task<Result<T>> Then<T>(this Task<Result<T>> result, Func<T, Task> success)
        where T : notnull
    {
        Result<T> value = await result.ConfigureAwait(false);

        return await value
            .When(success: success)
            .ConfigureAwait(false);
    }
}