namespace MooVC.Syntax.CSharp.ScopesTests;

public sealed class WhenToStringIsCalled
{
    public static IEnumerable<(Scopes Scope, string Expected)> GivenScopeThenLiteralValueReturnedData()
    {
        yield return (Scopes.File, "file");
        yield return (Scopes.Internal, "internal");
        yield return (Scopes.Public, "public");
        yield return (Scopes.Private, "private");
        yield return (Scopes.Private + Scopes.Protected, "private protected");
        yield return (Scopes.Protected, "protected");
        yield return (Scopes.Protected + Scopes.Internal, "protected internal");
        yield return (Scopes.Unspecified, string.Empty);
    }

    [Test]
    [MethodDataSource(nameof(GivenScopeThenLiteralValueReturnedData))]
    public async Task GivenScopeThenLiteralValueReturned(Scopes subject, string expected)
    {
        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}