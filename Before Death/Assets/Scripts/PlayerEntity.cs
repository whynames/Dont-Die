using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }

    public NewBorn NewBornState { get; private set; }
    public Baby BabyState { get; private set; }
    public Kid KidState { get; private set; }
    public Young YoungState { get; private set; }
    public MiddleAged MiddleAgedState { get; private set; }
    public Old OldState { get; private set; }
    public VeryOld VeryOldState { get; private set; }

    public Dead DeadState { get; private set; }

    public StateSpecs newBornStateSpecs;
    public StateSpecs babyStateSpecs;
    public StateSpecs kidStateSpecs;
    public StateSpecs youngStateSpecs;
    public StateSpecs manStateSpecs;
    public StateSpecs oldManStateSpecs;
    public StateSpecs veryOldManStateSpecs;
    public StateSpecs deadStateSpecs;

    public StateCommonSpecs commonSpecs;
    GameManager gamemanager;

    [SerializeField]
    GameObject Arm;
    Sprite Cane;


    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.Instance;
        gamemanager.gameEnd = true;
        this.transform.MoveInstant(y:gamemanager.ScreenEndForReUse.y -0.5f);

        StartCoroutine(gamemanager.GameStartCoroutine());
        SetUpStates();
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();

        if((gamemanager.MostPossibleLife < gamemanager.SecondsPassed) && !gamemanager.gameEnd)
        {
            StartCoroutine(gamemanager.GameEndCoroutine());
        }
    }

    public void ActivateArm()
    {
        Arm.SetActive(true);
    }
    void SetUpStates()
    {

        StateMachine = new StateMachine();

        NewBornState = new NewBorn(this.StateMachine,this, commonSpecs, newBornStateSpecs);
        BabyState = new Baby(this.StateMachine,this, commonSpecs, babyStateSpecs);
        KidState = new Kid(this.StateMachine,this,commonSpecs, kidStateSpecs, Arm);
        YoungState = new Young(this.StateMachine,this,commonSpecs, youngStateSpecs);
        MiddleAgedState = new MiddleAged(this.StateMachine,this,commonSpecs, manStateSpecs);
        OldState = new Old(this.StateMachine,this,commonSpecs, oldManStateSpecs);
        VeryOldState = new VeryOld(this.StateMachine,this,commonSpecs, veryOldManStateSpecs, Cane);
        DeadState = new Dead(this.StateMachine,this,commonSpecs, deadStateSpecs);

        StateMachine.Initialize(NewBornState);
    }
}
