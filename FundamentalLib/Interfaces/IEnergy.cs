using FundamentalLib.Classes;

namespace FundamentalLib.Interfaces
{
    public interface IEnergy : IResource
    {
        BigDouble MaxAmount { get; set; }
    }
}