using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField]
    float speed;



    // Update is called once per frame
    void Update()
    {
        transform.MoveSmooth(y:transform.position.y + 1, speed: speed);
    }
}
