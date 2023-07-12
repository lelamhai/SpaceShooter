using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactPlayer : BaseImpact
{
    //protected override void DeadGameObject(GameObject collision)
    //{
    //    Debug.Log(collision.name);
    //    BaseSoundEffect _baseSoundEffect = collision.GetComponent<BaseSoundEffect>();
    //    _baseSoundEffect.PlaySoundDead();
    //    collision.SetActive(false);

    //    //base.DeadGameObject(collision);
    //    //this.gameObject.SetActive(false);
    //}

    //protected override void HitGameObject(GameObject transform)
    //{
    //    base.HitGameObject(transform);
    //    StartCoroutine(HitPlayer());
    //}

    //private IEnumerator HitPlayer()
    //{
    //    _model.color = Color.red;
    //    yield return new WaitForSeconds(1f);
    //    _model.color = Color.white;
    //}
}
