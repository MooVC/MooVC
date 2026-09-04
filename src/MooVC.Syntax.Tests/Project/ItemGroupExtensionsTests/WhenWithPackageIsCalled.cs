namespace MooVC.Syntax.Project.ItemGroupExtensionsTests;

public sealed class WhenWithPackageIsCalled
{
    private const string Condition = "Condition";
    private const string Exclude = "Excluded";
    private const string PackageName = "Newtonsoft.Json";

    [Test]
    public async Task GivenNameThenAddsPackageReferenceItem()
    {
        // Arrange
        var subject = new ItemGroup();

        // Act
        ItemGroup result = subject.WithPackage(PackageName);

        // Assert
        _ = await Assert.That(result.Items.Length).IsEqualTo(1);
        _ = await Assert.That(result.Items[0].Name.ToString()).IsEqualTo("PackageReference");
        _ = await Assert.That(result.Items[0].Include.ToString()).IsEqualTo(PackageName);
    }

    [Test]
    public async Task GivenBuilderThenAddsConfiguredPackageReferenceItem()
    {
        // Arrange
        var subject = new ItemGroup();

        // Act
        ItemGroup result = subject.WithPackage(
            PackageName,
            package => package
                .OnCondition(Condition)
                .WithExclude(Exclude));

        // Assert
        _ = await Assert.That(result.Items.Length).IsEqualTo(1);
        _ = await Assert.That(result.Items[0].Condition.ToString()).IsEqualTo(Condition);
        _ = await Assert.That(result.Items[0].Exclude.ToString()).IsEqualTo(Exclude);
        _ = await Assert.That(result.Items[0].Include.ToString()).IsEqualTo(PackageName);
    }
}