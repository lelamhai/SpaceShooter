using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontalBoss : BaseMove, IBossSkillState
{
    [SerializeField] private float _timeExecuteSkill = 3f;
    public void OnExecute(BossSkill bossSkill)
    {
        _canMove = true;
        bossSkill.StopCoroutine(Timer(bossSkill));
        bossSkill.StartCoroutine(Timer(bossSkill));
    }

    public void OnExit()
    {
        _canMove = false;
    }

    private IEnumerator Timer(BossSkill bossSkill)
    {
        yield return new WaitForSeconds(_timeExecuteSkill);
        bossSkill.NextSkill();
    }

    protected override void Movement(Vector3 pos)
    {
        this.transform.Translate(pos * _moveSpeed * Time.deltaTime);

        if(-ScreenWidthHeight.Instance._WidthCamera / 2 > this.transform.position.x)
        {
            _direction = Vector3.right;
        } else if(ScreenWidthHeight.Instance._WidthCamera / 2 < this.transform.position.x)
        {
            _direction = Vector3.left;
        }
    }

    protected override void SetDefaultValue()
    {
        _direction = Vector3.left;
    }
}
