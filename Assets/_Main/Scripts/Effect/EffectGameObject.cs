using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGameObject : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(HideGameObject());
    }

    private IEnumerator HideGameObject()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        SpawnEffect.Instance.AddGameObjectPool(this.transform);
    }
}
