using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dangers : MonoBehaviour
{
    [SerializeField]
    private int effectToLife;


    public int EffectToLife { get => effectToLife; private set => effectToLife = value; }


    public virtual void DoDeed(int effecttolife)
    {
        GameManager.Instance.MostPossibleLife += effecttolife;
        PlayDeedSpecifics();
    }

    public virtual void PlayDeedSpecifics()
    {

    }
    
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        DoDeed(effectToLife);
        HurtSoundPlayer.PlayHurtSound();
        if(hitParticle.Instance.isParticlePlaying())
        {
            hitParticle.Instance.StopParticles();
        }
        hitParticle.Instance.SetPosition(collision.transform.position);
        hitParticle.Instance.PlayParticles();
    }
}

