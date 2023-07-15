using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : BaseAttack, ISkillState
{
    [SerializeField] private float _timeExecuteSkill = 3f;

    public void OnExecute(BaseSkill bossSkill)
    {
        _canShoot = true;
        bossSkill.StopCoroutine(Timer(bossSkill));
        bossSkill.StartCoroutine(Timer(bossSkill));
    }

    public void OnExit()
    {
        _canShoot = false;
    }

    private IEnumerator Timer(BaseSkill bossSkill)
    {
        yield return new WaitForSeconds(_timeExecuteSkill);
        bossSkill.NextSkill();
    }

    private void OnDisable()
    {
        _canShoot = false;
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
