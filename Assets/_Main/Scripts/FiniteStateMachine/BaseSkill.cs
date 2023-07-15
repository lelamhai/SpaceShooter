using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : BaseMonoBehaviour
{
    [SerializeField] protected MoveVerticalBoss _moveVerticalBoss;
    [SerializeField] protected MoveHorizontalBoss _moveHorizontalBoss;

    protected List<ISkillState> _listSkill = new List<ISkillState>();
    protected ISkillState _currentSkill;
    protected ISkillState _lastSkill;

    private void OnEnable()
    {
        AddListSkill();
        _currentSkill = _moveVerticalBoss;
        ExecuteSkill();
    }

    public void NextSkill()
    {
        if (_currentSkill == null) return;
        ExitSkill();
        RandomSkill();
        ExecuteSkill();
    }

    private void RandomSkill()
    {
        do
        {
            int index = Random.Range(0, _listSkill.Count);
            _currentSkill = _listSkill[index];
        } while (_currentSkill == _lastSkill);

    }

    private void ExecuteSkill()
    {
        _currentSkill.OnExecute(this);
        _lastSkill = _currentSkill;
    }

    private void ExitSkill()
    {
        _currentSkill.OnExit();
    }

    protected override void SetDefaultValue()
    { }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        loadSkills();
    }

    protected virtual void loadSkills()
    {
        _moveVerticalBoss = this.GetComponent<MoveVerticalBoss>();
        _moveHorizontalBoss = this.GetComponent<MoveHorizontalBoss>();
        //_shootEnemy = this.GetComponent<ShootEnemy>();
    }

    protected virtual void AddListSkill()
    {
        _listSkill.Add(_moveVerticalBoss);
        _listSkill.Add(_moveHorizontalBoss);
        //_listSkill.Add(_shootEnemy);
    }
}
