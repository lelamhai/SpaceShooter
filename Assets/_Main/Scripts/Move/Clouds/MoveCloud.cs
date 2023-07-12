using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : BaseMove
{
    protected override void Movement(Vector3 pos)
    {
        this.transform.Translate(pos * _moveSpeed * Time.deltaTime);
    }

    protected override void SetDefaultValue()
    {
        _direction = Vector3.down;
    }
}
