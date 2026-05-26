using Fundamental.Core;

namespace Fundamental.Interfaces
{
    public interface IEnergy : IResource
    {
        BigDouble MaxAmount { get; set; }
    }
}