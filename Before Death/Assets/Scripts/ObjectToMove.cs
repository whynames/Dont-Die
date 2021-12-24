using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToMove : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void Move()
    {
        transform.MoveSmooth(y: gameManager.ScreenEndForReUse.y +3, speed:speed);
        CheckOutofBounds();
    }

    public virtual void Reuse()
    {
        gameObject.SetActive(true);
        transform.MoveInstant(x:Random.Range(-gameManager.ScreenEndForReUse.x + 1f, gameManager.ScreenEndForReUse.x -1f), y: -gameManager.ScreenEndForReUse.y);
    }

    public virtual bool CheckOutofBounds()
    {
        if((this.gameObject.transform.position.y < -gameManager.ScreenEndForReUse.y -2)||(this.gameObject.transform.position.y > gameManager.ScreenEndForReUse.y +2))
        {
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
