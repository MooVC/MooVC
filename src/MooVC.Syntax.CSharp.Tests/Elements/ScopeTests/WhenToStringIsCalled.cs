namespace MooVC.Syntax.CSharp.Elements.ScopeTests;

public sealed class WhenToStringIsCalled
{
    public static TheoryData<Scope, string> Data => new()
    {
        { Scope.File, "file" },
        { Scope.Internal, "internal" },
        { Scope.Public, "public" },
        { Scope.Private, "private" },
        { Scope.Private + Scope.Protected, "private protected" },
        { Scope.Protected, "protected" },
        { Scope.Protected + Scope.Internal, "protected internal" },
        { Scope.Unspecified, string.Empty },
    };

    [Theory]
    [MemberData(nameof(Data))]
    public void GivenScopeThenLiteralValueReturned(Scope subject, string expected)
    {
        // Act
        string representation = subject.ToString();

        // Assert
        representation.ShouldBe(expected);
    }
}