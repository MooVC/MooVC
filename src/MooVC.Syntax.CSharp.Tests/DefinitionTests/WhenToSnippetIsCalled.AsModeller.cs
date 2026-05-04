namespace MooVC.Syntax.CSharp.DefinitionTests;

using System.ComponentModel;
using Monify;
using MooVC.Syntax;
using Attribute = System.Attribute;
using Options = MooVC.Syntax.CSharp.Options;

public sealed partial class WhenToSnippetIsCalled
{
    public sealed class AsModeller
    {
        private static readonly Options _options = new Options()
            .WithNamespace(Qualifier.Options.File)
            .WithTypes(types => types
                .WithQualifications(qualifications => qualifications
                    .WithFormat(Qualification.Options.Formats.Minimum)));

        [Test]
        public async Task GivenInstructionsWhenAttributeThenAttributeIsCreated()
        {
            // Arrange
            const string expected = """
                namespace Muify.Domain;

                using System;

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
                    .AttributedWith(
                        typeof(AttributeUsageAttribute),
                        attribute => attribute.WithArguments(
                            (Name: string.Empty, Value: "AttributeTargets.Property"),
                            (Name: nameof(AttributeUsageAttribute.AllowMultiple), Value: "false"),
                            (Name: nameof(AttributeUsageAttribute.Inherited), Value: "false")))
                    .DerivesFrom(typeof(Attribute))
                    .Named("IdentityAttribute")
                    .WithScope(Scopes.Internal))
                .ImportReferences();

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

                using System;

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
                    .AttributedWith(
                        typeof(AttributeUsageAttribute),
                        attribute => attribute.WithArguments(
                            (Name: string.Empty, Value: "AttributeTargets.Property"),
                            (Name: nameof(AttributeUsageAttribute.AllowMultiple), Value: "false"),
                            (Name: nameof(AttributeUsageAttribute.Inherited), Value: "false")))
                    .DerivesFrom(typeof(Attribute))
                    .Named("RaisesAttribute")
                    .WithProperties(name => name
                        .Named("Name")
                        .OfType(typeof(string))
                        .WithBehaviours(behaviors => behaviors
                            .WithSet(set => set.WithMode(Property.Methods.Setter.Modes.Set))))
                    .WithScope(Scopes.Internal))
                .ImportReferences();

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

                using System;
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
                    .AttributedWith(
                        typeof(DescriptionAttribute),
                        attribute => attribute.WithArguments((Name: string.Empty, Value: "\"Represents a Vehicle that has utilizes the services of the Mechanics\"")))
                    .DerivesFrom((Name: "Aggregate", Qualifier: "Mu.Modelling.State"))
                    .Named("Car")
                    .WithParameters(doors => doors
                        .AttributedWith(
                            typeof(DescriptionAttribute),
                            attribute => attribute.WithArguments((Name: string.Empty, Value: "\"The Number of Passenger Doors\"")))
                        .Named("Doors")
                        .OfType(typeof(byte)))
                    .WithParameters(make => make
                        .AttributedWith(
                            typeof(DescriptionAttribute),
                            attribute => attribute.WithArguments((Name: string.Empty, Value: "\"The Manufacturer of the Car\"")))
                        .Named("Make")
                        .OfType(typeof(string)))
                    .WithParameters(model => model
                        .AttributedWith(
                            typeof(DescriptionAttribute),
                            attribute => attribute.WithArguments((Name: string.Empty, Value: "\"The Name Ascribed to the Car by the Manufacturer\"")))
                        .Named("Model")
                        .OfType(typeof(string))))
                .ImportReferences();

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
                namespace MooVC.Testing.Mechanics.Car;

                using System.ComponentModel;
                using Muify.Domain;

                [Description("Represents a Wheel Attached to the Car")]
                public sealed partial class Wheel
                {
                    [Description("The Location of the Wheel on the Car")]
                    [Identity]
                    public Location Location { get; init; }
            
                    [Description("The Pressure of the Tyre on the Wheel")]
                    public Pressure Pressure { get; init; }
                }
                """;

            Definition content = Builder
                .New<Definition>()
                .From("MooVC.Testing.Mechanics.Car")
                .For<Class>(@class => @class
                    .AttributedWith(
                        typeof(DescriptionAttribute),
                        attribute => attribute.WithArguments((Name: string.Empty, Value: "\"Represents a Wheel Attached to the Car\"")))
                    .Named("Wheel")
                    .WithProperties(location => location
                        .AttributedWith(
                            typeof(DescriptionAttribute),
                            attribute => attribute.WithArguments((Name: string.Empty, Value: "\"The Location of the Wheel on the Car\"")))
                        .AttributedWith(identity => identity.Named((Name: "IdentityAttribute", Qualifier: "Muify.Domain")))
                        .Named("Location")
                        .OfType((Name: "Location", Qualifier: "MooVC.Testing.Mechanics.Car")))
                    .WithProperties(pressure => pressure
                        .AttributedWith(
                            typeof(DescriptionAttribute),
                            description => description.WithArguments((Name: string.Empty, Value: "\"The Pressure of the Tyre on the Wheel\"")))
                        .Named("Pressure")
                        .OfType((Name: "Pressure", Qualifier: "MooVC.Testing.Mechanics.Car"))))
               .ImportReferences();

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
                namespace MooVC.Testing.Mechanics.Car;

                using System;
                using System.ComponentModel;
                using Monify;

                [Description("Represents the Location of the Wheel on the Car")]
                [Monify<byte>]
                public readonly partial record struct Location
                {
                    [Description("The Front Left Wheel")]
                    public static readonly Location FrontLeft = 0;

                    [Description("The Front Right Wheel")]
                    public static readonly Location FrontRight = 1;

                    [Description("The Rear Left Wheel")]
                    public static readonly Location RearLeft = 2;

                    [Description("The Rear Right Wheel")]
                    public static readonly Location RearRight = 3;

                    private Location(byte value)
                    {
                        _value = value;
                    }

                    public bool IsFrontLeft => this == FrontLeft;

                    public bool IsFrontRight => this == FrontRight;

                    public bool IsRearLeft => this == RearLeft;

                    public bool IsRearRight => this == RearRight;
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
                .For<Struct>(@struct => @struct
                    .AttributedWith(
                        typeof(DescriptionAttribute),
                        description => description.WithArguments((Name: string.Empty, Value: "\"Represents the Location of the Wheel on the Car\"")))
                    .AttributedWith(monify => monify.Named(monify => monify
                        .Named(typeof(MonifyAttribute))
                        .WithArguments(type => type.Named(typeof(byte)))))
                    .Named("Location")
                    .Enumerate(
                        (member, @struct) => @struct.WithFields(field => field
                            .AttributedWith(
                                typeof(DescriptionAttribute),
                                description => description.WithArguments((Name: string.Empty, Value: $"\"{member.Description}\"")))
                            .IsReadOnly(true)
                            .IsStatic(true)
                            .Named(member.Name)
                            .OfType((Name: "Location", Qualifier: "MooVC.Testing.Mechanics.Car"))
                            .WithDefault(member.Index.ToString())
                            .WithScope(Scopes.Public)),
                        members)
                    .Enumerate(
                        (member, @struct) => @struct.WithProperties(property => property
                            .WithBehaviours(methods => methods
                                .WithGet($"this == {member.Name};")
                                .WithSet(setter => setter.WithMode(Property.Methods.Setter.Modes.ReadOnly)))
                            .Named($"Is{member.Name}")
                            .OfType(typeof(bool))),
                        members)
                    .WithBehavior(Struct.Kinds.ReadOnly + Struct.Kinds.Record)
                    .WithConstructors(constructor => constructor
                        .WithBody("_value = value;")
                        .WithParameters((Name: "Value", Type: typeof(byte)))
                        .WithScope(Scopes.Private)))
               .From("MooVC.Testing.Mechanics.Car")
               .ImportReferences();

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }
    }
}