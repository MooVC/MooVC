namespace MooVC.Syntax.CSharp.Concepts.ClassTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenNamedIsCalled
{
    [Test]
    public async Task GivenNameThenReturnsUpdatedInstance()
    {
        // Arrange
        Class original = ClassTestsData.Create();
        var newName = new Declaration { Name = "Other" };

        // Act
        Class result = original.Named(newName);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Declaration).IsEqualTo(newName);
        await Assert.That(original.Declaration).IsEqualTo(new Declaration { Name = ClassTestsData.DefaultName });
    }
}