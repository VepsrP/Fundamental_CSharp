namespace Fundamental.Interfaces
{
    public interface IResource
    {
        string Name { get; }
        string Image { get; }
        string Amount { get; set; }
    }
}
