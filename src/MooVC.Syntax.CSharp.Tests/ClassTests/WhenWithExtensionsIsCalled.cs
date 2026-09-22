namespace MooVC.Syntax.CSharp.ClassTests;

public sealed class WhenWithExtensionsIsCalled
{
    [Test]
    public async Task GivenAdditionalBlockThenNewClassPreservesExistingMembersAndBlocks()
    {
        // Arrange
        Extension first = Extension.Undefined.Extends(parameter => parameter.OfType(typeof(string)));
        Extension second = Extension.Undefined.Extends(parameter => parameter.OfType(typeof(int)));

        Class original = Type.New<Class>().Named("SampleExtensions").IsStatic(true)
            .WithExtensions(first)
            .WithMethods(method => method.Named("Perform").Returns(Result.Void).WithExtensibility(Modifiers.Static));

        // Act
        Class result = original.WithExtensions(second);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(original.Extensions).HasSingleItem();
        _ = await Assert.That(result.Extensions).IsEquivalentTo([first, second]);
        _ = await Assert.That(result.Methods).IsEqualTo(original.Methods);
    }
}