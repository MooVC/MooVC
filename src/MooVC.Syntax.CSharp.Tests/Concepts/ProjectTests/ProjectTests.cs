namespace MooVC.Syntax.CSharp.Concepts.ProjectTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Xml.Linq;
using MooVC.Syntax.CSharp.Attributes.Project;
using MooVC.Syntax.CSharp.Elements;

public sealed class WhenConstructorIsCalled
{
    [Fact]
    public void GivenDefaultsThenProjectIsUndefined()
    {
        // Act
        var subject = new Project();

        // Assert
        subject.Imports.ShouldBeEmpty();
        subject.ItemGroups.ShouldBeEmpty();
        subject.PropertyGroups.ShouldBeEmpty();
        subject.Sdks.ShouldBeEmpty();
        subject.Targets.ShouldBeEmpty();
        subject.IsUndefined.ShouldBeTrue();
    }

    [Fact]
    public void GivenValuesThenPropertiesAreAssigned()
    {
        // Arrange
        Import import = ProjectTestsData.CreateImport();
        ItemGroup itemGroup = ProjectTestsData.CreateItemGroup();
        PropertyGroup propertyGroup = ProjectTestsData.CreatePropertyGroup();
        Sdk sdk = ProjectTestsData.CreateSdk();
        Target target = ProjectTestsData.CreateTarget();

        // Act
        var subject = new Project
        {
            Imports = [import],
            ItemGroups = [itemGroup],
            PropertyGroups = [propertyGroup],
            Sdks = [sdk],
            Targets = [target],
        };

        // Assert
        subject.Imports.ShouldBe(new[] { import });
        subject.ItemGroups.ShouldBe(new[] { itemGroup });
        subject.PropertyGroups.ShouldBe(new[] { propertyGroup });
        subject.Sdks.ShouldBe(new[] { sdk });
        subject.Targets.ShouldBe(new[] { target });
        subject.IsUndefined.ShouldBeFalse();
    }
}

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmptyResults()
    {
        // Arrange
        Project subject = Project.Undefined;
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeTrue();
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenUndefinedImportThenValidationErrorReturned()
    {
        // Arrange
        Project subject = ProjectTestsData.Create(import: Import.Undefined);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Project.Imports));
    }

    [Fact]
    public void GivenUnspecifiedSdkThenValidationErrorReturned()
    {
        // Arrange
        Project subject = ProjectTestsData.Create(sdk: Sdk.Unspecified);
        var context = new ValidationContext(subject);
        var results = new List<ValidationResult>();

        // Act
        bool valid = Validator.TryValidateObject(subject, context, results, validateAllProperties: true);

        // Assert
        valid.ShouldBeFalse();
        _ = results.ShouldHaveSingleItem();
        results[0].MemberNames.ShouldContain(nameof(Project.Sdks));
    }
}

public sealed class WhenToDocumentIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmptyDocument()
    {
        // Arrange
        Project subject = Project.Undefined;

        // Act
        XDocument result = subject.ToDocument();

        // Assert
        result.Root.ShouldBeNull();
        result.Declaration.ShouldBeNull();
    }

    [Fact]
    public void GivenValuesThenReturnsDocument()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();

        var importElement = new XElement(
            nameof(Import),
            new XAttribute(nameof(Import.Project), ProjectTestsData.DefaultImportProject));

        var itemElement = new XElement(
            nameof(Item),
            new XAttribute(nameof(Item.Include), ProjectTestsData.DefaultItemInclude));

        var itemGroupElement = new XElement(nameof(ItemGroup), itemElement);

        var propertyElement = new XElement(
            ProjectTestsData.DefaultPropertyName,
            ProjectTestsData.DefaultPropertyValue);

        var propertyGroupElement = new XElement(nameof(PropertyGroup), propertyElement);

        var sdkElement = new XElement(
            nameof(Sdk),
            new XAttribute(nameof(Sdk.Name), ProjectTestsData.DefaultSdkName.ToString()),
            new XAttribute(nameof(Sdk.Version), ProjectTestsData.DefaultSdkVersion));

        var targetElement = new XElement(
            nameof(Target),
            new XAttribute(nameof(Target.Name), ProjectTestsData.DefaultTargetName));

        var expected = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XElement(
                nameof(Project),
                importElement,
                itemGroupElement,
                propertyGroupElement,
                sdkElement,
                targetElement));

        // Act
        XDocument result = subject.ToDocument();

        // Assert
        result.Declaration.ShouldNotBeNull();
        result.Declaration!.Version.ShouldBe("1.0");
        result.Declaration.Encoding.ShouldBe("utf-8");
        result.Declaration.Standalone.ShouldBe("yes");
        XNode.DeepEquals(expected, result).ShouldBeTrue();
    }
}

