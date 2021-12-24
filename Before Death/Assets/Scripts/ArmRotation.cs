using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{

    private Fall fall;
    [SerializeField]
    private int rotationSpeed;
    float random;

    bool continueCoroutine = true;
    void Start()
    {
        fall = GetComponentInParent<Fall>();
        random = Random.Range(0,35);

        StartCoroutine(RotateArm());

    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator RotateArm()
    {

        while(continueCoroutine)
        {
            random = Random.Range(5,75);
            float x = (fall.FacingDirection * 35 + 205 + random);
            while(Mathf.Abs(x - transform.rotation.eulerAngles.z) > 0.05f)
            {
                Quaternion rotation = Quaternion.Euler(0,(fall.FacingDirection ==1 ? 0 :180), x);
                this.transform.rotation= Quaternion.Slerp(transform.rotation, rotation, rotationSpeed*Time.deltaTime);
                yield return null;
            }
            yield return null;
        }
    }
}
