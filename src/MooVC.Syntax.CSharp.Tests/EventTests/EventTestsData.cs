namespace MooVC.Syntax.CSharp.EventTests;

internal static class EventTestsData
{
    public const string DefaultHandler = "Handler";
    public const string DefaultName = "Occurred";

    public static Event Create(
        string handler = DefaultHandler,
        string name = DefaultName,
        Event.Methods? behaviours = default,
        Scopes? scope = default)
    {
        var subject = new Event
        {
            Handler = new() { Name = handler },
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