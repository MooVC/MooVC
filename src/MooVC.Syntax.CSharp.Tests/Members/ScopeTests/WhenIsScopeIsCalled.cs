namespace MooVC.Syntax.CSharp.Members.ScopeTests;

using System;
using System.Collections.Generic;

public sealed class WhenIsScopeIsCalled
{
    public static IEnumerable<object[]> MatchingData => new[]
    {
        new object[] { Scope.File, (Func<Scope, bool>)(scope => scope.IsFile) },
        new object[] { Scope.Internal, (Func<Scope, bool>)(scope => scope.IsInternal) },
        new object[] { Scope.Public, (Func<Scope, bool>)(scope => scope.IsPublic) },
        new object[] { Scope.Private, (Func<Scope, bool>)(scope => scope.IsPrivate) },
        new object[] { Scope.PrivateProtected, (Func<Scope, bool>)(scope => scope.IsPrivateProtected) },
        new object[] { Scope.Protected, (Func<Scope, bool>)(scope => scope.IsProtected) },
        new object[] { Scope.ProtectedInternal, (Func<Scope, bool>)(scope => scope.IsProtectedInternal) },
        new object[] { Scope.Unspecified, (Func<Scope, bool>)(scope => scope.IsUnspecified) },
    };

    public static IEnumerable<object[]> NonMatchingData => new[]
    {
        new object[] { (Func<Scope, bool>)(scope => scope.IsFile) },
        new object[] { (Func<Scope, bool>)(scope => scope.IsInternal) },
        new object[] { (Func<Scope, bool>)(scope => scope.IsPublic) },
        new object[] { (Func<Scope, bool>)(scope => scope.IsPrivate) },
        new object[] { (Func<Scope, bool>)(scope => scope.IsPrivateProtected) },
        new object[] { (Func<Scope, bool>)(scope => scope.IsProtected) },
        new object[] { (Func<Scope, bool>)(scope => scope.IsProtectedInternal) },
    };

    [Theory]
    [MemberData(nameof(MatchingData))]
    public void GivenMatchingScopeThenPredicateReturnsTrue(Scope subject, Func<Scope, bool> predicate)
    {
        // Act
        bool result = predicate(subject);

        // Assert
        result.ShouldBeTrue();
    }

    [Theory]
    [MemberData(nameof(NonMatchingData))]
    public void GivenUnspecifiedScopeThenPredicateReturnsFalse(Func<Scope, bool> predicate)
    {
        // Act
        bool result = predicate(Scope.Unspecified);

        // Assert
        result.ShouldBeFalse();
    }
}
