using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVerticalBoss : BaseMove, ISkillState
{
    [SerializeField] private float _timeExecuteSkill = 3f;

    public void OnExecute(BaseSkill bossSkill)
    {
        _canMove = true;
        bossSkill.StopCoroutine(Timer(bossSkill));
        bossSkill.StartCoroutine(Timer(bossSkill));
    }

    public void OnExit()
    {
        _canMove = false;
    }

    private IEnumerator Timer(BaseSkill bossSkill)
    {
        yield return new WaitForSeconds(_timeExecuteSkill);
        bossSkill.NextSkill();
    }

    private void OnDisable()
    {
        _canMove = false;
    }

    protected override void Movement(Vector3 pos)
    {
        this.transform.Translate(pos * _moveSpeed * Time.deltaTime);

        if (-FullScreen.Instance._HeightCamera / 2 > this.transform.position.y)
        {
            _direction = Vector3.up;
        }
        else if (FullScreen.Instance._HeightCamera / 2 < this.transform.position.y)
        {
            _direction = Vector3.down;
        }
    }

    protected override void SetDefaultValue()
    {
        _direction = Vector3.down;
    }

  
}
