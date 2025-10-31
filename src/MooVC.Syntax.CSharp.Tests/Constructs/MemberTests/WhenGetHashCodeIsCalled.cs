namespace MooVC.Syntax.CSharp.Constructs.MemberTests;

public sealed class WhenGetHashCodeIsCalled
{
    private static readonly Faker generator = new();

    [Fact]
    public void GivenSameValueWhenInstantiatedTwiceThenHashesAreEqual()
    {
        // Arrange
        string value = generator.Lorem.Word();
        var first = new Member(value);
        var second = new Member(value);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Fact]
    public void GivenDifferentValueThenHashesAreNotEqual()
    {
        // Arrange
        IEnumerable<string> words = generator.Lorem
            .Words()
            .Distinct();

        IEnumerable<string> values = generator.PickRandom(words, 2);
        var firstMember = new Member(values.First());
        var secondMember = new Member(values.Last());

        // Act
        int firstHash = firstMember.GetHashCode();
        int secondHash = secondMember.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }

    [Fact]
    public void GivenSameInstanceWhenCalledTwiceThenHashIsStable()
    {
        // Arrange
        string value = generator.Lorem.Word();
        var subject = new Member(value);

        // Act
        int first = subject.GetHashCode();
        int second = subject.GetHashCode();

        // Assert
        first.ShouldBe(second);
    }
}