using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private List<WaveDataSO> _listWaveData = new List<WaveDataSO>();
    [SerializeField] private int _currentIndexWave = 0;
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
                StartCoroutine(SpawnWave(_currentWave._lisWave[i]));
            }
            yield return new WaitForSeconds(_currentWave._duration);
            StopAllCoroutines();
            _currentIndexWave++;

            if (_currentIndexWave < _listWaveData.Count)
            {
                StartCoroutine(SpawnData());
            } 
        }
        else
        {
            Debug.Log("The wave is duration 0", this);
            yield return null;
        }

    }

    private IEnumerator SpawnWave(WaveItemSO wave)
    {
        yield return new WaitForSeconds(wave._delay);
        for (int i = 1; i <= wave._numberGameObject; i++)
        {
            var point = SpawnGameObject.Instance.RandomPoint(FullScreen.Instance._WidthCamera / 2);
            SpawnGameObject.Instance.SpawnGameObject(wave._typeGameObject.ToString(), point);
        }
        StartCoroutine(SpawnWave(wave));
    }
}
