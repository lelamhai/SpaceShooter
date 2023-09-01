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
        OpenInventory();
        CloseInventory();
        if (_isJoystick) return;
        Keyboard();
    }

    private void Keyboard()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        _MovePos = new Vector2(x, y);
    }

    private void OpenInventory()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIManager.Instance.SetPanelState(TypePanelUI.Inventory, PanelState.Show);
        }
    }

    private void CloseInventory()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UIManager.Instance.SetPanelState(TypePanelUI.Inventory, PanelState.Hide);
        }
    }

    protected override void SetDefaultValue()
    {}
}
