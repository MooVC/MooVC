namespace MooVC.Syntax.BuilderTests;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MooVC.Syntax.Concepts;

public sealed class WhenNewIsCalled
{
    [Test]
    public async Task GivenConstructTypeThenNewInstanceIsReturned()
    {
        // Arrange
        // Act
        TestConstruct first = Builder.New<TestConstruct>();
        TestConstruct second = Builder.New<TestConstruct>();

        // Assert
        _ = await Assert.That(first).IsNotNull();
        _ = await Assert.That(second).IsNotNull();
        await Assert.That(first).IsTypeOf<TestConstruct>();
        await Assert.That(second).IsTypeOf<TestConstruct>();
        await Assert.That(ReferenceEquals(first, second)).IsFalse();
    }

    private sealed class TestConstruct
        : Construct
    {
        public override bool IsUndefined => false;

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}