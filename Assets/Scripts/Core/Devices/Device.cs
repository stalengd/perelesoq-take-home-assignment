using System;

namespace Perelesoq.TestAssignment.Core.Devices
{
    public class Device
    {
        public DeviceMetadata Metadata { get; set; }
        public DeviceNetwork Network { get; set; }

        public virtual void Update(TimeSpan deltaTime) { }
    }
}
