using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<WaveDataSO> _listWaveData = new List<WaveDataSO>();
    [SerializeField] private int _currentIndexWave = 0;
    [SerializeField] private float _timer = 1;

    private WaveDataSO _currentWave;
    private void Awake()
    {
        GameManager.Instance.SetGameState(GameStates.SetupLevel);
    }

    private void Start()
    {
        if (_listWaveData.Count > 0)
        {
            StartCoroutine(SpawnData());
        }
        else
        {
            Debug.Log("List Level empty", this);
        }
    }

    private IEnumerator SpawnData()
    {
        _currentWave = _listWaveData[_currentIndexWave];
        if (_currentWave._duration > 0)
        {
            for (int i = 0; i < _currentWave._lisWave.Count; i++)
            {
                StartCoroutine(SpawnWave(_currentWave._lisWave[i], _currentWave._duration));
            }
            yield return new WaitForSeconds(_currentWave._duration);
            _currentIndexWave++;
            if (_currentIndexWave < _listWaveData.Count)
            {
                StartCoroutine(SpawnData());
            } else
            {
                StopAllCoroutines();
            }
        }
        else
        {
            Debug.Log("The wave is duration 0", this);
            yield return null;
        }

    }

    private IEnumerator SpawnWave(WaveItemSO wave, float duration)
    {
        for (int i = 1; i <= wave._numberEnemy; i++)
        {
            var point = SpawnEnemy.Instance.RandomPoint(ScreenWidthHeight.Instance._WidthCamera / 2);
            SpawnEnemy.Instance.SpawnGameObject(wave._typeEnemy.ToString(), point);
        }

        yield return new WaitForSeconds(wave._delay);
        _timer += wave._delay;
       
        if (_timer < duration)
        {
            StartCoroutine(SpawnWave(wave, duration));
        } else
        {
            StopCoroutine(SpawnWave(wave, duration));
        }
    }
}
