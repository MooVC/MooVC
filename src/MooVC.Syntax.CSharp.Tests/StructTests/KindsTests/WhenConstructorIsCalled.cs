namespace MooVC.Syntax.CSharp.StructTests.KindsTests;

using System;
using System.Reflection;

public sealed class WhenConstructorIsCalled
{
    [Test]
    public async Task GivenValueThenKindIsCreated()
    {
        // Act
        var subject = (Struct.Kinds)Activator.CreateInstance(
            typeof(Struct.Kinds),
            BindingFlags.Instance | BindingFlags.NonPublic,
            binder: null,
            args: ["readonly"],
            culture: null)!;

        // Assert
        _ = await Assert.That(subject).IsEqualTo(Struct.Kinds.ReadOnly);
    }
}