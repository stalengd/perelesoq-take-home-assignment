using System;
using System.Collections.Generic;
using Perelesoq.TestAssignment.Core.DeviceInitializers;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using Perelesoq.TestAssignment.Core.Devices;
using Perelesoq.TestAssignment.Core.DeviceWidgets;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Runners
{
    public sealed class LevelRunner : IDisposable
    {
        private DeviceNetwork _deviceNetwork;
        private DeviceNetworkDiagnosticsContainer _diagnostics;
        private DevicePresenterManager _presenterManager;

        public void Start()
        {
            // This is sort of hit to performance on initial start, but this game is a prototype.
            var deviceInitializers = UnityEngine.Object.FindObjectsOfType<DeviceInitializer>(includeInactive: false);
            var widgetsContainer = UnityEngine.Object.FindObjectOfType<DeviceWidgetsContainer>();

            _deviceNetwork = new DeviceNetwork();
#if DEBUG
            _diagnostics = new(_deviceNetwork);
#endif
            var devices = new List<Device>();
            _presenterManager = new DevicePresenterManager();
            foreach (var initializer in deviceInitializers)
            {
                var device = initializer.Initialize(_deviceNetwork);
                devices.Add(device);
            }

            for (var i = 0; i < devices.Count; i++)
            {
                var initializer = deviceInitializers[i];
                var device = devices[i];
                initializer.InitializeConnections(device, _deviceNetwork);
                var presenter = initializer.InitializePresenter(device, widgetsContainer);
                if (presenter != null)
                {
                    _presenterManager.Add(presenter);
                }

                if (_diagnostics != null)
                {
                    initializer.PushDiagnostics(device, _diagnostics);
                }
            }

            _deviceNetwork.SetOutputActive(_deviceNetwork.PowerSource.Output, true);
            _deviceNetwork.SetOutputPowered(_deviceNetwork.PowerSource.Output, true);

            _presenterManager.Start();

        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _diagnostics?.LogDevicesTable();
            }
        }

        public void Dispose()
        {
            _presenterManager.Dispose();
        }
    }
}
