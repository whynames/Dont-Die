using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : State
{
    GameObject arm;

    public Kid(StateMachine stateMachine, PlayerEntity playerEntity, StateCommonSpecs stateCommonSpecs, StateSpecs stateSpecs, GameObject arm) : base(stateMachine, playerEntity, stateCommonSpecs, stateSpecs)
    {
        this.arm = arm;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        arm.SetActive(true);
    }



    public override void Exit()
    {
        base.Exit();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(GameManager.Instance.SecondsPassed > 15)
        {
            stateMachine.ChangeState(playerEntity.YoungState);
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
