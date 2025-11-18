namespace MooVC.Syntax.CSharp.Members.ScopeTests;

using System.Collections.Generic;

public sealed class WhenToStringIsCalled
{
    public static IEnumerable<object[]> Data => new[]
    {
        new object[] { Scope.File, "file" },
        new object[] { Scope.Internal, "internal" },
        new object[] { Scope.Public, "public" },
        new object[] { Scope.Private, "private" },
        new object[] { Scope.PrivateProtected, "private protected" },
        new object[] { Scope.Protected, "protected" },
        new object[] { Scope.ProtectedInternal, "protected internal" },
        new object[] { Scope.Unspecified, string.Empty },
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
