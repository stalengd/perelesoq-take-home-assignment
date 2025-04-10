using System;
using R3;

namespace Perelesoq.TestAssignment.Core.Devices.Doors
{
    public sealed class DoorDevice : Device
    {
        public DeviceInputPort Input { get; }

        public TimeSpan TransitionDuration { get; }
        public TimeSpan TimeToArrive { get; private set; }
        public float ActiveRequiredPower { get; }
        public ReadOnlyReactiveProperty<DoorState> State => _state;

        private readonly ReactiveProperty<DoorState> _state = new();

        public DoorDevice(TimeSpan transitionDuration, float activeRequiredPower, bool isOpened)
        {
            Input = new();

            TransitionDuration = transitionDuration;
            ActiveRequiredPower = activeRequiredPower;
            _state.Value = isOpened ? DoorState.Opened : DoorState.Closed;
        }

        public void Open()
        {
            DoTransition(DoorState.Opened, DoorState.Opening, DoorState.Closed);
        }

        public void Close()
        {
            DoTransition(DoorState.Closed, DoorState.Closing, DoorState.Opened);
        }

        public void ToggleState()
        {
            if (_state.Value is DoorState.Opened or DoorState.Opening)
            {
                Close();
            }
            else
            {
                Open();
            }
        }

        public override void Update(TimeSpan deltaTime)
        {
            var state = _state.Value;
            if (state is DoorState.Closed or DoorState.Opened
                || !Input.IsPowered.Value)
            {
                return;
            }

            TimeToArrive -= deltaTime;

            if (TimeToArrive <= TimeSpan.Zero)
            {
                EndTransition();
            }
        }

        private void DoTransition(DoorState toState, DoorState viaState, DoorState oppositeEndState)
        {
            if (_state.Value == toState || _state.Value == viaState)
            {
                return;
            }

            TimeToArrive = _state.Value == oppositeEndState
                ? TransitionDuration
                : TransitionDuration - TimeToArrive;

            Network.SetInputPowerRequirement(Input, ActiveRequiredPower);

            _state.Value = viaState;
        }

        private void EndTransition()
        {
            TimeToArrive = TimeSpan.Zero;
            Network.SetInputPowerRequirement(Input, 0f);
            if (_state.Value == DoorState.Opening)
            {
                _state.Value = DoorState.Opened;
            }
            else if (_state.Value == DoorState.Closing)
            {
                _state.Value = DoorState.Closed;
            }
        }
    }
}
