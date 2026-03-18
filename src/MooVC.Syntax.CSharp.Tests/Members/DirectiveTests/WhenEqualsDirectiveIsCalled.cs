namespace MooVC.Syntax.CSharp.Members.DirectiveTests;

using MooVC.Syntax.Elements;
using Identifier = MooVC.Syntax.Elements.Identifier;

public sealed class WhenEqualsDirectiveIsCalled
{
    private const string AlternativeAlias = "Other";
    private const string Alias = "Alias";

    [Test]
    public async Task GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Directive? left = default;
        Directive? right = default;

        // Act
        bool result = left?.Equals(right) ?? (right is null);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Directive? left = default;
        Directive right = Create();

        // Act
        bool result = left?.Equals(right) ?? false;

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenLeftValueRightNullThenReturnsFalse()
    {
        // Arrange
        Directive left = Create();
        Directive? right = default;

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenSameReferenceThenReturnsTrue()
    {
        // Arrange
        Directive first = Create();
        Directive second = first;

        // Act
        bool result = first.Equals(second);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create();

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsTrue();
    }

    [Test]
    public async Task GivenDifferentAliasesThenReturnsFalse()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create(alias: AlternativeAlias);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentQualifiersThenReturnsFalse()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create(qualifier: new Qualifier(["MooVC", "Alternate"]));

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    [Test]
    public async Task GivenDifferentStaticStatesThenReturnsFalse()
    {
        // Arrange
        Directive left = Create();
        Directive right = Create(isStatic: true);

        // Act
        bool result = left.Equals(right);

        // Assert
        _ = await Assert.That(result).IsFalse();
    }

    private static Directive Create(string alias = Alias, Qualifier? qualifier = default, bool isStatic = false)
    {
        return new Directive
        {
            Alias = alias,
            IsStatic = isStatic,
            Qualifier = qualifier ?? new Qualifier(["MooVC", "Syntax"]),
        };
    }
}