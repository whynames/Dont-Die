using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Young : State
{
    public Young(StateMachine stateMachine, PlayerEntity playerEntity, StateCommonSpecs stateCommonSpecs, StateSpecs stateSpecs) : base(stateMachine, playerEntity, stateCommonSpecs, stateSpecs)
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
        if(GameManager.Instance.SecondsPassed > 30)
        {
            stateMachine.ChangeState(playerEntity.MiddleAgedState);
        }
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
