namespace MooVC.Syntax.CSharp.DefinitionTests;

using System.ComponentModel;
using System.Globalization;
using Monify;
using MooVC.Syntax;
using Attribute = System.Attribute;
using Options = MooVC.Syntax.CSharp.Options;

public sealed partial class WhenToSnippetIsCalled
{
    public sealed class AsGenerator
    {
        private static readonly Options _options = new Options()
            .WithNamespace(Qualifier.Options.Block)
            .WithTypes(types => types
                .WithQualifications(qualifications => qualifications
                    .WithFormat(Qualification.Options.Formats.Global)));

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
                    .AttributedWith(
                        typeof(AttributeUsageAttribute),
                        attribute => attribute.WithArguments(
                            (Name: string.Empty, Value: "global::System.AttributeTargets.Property"),
                            (Name: nameof(AttributeUsageAttribute.AllowMultiple), Value: "false"),
                            (Name: nameof(AttributeUsageAttribute.Inherited), Value: "false")))
                    .DerivesFrom(typeof(Attribute))
                    .Named("IdentityAttribute")
                    .WithScope(Scopes.Internal))
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
                    .AttributedWith(
                        typeof(AttributeUsageAttribute),
                        attribute => attribute.WithArguments(
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
                    .WithScope(Scopes.Internal))
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
                            attribute => attribute.WithArguments((Name: string.Empty, Value: "\"The Pressure of the Tyre on the Wheel\"")))
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
                    public readonly partial record struct Location
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
                .For<Struct>(@struct => @struct
                    .AttributedWith(
                        typeof(DescriptionAttribute),
                        attribute => attribute.WithArguments((Name: string.Empty, Value: "\"Represents the Location of the Wheel on the Car\"")))
                    .AttributedWith(monify => monify.Named(monify => monify
                        .Named(typeof(MonifyAttribute))
                        .WithArguments(type => type.Named(typeof(byte)))))
                    .Named("Location")
                    .Enumerate(
                        (member, @struct) => @struct.WithFields(field => field
                            .AttributedWith(
                                typeof(DescriptionAttribute),
                                attribute => attribute.WithArguments((Name: string.Empty, Value: $"\"{member.Description}\"")))
                            .IsReadOnly(true)
                            .IsStatic(true)
                            .Named(member.Name)
                            .OfType((Name: "Location", Qualifier: "MooVC.Testing.Mechanics.Car"))
                            .WithDefault(member.Index.ToString(CultureInfo.InvariantCulture))
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
               .From("MooVC.Testing.Mechanics.Car");

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }

        [Test]
        public async Task GivenInstructionsWhenClassImplementingInterfaceThenDefinitionIsCreated()
        {
            // Arrange
            const string expected = """
                namespace MooVC.Testing.Mechanics.Car.Register
                {
                    public sealed partial record Register
                        : global::Mu.Composition.IRegistrar
                    {
                        public static global::SimpleInjector.Container Register(
                            global::Microsoft.Extensions.Configuration.IConfiguration configuration,
                            global::SimpleInjector.Container container)
                        {
                            return container;
                        }
                    }
                }
                """;

            Symbol configuration = (Name: "IConfiguration", Qualifier: "Microsoft.Extensions.Configuration");
            Symbol container = (Name: "Container", Qualifier: "SimpleInjector");

            Definition content = Builder
                .New<Definition>()
                .For<Record>(record => record
                    .Implements((Name: "IRegistrar", Qualifier: "Mu.Composition"))
                    .Named("Register")
                    .WithMethods(register => register
                        .Accepts((Name: "Configuration", Type: configuration))
                        .Accepts((Name: "Container", Type: container))
                        .Named("Register")
                        .Returns(result => result
                            .OfType(container)
                            .WithMode(Result.Modes.Synchronous))
                        .WithExtensibility(Modifiers.Static)
                        .WithBody("return container;")))
                .From("MooVC.Testing.Mechanics.Car.Register");

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }

        [Test]
        public async Task GivenInstructionsWhenClassImplementingInterfaceWithMultipleMethodsThenDefinitionIsCreated()
        {
            // Arrange
            const string expected = """
                namespace MooVC.Testing.Mechanics.Car
                {
                    public sealed partial class Allocator
                        : global::Mu.Modelling.Services.IAllocator<global::MooVC.Testing.Mechanics.Car.Registration>
                    {
                        public override global::System.Threading.Tasks.ValueTask<global::MooVC.Testing.Mechanics.Car.Registration> Allocate<TUseCase>(
                            TUseCase useCase,
                            global::System.Threading.CancellationToken cancellationToken)
                            where TUseCase : global::Mu.Modelling.Behavior.UseCase
                        {
                            throw new NotImplementedException();
                        }

                        public override global::System.Threading.Tasks.ValueTask Confirm(
                            global::MooVC.Testing.Mechanics.Car.Registration identity,
                            global::System.Threading.CancellationToken cancellationToken)
                        {
                            return ValueTask.CompletedTask;
                        }

                        public override global::System.Threading.Tasks.ValueTask Surrender(
                            global::MooVC.Testing.Mechanics.Car.Registration identity,
                            global::System.Threading.CancellationToken cancellationToken)
                        {
                            return ValueTask.CompletedTask;
                        }
                    }
                }
                """;

            Definition content = Builder
                .New<Definition>()
                .For<Class>(@class => @class
                    .Implements(
                        (Name: "IAllocator", Qualifier: "Mu.Modelling.Services"),
                        @base => @base.WithArguments((Name: "Registration", Qualifier: "MooVC.Testing.Mechanics.Car")))
                    .Named("Allocator")
                    .WithMethods(allocate => allocate
                        .Accepts(useCase => useCase
                            .Named("UseCase")
                            .OfType((Name: "TUseCase", Qualifier: Qualifier.Unqualified)))
                        .Accepts(cancellationToken => cancellationToken
                            .Named("CancellationToken")
                            .OfType(typeof(CancellationToken)))
                        .Named("Allocate", declaration => declaration
                            .WithArguments(useCase => useCase
                                .Named("TUseCase")
                                .WithConstraints(constraint => constraint
                                    .WithBase((Name: "UseCase", Qualifier: "Mu.Modelling.Behavior")))))
                        .Returns(result => result
                            .OfType(typeof(ValueTask), task => task.WithArguments((Name: "Registration", Qualifier: "MooVC.Testing.Mechanics.Car")))
                            .WithMode(Result.Modes.Synchronous))
                        .WithExtensibility(Modifiers.Override)
                        .WithBody("throw new NotImplementedException();")
                        .WithScope(Scopes.Public))
                    .WithMethods(confirm => confirm
                        .Accepts(identity => identity
                            .Named("Identity")
                            .OfType((Name: "Registration", Qualifier: "MooVC.Testing.Mechanics.Car")))
                        .Accepts(cancellationToken => cancellationToken
                            .Named("CancellationToken")
                            .OfType(typeof(CancellationToken)))
                        .Named("Confirm")
                        .Returns(typeof(ValueTask), task => task.WithMode(Result.Modes.Synchronous))
                        .WithExtensibility(Modifiers.Override)
                        .WithBody("return ValueTask.CompletedTask;")
                        .WithScope(Scopes.Public))
                    .WithMethods(surrender => surrender
                        .Accepts(identity => identity
                            .Named("Identity")
                            .OfType((Name: "Registration", Qualifier: "MooVC.Testing.Mechanics.Car")))
                        .Accepts(cancellationToken => cancellationToken
                            .Named("CancellationToken")
                            .OfType(typeof(CancellationToken)))
                        .Named("Surrender")
                        .Returns(typeof(ValueTask), task => task.WithMode(Result.Modes.Synchronous))
                        .WithExtensibility(Modifiers.Override)
                        .WithBody("return ValueTask.CompletedTask;")
                        .WithScope(Scopes.Public)))
                .From("MooVC.Testing.Mechanics.Car");

            // Act
            var actual = content.ToSnippet(_options);

            // Assert
            _ = await Assert.That(actual.ToString()).IsEqualTo(expected);
        }
    }
}