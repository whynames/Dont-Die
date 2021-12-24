using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitParticle : MonoSingleton<hitParticle>
{

    [SerializeField]
    private ParticleSystem ps;

    private void Start() {
    }

    // Update is called once per frame

    public void PlayParticles()
    {
        ps.Play();
    }
    public void StopParticles()
    {
        ps.Clear();
    } 

    public bool isParticlePlaying()
    {
        if(ps.isPlaying)
        {
            return true;
        }
        return false;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }
}
