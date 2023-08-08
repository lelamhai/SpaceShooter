using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Vector2 _MovePos { get; private set; }
    private bool _isJoystick = false;

    public void Movement(Vector2 currentPos, bool active)
    {
        _MovePos = currentPos;
        _isJoystick = active;
    }

    private void Update()
    {
        if (_isJoystick) return;
        Keyboard();
    }

    private void Keyboard()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        _MovePos = new Vector2(x, y);
    }

    protected override void SetDefaultValue()
    {}
}
