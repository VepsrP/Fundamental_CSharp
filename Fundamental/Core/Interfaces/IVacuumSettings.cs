namespace Fundamental.Interfaces
{
    public interface IVacuumSettings
    {
        bool True { get; set; }
        Dictionary<string, IStageSettings> StageInfo { get; }
    }
}