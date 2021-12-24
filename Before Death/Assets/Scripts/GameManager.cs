using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    
    #region CalculateDeathVariables
    public float SecondsPassed { get => secondsPassed; set => secondsPassed = value;}
    private float secondsPassed;
    public float MostPossibleLife;

    #endregion


    public Vector2 ScreenEndForReUse { get => screenEnd; }

    private Vector2 screenEnd;

    
    [SerializeField]
    private PlayerEntity pe;
    public PlayerEntity Pe {get => pe;}

    [SerializeField]
    private ParticleSystem ps;
    [SerializeField]
    private Transform groundPlatform;

    private Camera cam;

    public Camera Cam{get{return cam;}}

    public bool gameEnd;
    public bool isScoreShouldBeDefined;
    public bool isUISet;
    void Start()
    {
        GameManager.Instance.MostPossibleLife = PlayerPrefs.GetFloat("Seconds") + 75;
        GameManager.Instance.SecondsPassed = PlayerPrefs.GetFloat("Seconds");
        PlayerPrefs.SetFloat("Seconds", 0);
        isUISet = true;
        isScoreShouldBeDefined = false;
        gameEnd = false;
        cam = Camera.main;
        screenEnd = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    public IEnumerator DeathCameraMoveCoroutine()
    {
        MoveObjectsManager.Instance.canMove = false;

        float newY = cam.transform.position.y + 5;
        float speed = 0;

        while (cam.transform.position.y < newY)
        {
            speed += 4f * Time.deltaTime;
            cam.transform.MoveSmooth(y: newY, speed: speed);
            yield return null;
        }

        yield break;
    }

    void BringTheFloor()
    {
        groundPlatform.parent.MoveSmooth(y: pe.transform.position.y, speed: 15);
    }

    //[SerializeField]
    //private float fallStrenght;
    //void KeepFall()
    //{
    //    this.transform.Translate(new Vector3(0, -fallStrenght*Time.deltaTime, 0));
    //}
    public IEnumerator StartPlayerDeathCoroutine()
    {
        groundPlatform.parent.gameObject.SetActive(true);
        while(pe.transform.position.y > groundPlatform.transform.position.y)
        {
            BringTheFloor();
            yield return null;
        }
        ps.gameObject.transform.localScale = new Vector3(1, 1,1);
        ParticleSystem.MainModule _main = ps.main;    
        _main.startSpeed = 0.8f;
        PlayerPrefs.SetFloat("Seconds", GameManager.Instance.SecondsPassed);
        yield break;
    }
    public IEnumerator GameStartCoroutine()
    {
        while(pe.transform.position.y > 3)
        {
            pe.transform.MoveSmooth(y:0, speed:2);
            yield return null;
        }
        gameEnd = false;
    }
    public IEnumerator GameEndCoroutine()
    {
        isUISet = false;
        gameEnd = true;
        yield return StartPlayerDeathCoroutine();
        pe.StateMachine.ChangeState(pe.DeadState);
        pe.ActivateArm();
        isScoreShouldBeDefined = true;
        yield return DeathCameraMoveCoroutine();
        isScoreShouldBeDefined = false;
        isUISet = true;
    }

}


