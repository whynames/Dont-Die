using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birth : MonoBehaviour
{
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
        StartCoroutine(BirthCoroutine());
    }
    
    private void Update() {
    }

    IEnumerator BirthCoroutine()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        Destroy(gameObject);
    }

}
