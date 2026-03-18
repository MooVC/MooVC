namespace MooVC.Syntax.CSharp.Elements.ParameterTests.ModeTests;

public sealed class WhenPropertiesAreCalled
{
    [Test]
    [Arguments("in", true, false, false, false, false, false, false, false)]
    [Arguments("out", false, true, false, false, false, false, false, false)]
    [Arguments("", false, false, true, false, false, false, false, false)]
    [Arguments("params", false, false, false, true, false, false, false, false)]
    [Arguments("ref", false, false, false, false, true, false, false, false)]
    [Arguments("ref readonly", false, false, false, false, false, true, false, false)]
    [Arguments("scoped", false, false, false, false, false, false, true, false)]
    [Arguments("this", false, false, false, false, false, false, false, true)]
    public async Task GivenModeThenFlagsMatch(
        string value,
        bool expectedIn,
        bool expectedOut,
        bool expectedNone,
        bool expectedParams,
        bool expectedRef,
        bool expectedRefReadonly,
        bool expectedScoped,
        bool expectedThis)
    {
        // Arrange
        Parameter.Mode subject = value;

        // Act & Assert
        await Assert.That(subject.IsIn).IsEqualTo(expectedIn);
        await Assert.That(subject.IsOut).IsEqualTo(expectedOut);
        await Assert.That(subject.IsNone).IsEqualTo(expectedNone);
        await Assert.That(subject.IsParams).IsEqualTo(expectedParams);
        await Assert.That(subject.IsRef).IsEqualTo(expectedRef);
        await Assert.That(subject.IsRefReadonly).IsEqualTo(expectedRefReadonly);
        await Assert.That(subject.IsScoped).IsEqualTo(expectedScoped);
        await Assert.That(subject.IsThis).IsEqualTo(expectedThis);
    }
}