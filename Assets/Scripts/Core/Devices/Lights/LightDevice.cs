namespace Perelesoq.TestAssignment.Core.Devices.Lights
{
    public sealed class LightDevice : Device
    {
        public DeviceInputPort Input { get; }

        public LightDevice(float powerUsage)
        {
            Input = new(powerUsage);
        }
    }
}
