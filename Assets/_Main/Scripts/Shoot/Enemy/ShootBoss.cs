using System.Collections;
using UnityEngine;

public class ShootBoss : BaseAttack, ISkillState
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

    protected override void SpawnBullet()
    {
        SpawnBulletEnemy.Instance.SpawnGameObject(TypeBulletEnemy.RedBulletEnemy.ToString(), _point.position);
    }

    protected override void SetDefaultValue()
    {
        _timeShooting = 1f;
    }
}
