namespace MooVC.Syntax.CSharp.StructTests;

public sealed class WhenWithFieldsIsCalled
{
    [Test]
    public async Task GivenFieldsThenReturnsUpdatedInstance()
    {
        // Arrange
        var field = new Field { Name = new Variable("_value"), Type = typeof(int) };
        Struct original = StructTestsData.Create();

        // Act
        Struct result = original.WithFields(field);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Fields).Contains(field);
        _ = await Assert.That(original.Fields).IsEmpty();
    }
}