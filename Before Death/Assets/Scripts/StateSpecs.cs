using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StateSpecs
{
    [SerializeField]
    public Sprite[] animationSprites;
    [SerializeField]
    public AudioClip scream;
    [SerializeField]
    public AudioClip hurt; 
}

[System.Serializable]
public struct StateCommonSpecs
{
    [SerializeField]
    public AudioSource screamSource;
    [SerializeField]
    public AudioSource hurtSource;
    [SerializeField]
    public SpriteRenderer[] renderers;
    public ParticleSystem particle;
}
