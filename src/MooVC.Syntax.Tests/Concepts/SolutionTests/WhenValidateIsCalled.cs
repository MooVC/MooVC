namespace MooVC.Syntax.Concepts.SolutionTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Attributes.Solution;
using ProjectReference = MooVC.Syntax.Attributes.Solution.Project;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmptyResults()
    {
        // Arrange
        Solution subject = Solution.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUndefinedConfigurationThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(configuration: Configuration.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Solution.Configurations));
    }

    [Fact]
    public void GivenUndefinedFileThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(file: File.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Solution.Files));
    }

    [Fact]
    public void GivenUndefinedFolderThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(folder: Folder.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Solution.Folders));
    }

    [Fact]
    public void GivenUndefinedItemThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(item: Item.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Solution.Items));
    }

    [Fact]
    public void GivenUndefinedProjectThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(project: ProjectReference.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Solution.Projects));
    }

    [Fact]
    public void GivenUndefinedPropertyThenValidationErrorReturned()
    {
        // Arrange
        Solution subject = SolutionTestsData.Create(property: Property.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Solution.Properties));
    }
}