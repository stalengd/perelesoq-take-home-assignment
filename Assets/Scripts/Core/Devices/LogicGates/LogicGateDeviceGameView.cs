using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.LogicGates
{
    public sealed class LogicGateDeviceGameView : MonoBehaviour
    {
        [SerializeField] private Renderer _inputPortAIndicator;
        [SerializeField] private Renderer _inputPortBIndicator;
        [SerializeField] private Renderer _outputPortIndicator;
        [SerializeField] private Material _portPoweredMaterial;
        [SerializeField] private Material _portUnpoweredMaterial;

        public void SetInputAPowered(bool isPowered)
        {
            SetIndicatorPowered(_inputPortAIndicator, isPowered);
        }

        public void SetInputBPowered(bool isPowered)
        {
            SetIndicatorPowered(_inputPortBIndicator, isPowered);
        }

        public void SetOutputPowered(bool isPowered)
        {
            SetIndicatorPowered(_outputPortIndicator, isPowered);
        }

        private void SetIndicatorPowered(Renderer indicator, bool isPowered)
        {
            indicator.material = isPowered ? _portPoweredMaterial : _portUnpoweredMaterial;
        }
    }
}
