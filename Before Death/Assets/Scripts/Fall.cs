using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
   
    private CircleCollider2D playerCollider;

    [SerializeField]
    private float speed;
    private Vector3 targetPlace;

    public Vector3 TargetPlace {get{return targetPlace;}}


    float angle;
    public int FacingDirection{get; set;}

    GameManager gameManager;



    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameManager.Instance;
        FacingDirection = 1;
        cam = Camera.main;
    }
    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(!gameManager.gameEnd)
        {
            if(Input.GetMouseButton(0))
            {
                PlayerMove();
            }
            else
            {
                RotatePlayer(Vector3.zero, speed, 0);
            }
            gameManager.SecondsPassed+=Time.deltaTime;
        }
        else
        {
            RotatePlayer(Vector3.zero, speed, 0);
        }
    }

    void PlayerMove()
    {
        targetPlace = cam.ScreenToWorldPoint(Input.mousePosition);
        targetPlace.z = 0;
        float dir = targetPlace.x - transform.position.x;
        
        if(Mathf.Sign(dir) != FacingDirection && Mathf.Abs(dir)> 0.07f)
        {
            FacingDirection = (int)Mathf.Sign(dir);
            transform.Rotate(0,180,0);
        }
        float moveX = Mathf.Clamp(targetPlace.x, -gameManager.ScreenEndForReUse.x+1, gameManager.ScreenEndForReUse.x -1);
        float moveY = Mathf.Clamp(targetPlace.y, -gameManager.ScreenEndForReUse.y + 7.5f, gameManager.ScreenEndForReUse.y -2f);
        transform.MoveSmooth(x:moveX, y: moveY, speed:speed);
        RotatePlayer(targetPlace, speed, transform.eulerAngles.z -5);
    }

    private void RotatePlayer(Vector3 target, float rotationSpeed, float offset)
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0, (FacingDirection ==1 ? 0 :180), offset));        
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

}
