namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenToStringIsCalled
{
    public static IEnumerable<(Scope Scope, string Expected)> GivenScopeThenLiteralValueReturnedData()
    {
        yield return (Scope.File, "file");
        yield return (Scope.Internal, "internal");
        yield return (Scope.Public, "public");
        yield return (Scope.Private, "private");
        yield return (Scope.Private + Scope.Protected, "private protected");
        yield return (Scope.Protected, "protected");
        yield return (Scope.Protected + Scope.Internal, "protected internal");
        yield return (Scope.Unspecified, string.Empty);
    }

    [Test]
    [MethodDataSource(nameof(GivenScopeThenLiteralValueReturnedData))]
    public async Task GivenScopeThenLiteralValueReturned(Scope subject, string expected)
    {
        // Act
        string representation = subject.ToString();

        // Assert
        _ = await Assert.That(representation).IsEqualTo(expected);
    }
}