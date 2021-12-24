using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : State
{
    public Baby(StateMachine stateMachine, PlayerEntity playerEntity, StateCommonSpecs stateCommonSpecs, StateSpecs stateSpecs) : base(stateMachine, playerEntity, stateCommonSpecs, stateSpecs)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(GameManager.Instance.SecondsPassed > 8)
        {
            stateMachine.ChangeState(playerEntity.KidState);
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
