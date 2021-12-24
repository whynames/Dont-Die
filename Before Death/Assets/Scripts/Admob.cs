using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Admob : MonoSingleton<Admob>
{
    #if UNITY_ANDROID

    public bool TestMode = true;

    public string BannerID = "ca-app-pub-8680535163018538/1780340205";
    public string InterstitialID = "ca-app-pub-8680535163018538/5116949980";
    public string RewardedID = "ca-app-pub-8680535163018538/8892543462";

    private BannerView Banner;
    private InterstitialAd Interstitial;
    private RewardedAd Rewarded;
    private bool isBannerLoaded = false;
    private bool isRewardEarned = false;

    private bool[] IsInterstitialsLoaded = new bool[5];

    private InterstitialAd[] InterstitialAds;
    // Start is called before the first frame update
    void Start()
    {
        if (TestMode)
        {
            BannerID = "ca-app-pub-3940256099942544/6300978111";
            InterstitialID = "ca-app-pub-3940256099942544/1033173712";
            RewardedID = "ca-app-pub-3940256099942544/5224354917";
        }

        MobileAds.Initialize(initStatus => { });

        InterstitialAds = new InterstitialAd[5];
        RequestBanner();
        RequestInterstitial();
        RequestRewardedAd();
    }

    #region Public Functions

    public void ShowBanner()
    {
        RequestBanner();
    }
    public void CloseBanner()
    {
        Banner.Destroy();
    }

    public void ShowInterstitial()
    {
        if(Interstitial.IsLoaded())
        {
            Interstitial.Show();
        }
    }
    public void ShowRewardedAd()
    {
        if(Rewarded.IsLoaded())
        {
            Rewarded.Show();
        }
    }
    #endregion

    #region Private Functions
    private void InitInterstitials()
    {
        for(int i=0;i<InterstitialAds.Length;i++)
        {
            InterstitialAds[i] = new InterstitialAd(InterstitialID);
            InterstitialAds[i].OnAdClosed += Interstitial_OnAdClosed;
            InterstitialAds[i].OnAdLoaded += Admob_OnAdLoaded;
            AdRequest request = new AdRequest.Builder().Build();
            Interstitial.LoadAd(request);
        }
    }

    private void Admob_OnAdLoaded(object sender, System.EventArgs e)
    {
        for (int i = 0; i < InterstitialAds.Length; i++)
        {
           if( sender.Equals(InterstitialAds[0]))
            {
                return;
            }
        }
    }

    private void RequestBanner()
    {
        Banner = new BannerView(BannerID, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = new AdRequest.Builder().Build();
        Banner.LoadAd(request);
    }
    private void RequestInterstitial()
    {
        Interstitial = new InterstitialAd(InterstitialID);
        Interstitial.OnAdClosed += Interstitial_OnAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        Interstitial.LoadAd(request);
    }

    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        RequestInterstitial();
    }
    private void RequestRewardedAd()
    {
        Rewarded = new RewardedAd(RewardedID);
        Rewarded.OnUserEarnedReward += Rewarded_OnUserEarnedReward;
        Rewarded.OnAdClosed += Rewarded_OnAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        Rewarded.LoadAd(request);

    }

    private void Rewarded_OnAdClosed(object sender, System.EventArgs e)
    {

        if(!isRewardEarned)
        {
            SceneManager.LoadScene("Menu");
        }
        RequestRewardedAd();
        isRewardEarned = false;
    }

    private void Rewarded_OnUserEarnedReward(object sender, Reward e)
    {
        SceneManager.LoadScene("Main");
        isRewardEarned = true;
    }
    #endregion
    #endif
}