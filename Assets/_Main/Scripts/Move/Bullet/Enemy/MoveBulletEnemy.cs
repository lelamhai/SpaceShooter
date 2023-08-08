using UnityEngine;

public class MoveBulletEnemy : BaseMove
{
    protected override void SetDefaultValue()
    {
        _direction = Vector3.down;
        _moveSpeed = 5f;
    }
}
