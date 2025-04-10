using R3;

namespace Perelesoq.TestAssignment.Core.Devices.LogicGates
{
    public sealed class LogicGateDevice : Device
    {
        public DeviceInputPort InputA { get; }
        public DeviceInputPort InputB { get; }
        public DeviceOutputPort Output { get; }

        public LogicOperation Operation { get; }

        public LogicGateDevice(LogicOperation operation)
        {
            Operation = operation;

            InputA = new();
            InputB = new();
            Output = new();

            InputA.IsPowered.Skip(1).Subscribe(_ => RefreshOutput());
            InputB.IsPowered.Skip(1).Subscribe(_ => RefreshOutput());
        }

        private void RefreshOutput()
        {
            Network.SetOutputPowered(Output, DoOperation(Operation, InputA.IsPowered.Value, InputB.IsPowered.Value));
        }

        private static bool DoOperation(LogicOperation operation, bool a, bool b)
        {
            return operation switch
            {
                LogicOperation.And => a & b,
                LogicOperation.Or => a | b,
                _ => false,
            };
        }
    }
}
