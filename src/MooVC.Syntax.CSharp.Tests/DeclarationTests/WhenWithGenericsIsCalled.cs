namespace MooVC.Syntax.CSharp.DeclarationTests;

using Generic = MooVC.Syntax.CSharp.Generics.Generic;

public sealed class WhenWithGenericsIsCalled
{
    [Test]
    public async Task GivenArgumentsThenReturnsNewInstanceWithUpdatedArguments()
    {
        // Arrange
        Declaration original = DeclarationTestsData.Create(parameterNames: "T");
        Generic[] additional = [new Generic { Name = new Name("U") }];

        // Act
        Declaration result = original.WithGenerics(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Generics.Length).IsEqualTo(2);
        _ = await Assert.That(result.Generics).IsEquivalentTo([.. original.Generics, .. additional]);
        _ = await Assert.That(result.Name).IsEqualTo(original.Name);
    }
}