using FundamentalLib.Classes;
using FundamentalLib.Core;

namespace FundamentalLib.Interfaces
{
    public interface IEnergy : IResource
    {
        BigDouble MaxAmount { get; set; }
    }
}