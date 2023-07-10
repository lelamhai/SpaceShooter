using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : BaseAttack, IBossSkillState
{
    [SerializeField] private float _timeExecuteSkill = 3f;

    public void OnExecute(BossSkill bossSkill)
    {
        _canShoot = true;
        bossSkill.StartCoroutine(Timer(bossSkill));
    }

    public void OnExit()
    {
        _canShoot = false;
    }

    private IEnumerator Timer(BossSkill bossSkill)
    {
        yield return new WaitForSeconds(_timeExecuteSkill);
        bossSkill.NextSkill();
    }

    protected override void SpawnBullet()
    {
        SpawnBulletEnemy.Instance.SpawnGameObject(TypeBulletEnemy.RedBulletEnemy.ToString(), _point.position);
    }

    protected override void SetDefaultValue()
    {
        _durationDelayShooting = 1f;
    }
}
