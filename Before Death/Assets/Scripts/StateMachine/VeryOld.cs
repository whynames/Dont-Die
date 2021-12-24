using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeryOld : State
{
    Sprite cane;
    public VeryOld(StateMachine stateMachine, PlayerEntity playerEntity, StateCommonSpecs stateCommonSpecs, StateSpecs stateSpecs, Sprite cane) : base(stateMachine, playerEntity, stateCommonSpecs, stateSpecs)
    {
        this.cane = cane;   
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
