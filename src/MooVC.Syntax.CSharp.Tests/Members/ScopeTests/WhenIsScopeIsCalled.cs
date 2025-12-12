namespace MooVC.Syntax.CSharp.Members.ScopeTests;

using System;
using System.Collections.Generic;

public sealed class WhenIsScopeIsCalled
{
    public static IEnumerable<object[]> MatchingData =>
    [
        [Scope.File, (Func<Scope, bool>)(scope => scope.IsFile)],
        [Scope.Internal, (Func<Scope, bool>)(scope => scope.IsInternal)],
        [Scope.Public, (Func<Scope, bool>)(scope => scope.IsPublic)],
        [Scope.Private, (Func<Scope, bool>)(scope => scope.IsPrivate)],
        [Scope.PrivateProtected, (Func<Scope, bool>)(scope => scope.IsPrivateProtected)],
        [Scope.Protected, (Func<Scope, bool>)(scope => scope.IsProtected)],
        [Scope.ProtectedInternal, (Func<Scope, bool>)(scope => scope.IsProtectedInternal)],
        [Scope.Unspecified, (Func<Scope, bool>)(scope => scope.IsUnspecified)],
    ];

    public static IEnumerable<object[]> NonMatchingData =>
    [
        [(Func<Scope, bool>)(scope => scope.IsFile)],
        [(Func<Scope, bool>)(scope => scope.IsInternal)],
        [(Func<Scope, bool>)(scope => scope.IsPublic)],
        [(Func<Scope, bool>)(scope => scope.IsPrivate)],
        [(Func<Scope, bool>)(scope => scope.IsPrivateProtected)],
        [(Func<Scope, bool>)(scope => scope.IsProtected)],
        [(Func<Scope, bool>)(scope => scope.IsProtectedInternal)],
    ];

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