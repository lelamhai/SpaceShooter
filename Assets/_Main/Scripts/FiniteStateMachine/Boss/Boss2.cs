using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : BaseSkill
{
    [SerializeField] protected Shoot180 _shootEnemy;

    protected override void loadSkills()
    {
        base.loadSkills();
        _shootEnemy = this.GetComponent<Shoot180>();
    }

    protected override void AddListSkill()
    {
        base.AddListSkill();
        _listSkill.Add(_shootEnemy);
    }
}
