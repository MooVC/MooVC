namespace MooVC.Syntax.CSharp.ParameterTests.ModesTests;

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
        Parameter.Modes subject = value;

        // Act & Assert
        _ = await Assert.That(subject.IsIn).IsEqualTo(expectedIn);
        _ = await Assert.That(subject.IsOut).IsEqualTo(expectedOut);
        _ = await Assert.That(subject.IsNone).IsEqualTo(expectedNone);
        _ = await Assert.That(subject.IsParams).IsEqualTo(expectedParams);
        _ = await Assert.That(subject.IsRef).IsEqualTo(expectedRef);
        _ = await Assert.That(subject.IsRefReadonly).IsEqualTo(expectedRefReadonly);
        _ = await Assert.That(subject.IsScoped).IsEqualTo(expectedScoped);
        _ = await Assert.That(subject.IsThis).IsEqualTo(expectedThis);
    }
}