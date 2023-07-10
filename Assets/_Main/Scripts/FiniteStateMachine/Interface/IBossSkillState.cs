using System.Collections;

public interface IBossSkillState 
{
    void OnExecute(BossSkill bossSkill);
    void OnExit();
}
