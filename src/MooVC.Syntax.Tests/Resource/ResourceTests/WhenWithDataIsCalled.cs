namespace MooVC.Syntax.Resource.ResourceTests;

using Resource = Resource;

public sealed class WhenWithDataIsCalled
{
    [Test]
    public async Task GivenDataThenReturnsUpdatedInstance()
    {
        // Arrange
        Data existing = ResourceTestsData.CreateData();
        var additional = new Data { Name = "Other", Value = "Other" };
        Resource original = ResourceTestsData.Create(data: existing);

        // Act
        Resource result = original.WithData(additional);

        // Assert
        _ = await Assert.That(result).IsNotStrictlyEqualTo(original);
        _ = await Assert.That(result.Data).IsEquivalentTo([.. original.Data, additional]);
        _ = await Assert.That(result.Assemblies).IsEqualTo(original.Assemblies);
    }
}