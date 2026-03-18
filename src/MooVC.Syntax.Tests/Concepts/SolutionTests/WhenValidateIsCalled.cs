namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Solution;
using ProjectReference = MooVC.Syntax.Attributes.Solution.Project;

public sealed class WhenValidateIsCalled
{
    [Test]
    public async Task GivenUndefinedThenReturnsEmptyResults()
    {
        // Arrange
        Solution subject = Solution.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUndefinedConfigurationThenNoValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(configurations: Configurations.Default);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsTrue();
        await Assert.That(results).IsEmpty();
    }

    [Test]
    public async Task GivenUndefinedFileThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(file: File.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Solution.Files));
    }

    [Test]
    public async Task GivenUndefinedFolderThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(folder: Folder.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Solution.Folders));
    }

    [Test]
    public async Task GivenUndefinedItemThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(item: Item.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Solution.Items));
    }

    [Test]
    public async Task GivenUndefinedProjectThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(project: ProjectReference.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Solution.Projects));
    }

    [Test]
    public async Task GivenUndefinedPropertyThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(property: Property.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        await Assert.That(valid).IsFalse();
        _ = await results.Single();
        await Assert.That(results[0].MemberNames).Contains(nameof(Solution.Properties));
    }
}