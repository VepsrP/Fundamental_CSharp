using Fundamental.Core.StageSettings;
using Fundamental.Interfaces;

namespace Fundamental.Core;

public class VacuumSettings : IVacuumSettings
{
    private bool _true = false;

    private Dictionary<string, IStageSettings> _stageInfo = [];

    public VacuumSettings()
    {
        IStageSettings microworldStageSettings = new Microworld();
        _stageInfo["Microworld"] = microworldStageSettings;
    }
    public bool True
    {
        get => _true;
        set { _true = value;}
    }

    public Dictionary<string, IStageSettings> StageInfo => _stageInfo;
}