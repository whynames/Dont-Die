using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class State
{

    protected StateMachine stateMachine;
    protected bool isExitingState;
    protected float secondsPassed;
    protected float projectedLife;

    protected StateSpecs stateSpecs;

    protected StateCommonSpecs stateCommonSpecs;
    protected PlayerEntity playerEntity;

    public State(StateMachine stateMachine, PlayerEntity playerEntity, StateCommonSpecs stateCommonSpecs, StateSpecs stateSpecs)
    {
        this.playerEntity = playerEntity;
        this.stateSpecs = stateSpecs;
        this.stateCommonSpecs = stateCommonSpecs;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        SetupSprites(stateCommonSpecs.renderers, stateSpecs.animationSprites);
        SetUpAudio(stateCommonSpecs.screamSource, stateSpecs.scream);
        SetUpAudio(stateCommonSpecs.hurtSource, stateSpecs.hurt);
        stateCommonSpecs.screamSource.Play();

        DoChecks();
        secondsPassed = Time.time;
        isExitingState = false;
    }

    void SetUpAudio(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
    }
    public void SetupSprites(SpriteRenderer[] renderers, Sprite[] sprites )
    {
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].sprite = sprites[i];                
        }
    }
    public virtual void Exit()
    {
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {
        secondsPassed = Time.realtimeSinceStartup;

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks() { }

}
