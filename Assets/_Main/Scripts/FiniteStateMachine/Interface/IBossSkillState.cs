using System.Collections;

public interface IBossSkillState 
{
    void OnExecute(BaseSkill bossSkill);
    void OnExit();
}
