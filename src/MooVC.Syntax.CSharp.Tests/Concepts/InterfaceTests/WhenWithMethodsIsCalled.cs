namespace MooVC.Syntax.CSharp.Concepts.InterfaceTests;

using MooVC.Syntax.CSharp.Members;

public sealed class WhenWithMethodsIsCalled
{
    [Test]
    public async Task GivenMethodsThenReturnsUpdatedInstance()
    {
        // Arrange
        var method = new Method { Name = new Declaration { Name = "Execute" } };
        Interface original = InterfaceTestsData.Create();

        // Act
        Interface result = original.WithMethods(method);

        // Assert
        await Assert.That(ReferenceEquals(result, original)).IsFalse();
        await Assert.That(result.Methods).Contains(method);
        await Assert.That(original.Methods).IsEmpty();
    }
}