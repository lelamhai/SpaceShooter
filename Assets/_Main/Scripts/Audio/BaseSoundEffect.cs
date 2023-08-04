using UnityEngine;

public abstract class BaseSoundEffect : BaseMonoBehaviour
{
    [SerializeField] protected AudioClip _audioClipDeadGamobject;
    [SerializeField] protected AudioClip _audioClipHitGamobject;
    [SerializeField] protected AudioClip _audioClipAttackGamobject;

    public void PlaySoundDead()
    {
        if (_audioClipDeadGamobject == null) return;
        AudioManager.Instance.EffectPlaySound(_audioClipDeadGamobject);
    }

    public void PlaySoundHit()
    {
        if (_audioClipHitGamobject == null) return;
        AudioManager.Instance.EffectPlaySound(_audioClipHitGamobject);
    }

    public void PlaySoundAttack()
    {
        if (_audioClipAttackGamobject == null) return;
        AudioManager.Instance.EffectPlaySound(_audioClipAttackGamobject);
    }

    protected override void SetDefaultValue()
    {}
}
