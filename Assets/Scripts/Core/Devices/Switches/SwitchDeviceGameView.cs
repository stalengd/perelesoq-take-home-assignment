using UnityEngine;

namespace Perelesoq.TestAssignment.Core.Devices.Switches
{
    public sealed class SwitchDeviceGameView : MonoBehaviour
    {
        [SerializeField] private Transform _buttonRoot;
        [SerializeField] private Vector3 _buttonOnRotation;
        [SerializeField] private Vector3 _buttonOffRotation;
        [Space]
        [SerializeField] private Renderer _indicator;
        [SerializeField] private Material _indicatorOnMaterial;
        [SerializeField] private Material _indicatorOffMaterial;

        public void SetIsOn(bool isOn)
        {
            _buttonRoot.localRotation = Quaternion.Euler(isOn ? _buttonOnRotation : _buttonOffRotation);
            _indicator.material = isOn ? _indicatorOnMaterial : _indicatorOffMaterial;
        }
    }
}
