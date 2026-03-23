namespace MooVC.Syntax.CSharp.DefinitionTests;

using System.ComponentModel;
using MooVC.Syntax;
using static MooVC.Syntax.CSharp.Symbol;
using Attribute = System.Attribute;
using Options = MooVC.Syntax.CSharp.Options;

public sealed partial class WhenToSnippetIsCalled
{
    public sealed class AsGenerator
    {
        private static readonly Options _options = new Options()
            .WithNamespace(Qualifier.Options.Block)
            .WithTypes(types => types.WithQualification(Qualification.Global));

        [Test]
        public async Task GivenInstructionsWhenAttributeThenAttributeIsCreated()
        {
            // Arrange
            const string expected = """
            namespace Muify.Domain
            {
                [global::System.AttributeUsageAttribute(global::System.AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
                internal sealed partial class IdentityAttribute
                    : global::System.Attribute
                {
                }
            }
            """;

            Definition content = Builder
                .New<Definition>()
                .From("Muify.Domain")
                .For<Class>(@class => @class
                    .AttributedWith(attribute => attribute
                        .Named(typeof(AttributeUsageAttribute))
                        .WithArguments(
                            (Name: string.Empty, Value: "global::System.AttributeTargets.Property"),
                            (Name: nameof(AttributeUsageAttribute.AllowMultiple), Value: "false"),
                            (Name: nameof(AttributeUsageAttribute.Inherited), Value: "false")))
                    .DerivesFrom(typeof(Attribute))
                    .Named("IdentityAttribute")
                    .WithScope(Scope.Internal));

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }

        [Test]
        public async Task GivenInstructionsWhenAttributeWithPropertiesThenAttributeIsCreated()
        {
            // Arrange
            const string expected = """
            namespace Muify.Domain
            {
                [global::System.AttributeUsageAttribute(global::System.AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
                internal sealed partial class RaisesAttribute
                    : global::System.Attribute
                {
                    public string Name { get; set; }
                }
            }
            """;

            Definition content = Builder
                .New<Definition>()
                .From("Muify.Domain")
                .For<Class>(@class => @class
                    .AttributedWith(attribute => attribute
                        .Named(typeof(AttributeUsageAttribute))
                        .WithArguments(
                            (Name: string.Empty, Value: "global::System.AttributeTargets.Property"),
                            (Name: nameof(AttributeUsageAttribute.AllowMultiple), Value: "false"),
                            (Name: nameof(AttributeUsageAttribute.Inherited), Value: "false")))
                    .DerivesFrom(typeof(Attribute))
                    .Named("RaisesAttribute")
                    .WithProperties(name => name
                        .Named("Name")
                        .OfType(typeof(string))
                        .WithBehaviours(behaviors => behaviors
                            .WithSet(set => set.WithMode(Property.Mode.Set))))
                    .WithScope(Scope.Internal));

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }

        [Test]
        public async Task GivenInstructionsWhenRecordWithParametersThenRecordIsCreated()
        {
            // Arrange
            const string expected = """
            namespace MooVC.Testing.Mechanics.Car
            {
                [global::System.ComponentModel.DescriptionAttribute("Represents a Vehicle that has utilizes the services of the Mechanics")]
                public sealed partial record Car(
                    [global::System.ComponentModel.DescriptionAttribute("The Number of Passenger Doors")] byte Doors,
                    [global::System.ComponentModel.DescriptionAttribute("The Manufacturer of the Car")] string Make,
                    [global::System.ComponentModel.DescriptionAttribute("The Name Ascribed to the Car by the Manufacturer")] string Model)
                    : global::Mu.Modelling.State.Aggregate
                {
                }
            }
            """;

            Definition content = Builder
                .New<Definition>()
                .From("MooVC.Testing.Mechanics.Car")
                .For<Record>(record => record
                    .AttributedWith(attribute => attribute
                        .Named(typeof(DescriptionAttribute))
                        .WithArguments((Name: string.Empty, Value: "\"Represents a Vehicle that has utilizes the services of the Mechanics\"")))
                    .DerivesFrom((Name: "Aggregate", Qualifier: "Mu.Modelling.State"))
                    .Named("Car")
                    .WithParameters(doors => doors
                        .AttributedWith(description => description
                            .Named(typeof(DescriptionAttribute))
                            .WithArguments((Name: string.Empty, Value: "\"The Number of Passenger Doors\"")))
                        .Named("Doors")
                        .OfType(typeof(byte)))
                    .WithParameters(make => make
                        .AttributedWith(description => description
                            .Named(typeof(DescriptionAttribute))
                            .WithArguments((Name: string.Empty, Value: "\"The Manufacturer of the Car\"")))
                        .Named("Make")
                        .OfType(typeof(string)))
                    .WithParameters(model => model
                        .AttributedWith(description => description
                            .Named(typeof(DescriptionAttribute))
                            .WithArguments((Name: string.Empty, Value: "\"The Name Ascribed to the Car by the Manufacturer\"")))
                        .Named("Model")
                        .OfType(typeof(string))));

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }
    }
}