namespace MooVC.Syntax.CSharp.Members.EventTests;

internal static class EventTestsData
{
    public const string DefaultHandler = "Handler";
    public const string DefaultName = "Occurred";

    public static Event Create(
        string handler = DefaultHandler,
        string name = DefaultName,
        Event.Methods? behaviours = null,
        Scope? scope = null)
    {
        var subject = new Event
        {
            Handler = new Symbol { Name = handler },
            Name = new Identifier(name),
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
