using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSoundPlayer : MonoBehaviour
{
    public static AudioSource hurtSound;
    void Start()
    {
        hurtSound = GetComponent<AudioSource>();
    }

    public static void PlayHurtSound()
    {
        hurtSound.Play();
    }
}
