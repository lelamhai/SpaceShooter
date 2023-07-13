using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : BaseSkill
{
    [SerializeField] protected ShootEnemy _shootEnemy;

    protected override void loadSkills()
    {
        base.loadSkills();
        _shootEnemy = this.GetComponent<ShootEnemy>();
    }

    protected override void AddListSkill()
    {
        base.AddListSkill();
        _listSkill.Add(_shootEnemy);
    }
}
