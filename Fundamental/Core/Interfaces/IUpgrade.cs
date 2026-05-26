using Fundamental.Core;

namespace Fundamental.Interfaces;

public interface IUpgrade
{
    public string Name { get; set; }
    public bool Bought { get; set; }
    public string Color { get; }
    public Func<bool> Condition { get; }
    public Func<int> Power { get; }
    public Func<string> Effect { get; }
    public Func<BigDouble> Cost { get; }
    public IResourceTarget Resource { get; }
    public string Image { get; }
}