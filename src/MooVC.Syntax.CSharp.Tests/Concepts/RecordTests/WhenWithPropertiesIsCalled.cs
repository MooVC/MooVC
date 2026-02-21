namespace MooVC.Syntax.CSharp.Concepts.RecordTests;

using MooVC.Syntax.CSharp.Elements;
using MooVC.Syntax.CSharp.Members;
using MooVC.Syntax.Elements;

public sealed class WhenWithPropertiesIsCalled
{
    [Fact]
    public void GivenPropertiesThenReturnsUpdatedInstance()
    {
        // Arrange
        var existing = new Property { Name = "Value", Type = typeof(string) };
        var appended = new Property { Name = "Other", Type = typeof(int) };
        Record original = RecordTestsData.Create(properties: [existing]);

        // Act
        Record result = original.WithProperties(appended);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Properties.ShouldBe(new[] { existing, appended });
        result.Scope.ShouldBe(original.Scope);
    }
}