public sealed class WhenToStringIsCalled
{
    [Fact]
    public void GivenUndefinedThenReturnsEmpty()
    {
        // Arrange
        Project subject = Project.Undefined;

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(string.Empty);
    }

    [Fact]
    public void GivenValuesThenReturnsDocumentString()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();

        // Act
        string result = subject.ToString();

        // Assert
        result.ShouldBe(subject.ToDocument().ToString());
    }
}

public sealed class WhenWithImportsIsCalled
{
    [Fact]
    public void GivenImportsThenReturnsUpdatedInstance()
    {
        // Arrange
        Import existing = ProjectTestsData.CreateImport();
        Import additional = new Import { Project = Snippet.From("Other"), Sdk = Snippet.Empty };
        Project original = ProjectTestsData.Create(import: existing);

        // Act
        Project result = original.WithImports(additional);

        // Assert
        result.ShouldNotBeSameAs(original);
        result.Imports.ShouldBe(original.Imports.Concat(new[] { additional }));
        result.ItemGroups.ShouldBe(original.ItemGroups);
    }
}

public sealed class WhenEqualsProjectIsCalled
{
    [Fact]
    public void GivenNullThenReturnsFalse()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();
        Project? other = default;

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();
        Project other = ProjectTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();
        Project other = ProjectTestsData.Create(import: new Import { Project = Snippet.From("Other") });

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
        Project subject = ProjectTestsData.Create();

        // Act
        bool result = subject.Equals(new object());

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Project subject = ProjectTestsData.Create();
        object other = ProjectTestsData.Create();

        // Act
        bool result = subject.Equals(other);

        // Assert
        result.ShouldBeTrue();
    }
}

public sealed class WhenEqualityOperatorProjectProjectIsCalled
{
    [Fact]
    public void GivenBothNullThenReturnsTrue()
    {
        // Arrange
        Project? left = default;
        Project? right = default;

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenEqualValuesThenReturnsTrue()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create();

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void GivenDifferentValuesThenReturnsFalse()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(import: new Import { Project = Snippet.From("Other") });

        // Act
        bool result = left == right;

        // Assert
        result.ShouldBeFalse();
    }
}

public sealed class WhenInequalityOperatorProjectProjectIsCalled
{
    [Fact]
    public void GivenDifferentValuesThenReturnsTrue()
    {
        // Arrange
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(import: new Import { Project = Snippet.From("Other") });

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
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create();

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
        Project left = ProjectTestsData.Create();
        Project right = ProjectTestsData.Create(import: new Import { Project = Snippet.From("Other") });

        // Act
        int leftHash = left.GetHashCode();
        int rightHash = right.GetHashCode();

        // Assert
        leftHash.ShouldNotBe(rightHash);
    }
}

internal static class ProjectTestsData
{
    public const string DefaultImportProject = "Project";
    public const string DefaultItemInclude = "Include";
    public const string DefaultPropertyName = "Property";
    public const string DefaultPropertyValue = "Value";
    public const string DefaultSdkVersion = "1.0.0";
    public const string DefaultTargetName = "Build";
    public static readonly Qualifier DefaultSdkName = "MooVC.Sdk";

    public static Project Create(
        Import? import = default,
        ItemGroup? itemGroup = default,
        PropertyGroup? propertyGroup = default,
        Sdk? sdk = default,
        Target? target = default)
    {
        var project = new Project();

        if (import is not null)
        {
            project = project.WithImports(import);
        }

        if (itemGroup is not null)
        {
            project = project.WithItemGroups(itemGroup);
        }

        if (propertyGroup is not null)
        {
            project = project.WithPropertyGroups(propertyGroup);
        }

        if (sdk is not null)
        {
            project = project.WithSdks(sdk);
        }

        if (target is not null)
        {
            project = project.WithTargets(target);
        }

        return project;
    }

    public static Import CreateImport()
    {
        return new Import
        {
            Project = Snippet.From(DefaultImportProject),
        };
    }

    public static ItemGroup CreateItemGroup()
    {
        return new ItemGroup
        {
            Items = [new Item { Include = Snippet.From(DefaultItemInclude) }],
        };
    }

    public static PropertyGroup CreatePropertyGroup()
    {
        return new PropertyGroup
        {
            Properties = [new Property { Name = new Identifier(DefaultPropertyName), Value = Snippet.From(DefaultPropertyValue) }],
        };
    }

    public static Sdk CreateSdk()
    {
        return new Sdk
        {
            Name = DefaultSdkName,
            Version = Snippet.From(DefaultSdkVersion),
        };
    }

    public static Target CreateTarget()
    {
        return new Target
        {
            Name = new Identifier(DefaultTargetName),
        };
    }
}