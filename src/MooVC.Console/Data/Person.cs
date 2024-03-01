namespace MooVC.Console.Data;

using MooVC.Data;

public sealed partial record Person
    : IFeature<Name>
{
}