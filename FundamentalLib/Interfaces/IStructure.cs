using FundamentalLib.Classes;

namespace FundamentalLib.Interfaces;

public interface IStructure
{
    string Name { get; }
    double Cost { get; }
    IResourceTarget BuyingResource { get; }
    IResourceTarget Target { get; }
    IResourceTarget ResourceTarget { get; }
    BigDouble ResourceProducing { get; }
    double CostScaling { get; }
    double Producing { get; }
    double Improving { get; }
    BigDouble Amount { get; }
    int TrueAmount { get; }
    BigDouble TotalAmount { get; }
    BigDouble TrueTotal { get; }
    string Image { get; }
}