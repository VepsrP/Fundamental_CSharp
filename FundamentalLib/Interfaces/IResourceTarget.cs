using FundamentalLib.Classes;

namespace FundamentalLib.Interfaces;

public interface IResourceTarget
{
    string Name { get; }
    BigDouble Amount { get; }

    void Increase(BigDouble value);
    void Decrease(BigDouble value, bool isTrue = false);
    void ResetAmount();
}