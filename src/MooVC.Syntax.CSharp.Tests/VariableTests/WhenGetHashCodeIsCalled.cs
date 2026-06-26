namespace MooVC.Syntax.CSharp.VariableTests;

public sealed class WhenGetHashCodeIsCalled
{
    private static readonly Faker generator = new();

    [Test]
    public async Task GivenDifferentValueThenHashesAreNotEqual()
    {
        // Arrange
        string[] words = generator
            .Random
            .WordsArray(100)
            .Distinct()
            .OrderBy(_ => Random.Shared.Next())
            .ToArray();

        var firstMember = new Variable(words[0]);
        var secondMember = new Variable(words[^1]);

        // Act
        int firstHash = firstMember.GetHashCode();
        int secondHash = secondMember.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }

    [Test]
    public async Task GivenSameInstanceWhenCalledTwiceThenHashIsStable()
    {
        // Arrange
        string value = generator.Lorem.Word();
        var subject = new Variable(value);

        // Act
        int first = subject.GetHashCode();
        int second = subject.GetHashCode();

        // Assert
        _ = await Assert.That(first).IsEqualTo(second);
    }

    [Test]
    public async Task GivenSameValueWhenInstantiatedTwiceThenHashesAreEqual()
    {
        // Arrange
        string value = generator.Lorem.Word();
        var first = new Variable(value);
        var second = new Variable(value);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }
}