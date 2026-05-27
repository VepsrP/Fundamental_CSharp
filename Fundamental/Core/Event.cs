namespace Fundamental.Core;

public class Event(string text, Func<PlayerState, bool> condition)
{
    public string Text { get; } = text;
    public Func<PlayerState, bool> Condition { get; } = condition;
    public bool Played { get; set; } = false;
}