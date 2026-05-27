using Fundamental.Core.StageSettings;
using Fundamental.Interfaces;

namespace Fundamental.Core;

public class VacuumSettings : IVacuumSettings
{
    private bool _state = false;

    private Dictionary<string, IStageSettings> _stageInfo = [];

    public VacuumSettings()
    {
        IStageSettings microworldStageSettings = new Microworld();
        _stageInfo["Microworld"] = microworldStageSettings;
    }
    public bool State
    {
        get => _state;
        set { _state = value;}
    }

    public Dictionary<string, IStageSettings> StageInfo => _stageInfo;
}