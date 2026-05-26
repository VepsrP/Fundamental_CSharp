using Fundamental.Interfaces;

namespace Fundamental.Core
{
    public static class GlobalBase
    {
        public static double Multiplier { get; } = 4.0;

        public static IVacuumSettings VacuumSettings { get; };
    }
}
