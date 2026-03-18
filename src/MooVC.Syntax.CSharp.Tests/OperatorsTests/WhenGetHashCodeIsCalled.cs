namespace MooVC.Syntax.CSharp.OperatorsTests;

using MooVC.Syntax.CSharp.BinaryTests;

public sealed class WhenGetHashCodeIsCalled
{
    [Test]
    public async Task GivenEquivalentValuesThenHashesMatch()
    {
        // Arrange
        Operators first = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);
        Operators second = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsEqualTo(secondHash);
    }

    [Test]
    public async Task GivenDifferentValuesThenHashesDiffer()
    {
        // Arrange
        Operators first = OperatorsSubjectData.Create();
        Operators second = OperatorsSubjectData.Create(binaries: [BinaryTestsData.Create()]);

        // Act
        int firstHash = first.GetHashCode();
        int secondHash = second.GetHashCode();

        // Assert
        _ = await Assert.That(firstHash).IsNotEqualTo(secondHash);
    }
}