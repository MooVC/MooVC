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
        _ = await Assert.That(result).IsNotSameReferenceAs(original);
        _ = await Assert.That(result.Declaration).IsEqualTo(newName);
        _ = await Assert.That(original.Declaration).IsEqualTo(new Declaration { Name = ClassTestsData.DefaultName });
    }
}