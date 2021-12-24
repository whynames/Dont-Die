using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Old : State
{
    public Old(StateMachine stateMachine, PlayerEntity playerEntity, StateCommonSpecs stateCommonSpecs, StateSpecs stateSpecs) : base(stateMachine, playerEntity, stateCommonSpecs, stateSpecs)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(GameManager.Instance.SecondsPassed > 70)
        {
            stateMachine.ChangeState(playerEntity.VeryOldState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
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
