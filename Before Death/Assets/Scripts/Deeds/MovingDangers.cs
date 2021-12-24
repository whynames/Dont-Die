using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDangers : Dangers
{

    [SerializeField]
    private Vector2 direction;
    [SerializeField]
    private float speed;
    public void Update() {
        transform.MoveSmooth(x:transform.position.x + direction.x, y: transform.position.y+ direction.y, speed:speed);
    }
    
    //public override void DoDeed(int effecttolife)
    //{
    //    base.DoDeed(effecttolife);
    //}

    //public override void OnTriggerEnter2D(Collider2D collision)
    //{
    //    base.OnTriggerEnter2D(collision);
    //}
}
