using TMPro;
using UnityEngine;

namespace Perelesoq.TestAssignment.Core.ControlPanel
{
    public abstract class DeviceWidgetView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;

        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return;
            }
            _nameText.text = name;
        }
    }
}
