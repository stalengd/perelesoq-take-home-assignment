using System;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices
{
    [Serializable]
    public sealed class DeviceMetadata
    {
        // This should be localized and everything
        [field: SerializeField]
        public string Name { get; set; }
    }
}
