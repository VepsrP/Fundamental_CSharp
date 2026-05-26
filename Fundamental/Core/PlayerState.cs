using Fundamental.ViewModels;
using Fundamental.ViewModels.Base;
using Fundamental.Interfaces;

namespace Fundamental.Core
{
    /// <summary>
    /// Единый контейнер состояния игрока. Зарегистрирован как Singleton через DI.
    /// </summary>
    public class PlayerState
    {
        #region Resources

        /// <summary>Ресурсы игрока</summary>
        public PlayerResources Resources { get; } = new();

        #endregion

        #region Collections

        /// <summary>Улучшения по стадиям: Stage -> [ID -> UpgradeViewModel]</summary>
        public Dictionary<int, Dictionary<int, UpgradeViewModel>> Upgrades { get; } = [];

        /// <summary>Строения по стадиям: Stage -> [ID -> Structure]</summary>
        public Dictionary<int, Dictionary<int, StructureViewModel>> Buildings { get; } = [];

        #endregion

        #region State

        /// <summary>Текущая активная стадия</summary>
        public int ActiveStage { get; set; } = 1;

        public IVacuumSettings Vacuum { get; } = new VacuumSettings();

        /// <summary>Активная вкладка</summary>
        public int MainTab { get; set; }

        #endregion

        #region Update Loop

        /// <summary>Обновить все строения — производство ресурсов</summary>
        public void UpdateBuildings()
        {
            if (!Buildings.TryGetValue(ActiveStage, out var stageBuildings)) return;

            foreach (var building in stageBuildings.Values)
            {
                if (building.Producing > BigDouble.Zero)
                {
                    building.Produce();
                }
            }
        }

        /// <summary>Полное обновление игрока</summary>
        public void Update()
        {
            UpdateBuildings();
        }

        #endregion
    }

    /// <summary>
    /// Хранилище ресурсов игрока
    /// </summary>
    public class PlayerResources
    {
        /// <summary>Микромасса</summary>
        public BigDouble Micromass { get; set; } = BigDouble.Zero;

        /// <summary>Энергия</summary>
        public BigDouble Energy { get; set; } = BigDouble.Zero;

        /// <summary>Масса</summary>
        public BigDouble Mass { get; set; } = BigDouble.Zero;

        /// <summary>Моли</summary>
        public BigDouble Moles { get; set; } = BigDouble.Zero;

        /// <summary>Звёздная пыль</summary>
        public BigDouble Stardust { get; set; } = BigDouble.Zero;
    }
}
