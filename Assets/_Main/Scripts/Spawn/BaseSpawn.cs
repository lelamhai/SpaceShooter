using UnityEngine;

public abstract class BaseSpawn : BaseMonoBehaviour
{
    [Header("Base Spawn")]
    [SerializeField] protected BasePrefabs _basePrefabs = null;
    [SerializeField] protected BaseHolders _baseHolders = null;
    [SerializeField] protected Vector3 _point;

    public Transform SpawnGameObject(string name, Vector3 point)
    {
        Transform gameObject = FindInHolders(name);
        if (gameObject != null)
        {
            SetPoint(gameObject, point);
            SetActive(gameObject, true);
            RemoveGameObjectHolders(gameObject);
        } else
        {
            gameObject = FindInPrefabs(name);
            if (gameObject == null) return null;
            gameObject = Clone(gameObject);
            SetName(gameObject, name);
            SetPoint(gameObject, point);
            SetActive(gameObject, true);
            SetParent(gameObject, _baseHolders.transform);
        }

        return gameObject;
    }

    private Transform FindInHolders(string name)
    {
        if (_baseHolders == null) return null;
        Transform gameObject = _baseHolders.FindGameObject(name);
        if (gameObject == null) return null;
        return gameObject;
    }

    private Transform FindInPrefabs(string name)
    {
        Transform gameObject = _basePrefabs.FindGameObject(name);
        if (gameObject == null) return null;
        return gameObject;
    }

    private Transform Clone(Transform gameObject)
    {
        return Instantiate(gameObject);
    }

    private void SetName(Transform gameObject,string name)
    {
        gameObject.name = name;
    }

    private void SetActive(Transform gameObject, bool active)
    {
        gameObject.gameObject.SetActive(active);
    }

    private void SetPoint(Transform gameObject, Vector3 point)
    {
        gameObject.SetPositionAndRotation(point, Quaternion.identity);
    }

    private void SetParent(Transform gameObject, Transform parent)
    {
        gameObject.SetParent(parent);
    }

    public void AddGameObjectHolders(Transform gameobject)
    {
        _baseHolders.AddObjectPool(gameobject);
    }

    public void RemoveGameObjectHolders(Transform gameobject)
    {
        _baseHolders.RemoveObjectPool(gameobject);
    }

    public Vector2 RandomPoint(float x)
    {
        var posX = Random.Range(-x, x);
        var posY = _point.y;
        var posZ = 0;

        return new Vector3(posX, posY, posZ);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadScript();
    }

    private void LoadScript()
    {
        Transform prefab = transform.Find("Prefabs");
        _basePrefabs = prefab.GetComponent<BasePrefabs>();

        Transform holder = transform.Find("Holders");
        if (holder != null)
        {
            _baseHolders = holder.GetComponent<BaseHolders>();
        }

        Transform point = transform.Find("Point");
        if (point == null) return;
        _point = point.position;
    }
}