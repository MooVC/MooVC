namespace MooVC.Syntax.CSharp.Attributes.Project.ImportTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenImportIsUndefined()
    {
        // Act
        var subject = new Import();

        // Assert
        subject.Condition.ShouldBe(Snippet.Empty);
        subject.Label.ShouldBe(Snippet.Empty);
        subject.Project.ShouldBe(Snippet.Empty);
        subject.Sdk.ShouldBe(Snippet.Empty);
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Import
        {
            Condition = Snippet.From(ImportTestsData.DefaultCondition),
            Label = Snippet.From(ImportTestsData.DefaultLabel),
            Project = Snippet.From(ImportTestsData.DefaultProject),
            Sdk = Snippet.From(ImportTestsData.DefaultSdk),
        };

        // Assert
        subject.Condition.ShouldBe(Snippet.From(ImportTestsData.DefaultCondition));
        subject.Label.ShouldBe(Snippet.From(ImportTestsData.DefaultLabel));
        subject.Project.ShouldBe(Snippet.From(ImportTestsData.DefaultProject));
        subject.Sdk.ShouldBe(Snippet.From(ImportTestsData.DefaultSdk));
        subject.IsUndefined.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenValidationIsSkipped()
    {
        // Arrange
        Import subject = Import.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultiLineConditionThenValidationErrorReturned()
    {
        // Arrange
        Import subject = ImportTestsData.Create(condition: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Import.Condition));
    }

    [Fact]
    public void GivenSingleLineProjectThenValidationErrorReturned()
    {
        // Arrange
        Import subject = ImportTestsData.Create(project: Snippet.From("Project"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Import.Project));
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Import subject = Import.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        var element = new XElement(
            nameof(Import),
            new XAttribute(nameof(Import.Project), ImportTestsData.DefaultProject),
            new XAttribute(nameof(Import.Sdk), ImportTestsData.DefaultSdk),
            new XAttribute(nameof(Import.Condition), ImportTestsData.DefaultCondition),
            new XAttribute(nameof(Import.Label), ImportTestsData.DefaultLabel));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenWithProjectIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Import original = ImportTestsData.Create();
        Snippet updated = Snippet.From("Updated");

        // Act
        Import result = original.WithProject(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Project.ShouldBe(updated);
        result.Condition.ShouldBe(original.Condition);
        result.Label.ShouldBe(original.Label);
        result.Sdk.ShouldBe(original.Sdk);
    }
}

public sealed class WhenEqualsImportIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        Import? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        Import other = ImportTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        Import other = ImportTestsData.Create(project: Snippet.From("Other"));

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenEqualsObjectIsCalled
{
    [Fact]
    public void GivenOtherTypeThenReturnsFalse()
    {
        // Arrange
        Import subject = ImportTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Import subject = ImportTestsData.Create();
        object other = ImportTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorImportImportIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Import? left = default;
        Import? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenLeftNullRightValueThenReturnsFalse()
    {
        // Arrange
        Import? left = default;
        Import right = ImportTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create(sdk: Snippet.From("Other"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorImportImportIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsFalse()
    {
        // Arrange
        Import? left = default;
        Import? right = default;

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create(label: Snippet.From("Other"));

        // Act
        bool result = left != right;

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenGetHashCodeIsCalled
{
    [Fact]
    public void GivenEqualValuesThenHashCodesMatch()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create();

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldBe(rightHash);
    }

    [Fact]
    public void GivenDifferentValuesThenHashCodesDiffer()
    {
        // Arrange
        Import left = ImportTestsData.Create();
        Import right = ImportTestsData.Create(label: Snippet.From("Other"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class ImportTestsData
{
    public const string DefaultCondition = "Condition";
    public const string DefaultLabel = "Label";
    public const string DefaultProject = "Project";
    public const string DefaultSdk = "Sdk";

    public static Import Create(
        Snippet? condition = default,
        Snippet? label = default,
        Snippet? project = default,
        Snippet? sdk = default)
    {
        return new Import
        {
            Condition = condition ?? Snippet.From(DefaultCondition),
            Label = label ?? Snippet.From(DefaultLabel),
            Project = project ?? Snippet.From(DefaultProject),
            Sdk = sdk ?? Snippet.From(DefaultSdk),
        };
    }
}