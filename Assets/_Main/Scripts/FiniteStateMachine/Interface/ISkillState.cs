using System.Collections;

public interface ISkillState 
{
    void OnExecute(BaseSkill bossSkill);
    void OnExit();
}
