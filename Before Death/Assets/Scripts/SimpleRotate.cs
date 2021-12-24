using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    float rot;
    // Start is called before the first frame update
    void Start()
    {
        rot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rot += Time.deltaTime *5;
        transform.Rotate(new Vector3(0,0,rot));
    }
}
