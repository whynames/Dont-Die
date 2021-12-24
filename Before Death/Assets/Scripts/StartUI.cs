using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class StartUI : MonoBehaviour
{

    [SerializeField]
    GameObject birth;
    [SerializeField]
    Image image;

    [SerializeField]
    TMP_Text theSurvivorText;
    private void Start() 
    {
        PlayerPrefs.SetFloat("Seconds", 0);
        #if UNITY_ANDROID
        Admob.Instance.ShowInterstitial();
        #endif

        image.rectTransform.DOAnchorPosY(8,0.2f).SetLoops(-1,LoopType.Yoyo).SetRelative();
        birth.transform.DOScale(0.05f, 0.3f).SetLoops(-1,LoopType.Yoyo).SetRelative();
        theSurvivorText.text = string.Concat("The <color=black>SURVIVOR</color> lived \n <color=black>", PlayerPrefs.GetInt("theSurvivor").ToString(), "</color>\nyears");
    }
    public void StartGame()
    {
        #if UNITY_ANDROID
        Admob.Instance.CloseBanner();
        #endif
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void Update() {
    }

    public void Setting()
    {

    }

    public void AdjustSound(float value)
    {
        AudioListener.volume = value;
    }
}
