using System.Collections;
using System.Collections.Generic;
using Valpub;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ValpubSDKDemo : MonoBehaviour
{
    public Button btnReqRewardAd;
    public Button btnShowRewardAd;
    void Start()
    {
        btnReqRewardAd?.onClick.AddListener(RequestRewardAd);
        btnShowRewardAd?.onClick.AddListener(ShowRewardAd);

        if (btnShowRewardAd != null)
        {
            btnShowRewardAd.interactable = false;
        }

        ValpubSDK.OnRewardVideoAdDidLoadedEvent += OnRewardVideoAdDidLoadedEvent;
        ValpubSDK.OnRewardVideoAdVideoDidLoadedEvent += OnRewardVideoAdVideoDidLoadedEvent;
        ValpubSDK.OnRewardVideoAdDidAppearEvent += OnRewardVideoAdDidAppearEvent;
        ValpubSDK.OnRewardVideoAdDidPlayFinishEvent += OnRewardVideoAdDidPlayFinishEvent;
        ValpubSDK.OnRewardVideoAdDidClickedEvent += OnRewardVideoAdDidClickedEvent;
        ValpubSDK.OnRewardVideoAdDidCloseEvent += OnRewardVideoAdDidCloseEvent;
        ValpubSDK.OnRewardVideoAdLoadFailWithErrorEvent += OnRewardVideoAdLoadFailWithErrorEvent;
    }



    private void OnRewardVideoAdDidLoadedEvent()
    {

    }

    private void OnRewardVideoAdVideoDidLoadedEvent()
    {
        if (btnShowRewardAd != null)
        {
            btnShowRewardAd.interactable = ValpubSDK.Instance.IsAdValid();
        }
    }

    private void OnRewardVideoAdDidAppearEvent()
    {

    }

    private void OnRewardVideoAdDidPlayFinishEvent()
    {

    }

    private void OnRewardVideoAdDidClickedEvent()
    {

    }

    private void OnRewardVideoAdDidCloseEvent()
    {

    }

    private void OnRewardVideoAdLoadFailWithErrorEvent(int errCode)
    {
        Debug.Log("[ValpubSDKDemo] OnRewardVideoAdLoadFailWithErrorEvent errCode = " + errCode);
    }

    public void RequestRewardAd()
    {
        Debug.Log("RequestRewardAd");
        ValpubSDK.Instance.PreloadRewardAd();
    }

    public void ShowRewardAd()
    {
        Debug.Log("ShowRewardAd");
        if (ValpubSDK.Instance.IsAdValid())
        {
            ValpubSDK.Instance.ShowRewardAd();
        }
    }

    public void SetDebugMode(bool debugEnable)
    {
        Debug.Log(string.Format("SetDebugMode isDebug = {0}", debugEnable));
        ValpubSDK.Instance.SetDebugEnable(debugEnable);
    }

}
