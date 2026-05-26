namespace Fundamental.Interfaces
{
    public interface IVacuumSettings
    {
        bool State { get; set; }
        Dictionary<string, IStageSettings> StageInfo { get; }
    }
}