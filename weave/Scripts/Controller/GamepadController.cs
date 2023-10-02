using Godot;

namespace weave.Controller;

public sealed class GamepadController : IController
{
    private const float DeadZone = 0.2f;
    private readonly int _deviceId;
    int IController.DeviceId => _deviceId;
    public Controller Type => Controller.Gamepad;

    public GamepadController(int deviceId)
    {
        _deviceId = deviceId;
    }

    bool IController.IsTurningLeft()
    {
        return Input.GetJoyAxis(_deviceId, JoyAxis.LeftX) < -DeadZone;
    }

    bool IController.IsTurningRight()
    {
        return Input.GetJoyAxis(_deviceId, JoyAxis.LeftX) > DeadZone;
    }

    public bool Equals(IController other)
    {
        if (other is GamepadController gamepadController)
            return _deviceId == gamepadController._deviceId;

        return false;
    }
}
