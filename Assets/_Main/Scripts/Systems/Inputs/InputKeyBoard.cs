using UnityEngine;

public class InputKeyboard : MonoBehaviour
{
    public Vector2 _MovementPos { get; private set; }

    private void Update()
    {
        Movement2D();
        Space();
    }

    private void Movement2D()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        var z = 0;
        var pos = new Vector3(x, y, z);
        InputManager.Instance.Movement(pos);
    }

    private void Space()
    {
        GetKeyDownSpace();
        GetKeyUpSpace();
    }

    private void GetKeyUpSpace()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
        }
    }

    private void GetKeyDownSpace()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
