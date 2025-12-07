namespace MooVC.Syntax.CSharp.Members.IndexerTests;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.CSharp.Members;

public sealed class WhenValidateIsCalled
{
    [Fact]
    public void GivenUndefinedIndexerThenNoResultsReturned()
    {
        // Arrange
        Indexer subject = Indexer.Undefined;

        // Act
        IEnumerable<ValidationResult> results = subject.Validate(new ValidationContext(subject));

        // Assert
        results.ShouldBeEmpty();
    }

    [Fact]
    public void GivenDefinedIndexerThenNotImplementedExceptionIsThrown()
    {
        // Arrange
        Indexer subject = IndexerTestsData.Create();

        // Act
        Action action = () => subject.Validate(new ValidationContext(subject));

        // Assert
        _ = action.ShouldThrow<NotImplementedException>();
    }
}
