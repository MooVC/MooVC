namespace MooVC.Modelling.FileTests;

public sealed class WhenToStringIsCalled
{
    [Test]
    public async Task GivenDifferentValuesThenReturnsDifferentRepresentations()
    {
        // Arrange
        File first = FileTestsData.Create();
        File second = FileTestsData.Create(content: FileTestsData.OtherContent);

        // Act
        string firstString = first.ToString();
        string secondString = second.ToString();

        // Assert
        _ = await Assert.That(firstString).IsNotEqualTo(secondString);
    }

    [Test]
    public async Task GivenEqualValuesThenReturnsSameRepresentation()
    {
        // Arrange
        File first = FileTestsData.Create();
        File second = FileTestsData.Create();

        // Act
        string firstString = first.ToString();
        string secondString = second.ToString();

        // Assert
        _ = await Assert.That(firstString).IsEqualTo(secondString);
    }
}