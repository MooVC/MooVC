namespace MooVC.Syntax.CSharp.Operators.OperatorsTests;

using MooVC.Syntax.CSharp.Operators.BinaryTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public void GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        Operators first = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);
        Operators second = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldBe(secondHash);
    }

    [Test]
    public void GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Operators first = OperatorsSubjectData.Create();
        Operators second = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        firstHash.ShouldNotBe(secondHash);
    }
}