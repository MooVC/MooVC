namespace MooVC.Syntax.CSharp.DefinitionTests;

using System.ComponentModel;
using Monify;
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
            .WithTypes(types => types
                .WithSymbols(symbols => symbols
                    .WithQualification(Qualification.Global)));

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
                .For<Class>(@class => @class
                    .AttributedWith(attribute => attribute
                        .Named(typeof(AttributeUsageAttribute))
                        .WithArguments(
                            (Name: string.Empty, Value: "global::System.AttributeTargets.Property"),
                            (Name: nameof(AttributeUsageAttribute.AllowMultiple), Value: "false"),
                            (Name: nameof(AttributeUsageAttribute.Inherited), Value: "false")))
                    .DerivesFrom(typeof(Attribute))
                    .Named("IdentityAttribute")
                    .WithScope(Scope.Internal))
                .From("Muify.Domain");

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
                            .WithSet(set => set.WithMode(Property.Methods.Setter.Modes.Set))))
                    .WithScope(Scope.Internal))
                .From("Muify.Domain");

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
                    : global::Mu.Modelling.State.Aggregate;
            }
            """;

            Definition content = Builder
                .New<Definition>()
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
                .From("MooVC.Testing.Mechanics.Car");

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }

        [Test]
        public async Task GivenInstructionsWhenClassWithPropertiesThenClassIsCreated()
        {
            // Arrange
            const string expected = """
            namespace MooVC.Testing.Mechanics.Car
            {
                [global::System.ComponentModel.DescriptionAttribute("Represents a Wheel Attached to the Car")]
                public sealed partial class Wheel
                {
                    [global::System.ComponentModel.DescriptionAttribute("The Location of the Wheel on the Car")]
                    [global::Muify.Domain.IdentityAttribute]
                    public global::MooVC.Testing.Mechanics.Car.Location Location { get; init; }
            
                    [global::System.ComponentModel.DescriptionAttribute("The Pressure of the Tyre on the Wheel")]
                    public global::MooVC.Testing.Mechanics.Car.Pressure Pressure { get; init; }
                }
            }
            """;

            Definition content = Builder
                .New<Definition>()
                .From("MooVC.Testing.Mechanics.Car")
                .For<Class>(@class => @class
                    .AttributedWith(description => description
                        .Named(typeof(DescriptionAttribute))
                        .WithArguments((Name: string.Empty, Value: "\"Represents a Wheel Attached to the Car\"")))
                    .Named("Wheel")
                    .WithProperties(location => location
                        .AttributedWith(description => description
                            .Named(typeof(DescriptionAttribute))
                            .WithArguments((Name: string.Empty, Value: "\"The Location of the Wheel on the Car\"")))
                        .AttributedWith(identity => identity.Named((Name: "IdentityAttribute", Qualifier: "Muify.Domain")))
                        .Named("Location")
                        .OfType((Name: "Location", Qualifier: "MooVC.Testing.Mechanics.Car")))
                    .WithProperties(pressure => pressure
                        .AttributedWith(description => description
                            .Named(typeof(DescriptionAttribute))
                            .WithArguments((Name: string.Empty, Value: "\"The Pressure of the Tyre on the Wheel\"")))
                        .Named("Pressure")
                        .OfType((Name: "Pressure", Qualifier: "MooVC.Testing.Mechanics.Car"))));

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }

        [Test]
        public async Task GivenInstructionsWhenListThenAnnotatedRecordIsCreated()
        {
            // Arrange
            const string expected = """
            namespace MooVC.Testing.Mechanics.Car
            {
                [global::System.ComponentModel.DescriptionAttribute("Represents the Location of the Wheel on the Car")]
                [global::Monify.MonifyAttribute<byte>]
                public sealed partial record Location
                {
                    [global::System.ComponentModel.DescriptionAttribute("The Front Left Wheel")]
                    public static readonly global::MooVC.Testing.Mechanics.Car.Location FrontLeft = 0;

                    [global::System.ComponentModel.DescriptionAttribute("The Front Right Wheel")]
                    public static readonly global::MooVC.Testing.Mechanics.Car.Location FrontRight = 1;

                    [global::System.ComponentModel.DescriptionAttribute("The Rear Left Wheel")]
                    public static readonly global::MooVC.Testing.Mechanics.Car.Location RearLeft = 2;

                    [global::System.ComponentModel.DescriptionAttribute("The Rear Right Wheel")]
                    public static readonly global::MooVC.Testing.Mechanics.Car.Location RearRight = 3;

                    private Location(byte value)
                    {
                        _value = value;
                    }

                    public bool IsFrontLeft => this == FrontLeft;

                    public bool IsFrontRight => this == FrontRight;

                    public bool IsRearLeft => this == RearLeft;

                    public bool IsRearRight => this == RearRight;
                }
            }
            """;

            var members = new (string Name, string Description, int Index)[]
            {
                (Name: "FrontLeft", Description: "The Front Left Wheel", Index: 0),
                (Name: "FrontRight", Description: "The Front Right Wheel", Index: 1),
                (Name: "RearLeft", Description: "The Rear Left Wheel", Index: 2),
                (Name: "RearRight", Description: "The Rear Right Wheel", Index: 3),
            };

            Definition content = Builder
                .New<Definition>()
                .For<Record>(record => record
                    .AttributedWith(description => description
                        .Named(typeof(DescriptionAttribute))
                        .WithArguments((Name: string.Empty, Value: "\"Represents the Location of the Wheel on the Car\"")))
                    .AttributedWith(monify => monify.Named(monify => monify
                        .From(typeof(MonifyAttribute))
                        .Named(nameof(MonifyAttribute))
                        .WithArguments(type => type.Named(typeof(byte)))))
                    .Named("Location")
                    .Enumerate(
                        (member, record) => record.WithFields(field => field
                            .AttributedWith(description => description
                                .Named(typeof(DescriptionAttribute))
                                .WithArguments((Name: string.Empty, Value: $"\"{member.Description}\"")))
                            .IsReadOnly(true)
                            .IsStatic(true)
                            .Named(member.Name)
                            .OfType((Name: "Location", Qualifier: "MooVC.Testing.Mechanics.Car"))
                            .WithDefault(member.Index.ToString())
                            .WithScope(Scope.Public)),
                        members)
                    .Enumerate(
                        (member, record) => record.WithProperties(property => property
                            .WithBehaviours(methods => methods
                                .WithGet($"this == {member.Name};")
                                .WithSet(setter => setter.WithMode(Property.Methods.Setter.Modes.ReadOnly)))
                            .Named($"Is{member.Name}")
                            .OfType(typeof(bool))),
                        members)
                    .WithConstructors(constructor => constructor
                        .WithBody("_value = value;")
                        .WithParameters((Name: "Value", Type: typeof(byte)))
                        .WithScope(Scope.Private)))
               .From("MooVC.Testing.Mechanics.Car");

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }
    }
}