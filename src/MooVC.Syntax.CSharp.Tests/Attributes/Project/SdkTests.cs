namespace MooVC.Syntax.CSharp.Attributes.Project.SdkTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenSdkIsUnspecified()
    {
        // Act
        var subject = new Sdk();

        // Assert
        subject.MinimumVersion.ShouldBe(Snippet.Empty);
        subject.Name.ShouldBe(Qualifier.Unqualified);
        subject.Version.ShouldBe(Snippet.Empty);
        subject.IsUnspecified.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Act
        var subject = new Sdk
        {
            MinimumVersion = Snippet.From(SdkTestsData.DefaultMinimumVersion),
            Name = SdkTestsData.DefaultName,
            Version = Snippet.From(SdkTestsData.DefaultVersion),
        };

        // Assert
        subject.MinimumVersion.ShouldBe(Snippet.From(SdkTestsData.DefaultMinimumVersion));
        subject.Name.ShouldBe(SdkTestsData.DefaultName);
        subject.Version.ShouldBe(Snippet.From(SdkTestsData.DefaultVersion));
        subject.IsUnspecified.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUnspecifiedThenValidationIsSkipped()
    {
        // Arrange
        Sdk subject = Sdk.Unspecified;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenMultiLineMinimumVersionThenValidationErrorReturned()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create(minimumVersion: Snippet.From($"alpha{Environment.NewLine}beta"));
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Sdk.MinimumVersion));
    }

    [Fact]
    public void GivenUnqualifiedNameThenValidationErrorReturned()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create(name: Qualifier.Unqualified);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Sdk.Name));
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUnspecifiedThenReturnsEmpty()
    {
        // Arrange
        Sdk subject = Sdk.Unspecified;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsFragment()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        var element = new XElement(
            nameof(Sdk),
            new XAttribute(nameof(Sdk.Name), SdkTestsData.DefaultName.ToString()),
            new XAttribute(nameof(Sdk.Version), SdkTestsData.DefaultVersion),
            new XAttribute(nameof(Sdk.MinimumVersion), SdkTestsData.DefaultMinimumVersion));

        string expected = element + Environment.NewLine;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(expected);
    }
}

public sealed class WhenWithNameIsCalled
{
    [Fact]
    public void GivenValueThenReturnsUpdatedInstance()
    {
        // Arrange
        Sdk original = SdkTestsData.Create();
        Qualifier updated = "Other.Sdk";

        // Act
        Sdk result = original.WithName(updated);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Name.ShouldBe(updated);
        result.MinimumVersion.ShouldBe(original.MinimumVersion);
        result.Version.ShouldBe(original.Version);
    }
}

public sealed class WhenEqualsSdkIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        Sdk? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        Sdk other = SdkTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        Sdk other = SdkTestsData.Create(version: Snippet.From("2.0.0"));

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
        Sdk subject = SdkTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Sdk subject = SdkTestsData.Create();
        object other = SdkTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorSdkSdkIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Sdk? left = default;
        Sdk? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Sdk left = SdkTestsData.Create();
        Sdk right = SdkTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Sdk left = SdkTestsData.Create();
        Sdk right = SdkTestsData.Create(version: Snippet.From("2.0.0"));

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorSdkSdkIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Sdk left = SdkTestsData.Create();
        Sdk right = SdkTestsData.Create(version: Snippet.From("2.0.0"));

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
        Sdk left = SdkTestsData.Create();
        Sdk right = SdkTestsData.Create();

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
        Sdk left = SdkTestsData.Create();
        Sdk right = SdkTestsData.Create(version: Snippet.From("2.0.0"));

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class SdkTestsData
{
    public const string DefaultMinimumVersion = "1.0.0";
    public const string DefaultVersion = "9.9.9";
    public static readonly Qualifier DefaultName = "MooVC.Sdk";

    public static Sdk Create(
        Snippet? minimumVersion = default,
        Qualifier? name = default,
        Snippet? version = default)
    {
        return new Sdk
        {
            MinimumVersion = minimumVersion ?? Snippet.From(DefaultMinimumVersion),
            Name = name ?? DefaultName,
            Version = version ?? Snippet.From(DefaultVersion),
        };
    }
}