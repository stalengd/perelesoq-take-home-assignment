namespace Perelesoq.TestAssignment.Core.Util
{
    public static class PowerMath
    {
        public static float WattSecondToWattHour(float ws) => ws / 3600;
        public static float WattHourToWattSecond(float wh) => wh * 3600;
        public static float WattHourToKilowattHour(float wh) => wh / 1000;
        public static float KilowattHourToWattHour(float kwh) => kwh * 1000;
    }
}
