public enum TypeReward
{
    None,
    Coin,
    Health
}

public class SpawnReward : SingletonSpawn<SpawnReward>
{
    protected override void SetDefaultValue()
    {}
}