public class SpawnReward : SingletonSpawn<SpawnReward>
{
    private void OnEnable()
    {
        GameManager.Instance._StopGame += StopGame;
    }

    private void OnDisable()
    {
        GameManager.Instance._StopGame -= StopGame;
    }

    private void StopGame()
    {
        _baseHolders.DisableAllGameObject();
    }

    protected override void SetDefaultValue()
    {}
}