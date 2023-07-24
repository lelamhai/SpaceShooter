using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : BaseSkill
{
    [SerializeField] protected ShootBoss _shootBoss;

    protected override void loadSkills()
    {
        base.loadSkills();
        _shootBoss = this.GetComponent<ShootBoss>();
    }

    protected override void AddListSkill()
    {
        base.AddListSkill();
        _listSkill.Add(_shootBoss);
    }
}
