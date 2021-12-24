using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Devil : MonoBehaviour
{
    private GameObject devilMain;

    [SerializeField]
    private Transform lair;
    
    [SerializeField]
    private Transform spear;

    [SerializeField]
    private AudioSource devilsLaugh;
    
    private void OnEnable() {
        PlaySound();
        lair.DORotate(new Vector3(0,0, 20), 1).SetLoops(-1, LoopType.Yoyo).SetRelative();
        spear.DORotate(new Vector3(0,0, -20), 1).SetLoops(-1, LoopType.Yoyo).SetRelative();
    }
    public void PlayAd()
    {
        #if UNITY_ANDROID
        Admob.Instance.ShowRewardedAd();
        #endif
    }

    void PlaySound()
    {
        devilsLaugh.Play();
    }

}
