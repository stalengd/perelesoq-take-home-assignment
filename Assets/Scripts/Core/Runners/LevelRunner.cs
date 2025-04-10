using System;
using System.Collections.Generic;
using Perelesoq.TestAssignment.Core.DeviceInitializers;
using Perelesoq.TestAssignment.Core.DevicePresenters;
using Perelesoq.TestAssignment.Core.Devices;
using Perelesoq.TestAssignment.Core.Di;
using UnityEngine;
using Zenject;

namespace Perelesoq.TestAssignment.Core.Runners
{
    public sealed class LevelRunner : IDisposable
    {
        private DiContainer _diContainer;
        private DeviceNetwork _deviceNetwork;
        private DeviceNetworkDiagnosticsContainer _diagnostics;
        private DevicePresenterManager _presenterManager;

        public void Start()
        {
            PrepareDi();

            // This is sort of hit to performance on initial start, but this game is a prototype.
            var deviceInitializers = UnityEngine.Object.FindObjectsOfType<DeviceInitializer>(includeInactive: false);

            _deviceNetwork = new DeviceNetwork();
#if DEBUG
            _diagnostics = new(_deviceNetwork);
#endif
            var devices = new List<Device>();
            _presenterManager = new DevicePresenterManager();
            foreach (var initializer in deviceInitializers)
            {
                _diContainer.Inject(initializer);
                var device = initializer.Initialize();
                device.Metadata = initializer.CreateDeviceMetadata(device);
                _deviceNetwork.AddDevice(device);
                devices.Add(device);
            }

            for (var i = 0; i < devices.Count; i++)
            {
                var initializer = deviceInitializers[i];
                var device = devices[i];
                initializer.InitializeConnections(device, _deviceNetwork);
                var presenter = initializer.InitializePresenter(device);
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
            var deltaTime = TimeSpan.FromSeconds(Time.deltaTime);
            foreach (var device in _deviceNetwork.Devices)
            {
                device.Update(deltaTime);
            }

            _presenterManager.Update();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _diagnostics?.LogDevicesTable();
            }
        }

        public void Dispose()
        {
            _presenterManager.Dispose();
        }

        private void PrepareDi()
        {
            var sceneContext = SceneContext.Create();
            sceneContext.Install();

            _diContainer = sceneContext.Container;

            var levelContextInstallers = UnityEngine.Object.FindObjectsOfType<LevelContextInstaller>();
            foreach (var levelInstaller in levelContextInstallers)
            {
                _diContainer.Inject(levelInstaller);
                levelInstaller.InstallBindings();
            }

            LevelViewInstaller.Install(_diContainer);
            LevelModelInstaller.Install(_diContainer);

            sceneContext.Resolve();
        }
    }
}
