namespace MooVC.Syntax.CSharp.DefinitionTests;

using System.ComponentModel;
using MooVC.Syntax;
using static MooVC.Syntax.CSharp.Symbol;
using Attribute = System.Attribute;
using Options = MooVC.Syntax.CSharp.Options;

public sealed partial class WhenToSnippetIsCalled
{
    public sealed class AsModeller
    {
        private static readonly Options _options = new Options()
            .WithNamespace(Qualifier.Options.File)
            .WithTypes(types => types.WithQualification(Qualification.Minimum));

        [Test]
        public async Task GivenInstructionsWhenAttributeThenAttributeIsCreated()
        {
            // Arrange
            const string expected = """
            namespace Muify.Domain;
            
            [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
            internal sealed partial class IdentityAttribute
                : Attribute
            {
            }
            """;

            Definition content = Builder
                .New<Definition>()
                .From("Muify.Domain")
                .For<Class>(@class => @class
                    .AttributedWith(attribute => attribute
                        .Named(typeof(AttributeUsageAttribute))
                        .WithArguments(
                            (Name: string.Empty, Value: "AttributeTargets.Property"),
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
            namespace Muify.Domain;

            [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
            internal sealed partial class RaisesAttribute
                : Attribute
            {
                public string Name { get; set; }
            }
            """;

            Definition content = Builder
                .New<Definition>()
                .From("Muify.Domain")
                .For<Class>(@class => @class
                    .AttributedWith(attribute => attribute
                        .Named(typeof(AttributeUsageAttribute))
                        .WithArguments(
                            (Name: string.Empty, Value: "AttributeTargets.Property"),
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
            namespace MooVC.Testing.Mechanics.Car;
            
            using System.ComponentModel;
            using Mu.Modelling.State;
            
            [Description("Represents a Vehicle that has utilizes the services of the Mechanics")]
            public sealed partial record Car(
                [Description("The Number of Passenger Doors")] byte Doors,
                [Description("The Manufacturer of the Car")] string Make,
                [Description("The Name Ascribed to the Car by the Manufacturer")] string Model)
                : Aggregate;
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
                        .OfType(typeof(string))))
                .Referencing(directive => directive.From(typeof(DescriptionAttribute)))
                .Referencing(directive => directive.From("Mu.Modelling.State"));

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }
    }
}