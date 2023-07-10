using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill : BaseMonoBehaviour
{

    [SerializeField] private MoveVerticalBoss _moveVerticalBoss;
    [SerializeField] private MoveHorizontalBoss _moveHorizontalBoss;
    [SerializeField] private ShootEnemy _shootEnemy;

    private List<IBossSkillState> _listSkill = new List<IBossSkillState>();
    private IBossSkillState _currentSkill;
    private IBossSkillState _lastSkill;

    private void Start()
    {
        AddListSkill();
        _currentSkill = _moveVerticalBoss;
        ExecuteSkill();
    }

    public void NextSkill()
    {
        if(_currentSkill == null) return;
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
    {}

    protected override void LoadComponent()
    {
        base.LoadComponent();
        loadSkills();
    }

    private void loadSkills()
    {
        _moveVerticalBoss = this.GetComponent<MoveVerticalBoss>();
        _moveHorizontalBoss = this.GetComponent<MoveHorizontalBoss>();
        _shootEnemy = this.GetComponent<ShootEnemy>();
    }

    private void AddListSkill()
    {
        _listSkill.Add(_moveVerticalBoss);
        _listSkill.Add(_moveHorizontalBoss);
        _listSkill.Add(_shootEnemy);
    }
}
