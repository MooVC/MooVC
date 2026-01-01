namespace MooVC.Syntax.CSharp.Members.EventTests;

using MooVC.Syntax.CSharp.Elements;

internal static class EventTestsData
{
    public const string DefaultHandler = "Handler";
    public const string DefaultName = "Occurred";

    public static Event Create(
        string handler = DefaultHandler,
        string name = DefaultName,
        Event.Methods? behaviours = default,
        Scope? scope = default)
    {
        var subject = new Event
        {
            Handler = new Symbol { Name = handler },
            Name = name,
        };

        if (behaviours is not null)
        {
            subject.Behaviours = behaviours;
        }

        if (scope is not null)
        {
            subject.Scope = scope;
        }

        return subject;
    }
}