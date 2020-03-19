using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MJ = Valpub.ThirdParty.MiniJSON;

namespace Valpub
{
    public class ValpubSDK : MonoBehaviour
    {

        /// <summary>
        /// 广告数据加载成功回调
        /// </summary>
        public static event Action OnRewardVideoAdDidLoadedEvent;
        /// <summary>
        /// 视频数据下载成功回调，已经下载过的 视频会直接回调 (请在视频视频下载完成后再进行播放)
        /// </summary>
        public static event Action OnRewardVideoAdVideoDidLoadedEvent;
        /// <summary>
        /// 视频广告即将展示
        /// </summary>
        public static event Action OnRewardVideoAdWillAppearEvent;
        /// <summary>
        /// 视频广告曝光
        /// </summary>
        public static event Action OnRewardVideoAdDidAppearEvent;
        /// <summary>
        /// 视频广告关闭回调
        /// </summary>
        public static event Action OnRewardVideoAdDidCloseEvent;
        /// <summary>
        /// 视频广告被点击回调
        /// </summary>
        public static event Action OnRewardVideoAdDidClickedEvent;
        /// <summary>
        /// 视频广告达到激励目标回调
        /// </summary>
        public static event Action OnRewardVideoAdDidRewardEffectiveEvent;
        /// <summary>
        /// 视频广告播放完成
        /// </summary>
        public static event Action OnRewardVideoAdDidPlayFinishEvent;
        /// <summary>
        /// 视频广告错误信息回调，收到该回 调需解析errCode
        /// </summary>
        public static event Action<int> OnRewardVideoAdLoadFailWithErrorEvent;

        ValpubBase mSDKAdapter = null;
        public static ValpubSDK mInstance = null;

        public static ValpubSDK Instance
        {
            get
            {
                if (mInstance == null)
                {
                    Debug.LogError("Instance is NULL, you shoud add SDK Component to your gameobject In Scene");
                }
                return mInstance;
            }
        }

        ValpubBase SDKAdpater
        {
            get
            {
#if UNITY_EDITOR
                mSDKAdapter = new ValpubEditor();
#elif UNITY_IOS
            mSDKAdapter = new ValpubIOS();
#elif UNITY_ANDROID
            mSDKAdapter = new ValpubAndriod();
#else
            mSDKAdapter = new ValpubBase();
#endif
                return mSDKAdapter;
            }
        }

        private void Awake()
        {
            mInstance = this;
            if (transform.parent == null)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        /// <summary>
        /// 设置debug，debug时使用,默认为关闭
        /// </summary>
        /// <param name="debugEnable"></ param >
        public void SetDebugEnable(bool debugEnable)
        {
            SDKAdpater.SetDebugEnable(debugEnable);
        }

        /// <summary>
        /// 是否有可用广告，在调用展示之前需要查询是否有可用广告
        /// </summary>
        public bool IsAdValid()
        {
            return SDKAdpater.IsAdValid();
        }

        /// <summary>
        /// 拉取激励视频广告
        /// </summary>
        public void PreloadRewardAd()
        {
            SDKAdpater.PreloadRewardAd();
        }

        /// <summary>
        /// 展示激励视频广告
        /// </summary>
        public void ShowRewardAd()
        {
            SDKAdpater.ShowRewardAd();
        }

        public void ValpubUnityReceiver(string jsonParams)
        {
            var jsonData = MJ.Json.Deserialize(jsonParams) as Dictionary<string, object>; ;
            var FuncName = jsonData["func"].ToString();

            if (FuncName.Equals(ValpubSDKCallbackFunc.Func_RewardVideoAdLoadFailWithError))
            {
                var errCode = (int)jsonData["errCode"];
                Func_RewardVideoAdLoadFailWithError(errCode);
            }
            else if (FuncName.Equals(ValpubSDKCallbackFunc.Func_RewardVideoAdDidAppear))
            {
                Func_RewardVideoAdDidAppear();
            }
            else if (FuncName.Equals(ValpubSDKCallbackFunc.Func_RewardVideoAdDidClicked))
            {
                Func_RewardVideoAdDidClicked();
            }
            else if (FuncName.Equals(ValpubSDKCallbackFunc.Func_RewardVideoAdDidClose))
            {
                Func_RewardVideoAdDidClose();
            }
            else if (FuncName.Equals(ValpubSDKCallbackFunc.Func_RewardVideoAdDidLoaded))
            {
                Func_RewardVideoAdDidLoaded();
            }
            else if (FuncName.Equals(ValpubSDKCallbackFunc.Func_RewardVideoAdDidPlayFinish))
            {
                Func_RewardVideoAdDidPlayFinish();
            }
            else if (FuncName.Equals(ValpubSDKCallbackFunc.Func_RewardVideoAdDidRewardEffective))
            {
                Func_RewardVideoAdDidRewardEffective();
            }
            else if (FuncName.Equals(ValpubSDKCallbackFunc.Func_RewardVideoAdVideoDidLoaded))
            {
                Func_RewardVideoAdVideoDidLoaded();
            }
            else if (FuncName.Equals(ValpubSDKCallbackFunc.Func_RewardVideoAdWillAppear))
            {
                Func_RewardVideoAdWillAppear();
            }
        }

        public void Func_RewardVideoAdDidLoaded()
        {
            OnRewardVideoAdDidLoadedEvent?.Invoke();
        }

        public void Func_RewardVideoAdVideoDidLoaded()
        {
            OnRewardVideoAdVideoDidLoadedEvent?.Invoke();
        }

        public void Func_RewardVideoAdWillAppear()
        {
            OnRewardVideoAdWillAppearEvent?.Invoke();
        }

        public void Func_RewardVideoAdDidAppear()
        {
            OnRewardVideoAdDidAppearEvent?.Invoke();
        }

        public void Func_RewardVideoAdDidClose()
        {
            OnRewardVideoAdDidCloseEvent?.Invoke();
        }

        public void Func_RewardVideoAdDidClicked()
        {
            OnRewardVideoAdDidClickedEvent?.Invoke();
        }

        public void Func_RewardVideoAdDidRewardEffective()
        {
            OnRewardVideoAdDidRewardEffectiveEvent?.Invoke();
        }

        public void Func_RewardVideoAdDidPlayFinish()
        {
            OnRewardVideoAdDidPlayFinishEvent?.Invoke();
        }

        public void Func_RewardVideoAdLoadFailWithError(int errCode)
        {
            Debug.Log("[ValpubSDK] Func_RewardVideoAdLoadFailWithError errCode = " + errCode);
            OnRewardVideoAdLoadFailWithErrorEvent?.Invoke(errCode);
        }
    }

    public class ValpubSDKCallbackFunc
    {
        /// <summary>
        /// 广告数据加载成功回调
        /// </summary>
        public static string Func_RewardVideoAdDidLoaded = "valpub_rewardVideoAdDidLoad";
        /// <summary>
        /// 视频数据下载成功回调，已经下载过的 视频会直接回调 (请在视频视频下载完成后再进行播放)
        /// </summary>
        public static string Func_RewardVideoAdVideoDidLoaded = "valpub_rewardVideoAdVideoDidLoad";
        /// <summary>
        /// 视频广告即将展示
        /// </summary>
        public static string Func_RewardVideoAdWillAppear = "valpub_rewardVideoAdWillAppear";
        /// <summary>
        /// 视频广告曝光
        /// </summary>
        public static string Func_RewardVideoAdDidAppear = "valpub_rewardVideoAdDidAppear";
        /// <summary>
        /// 视频广告关闭回调
        /// </summary>
        public static string Func_RewardVideoAdDidClose = "valpub_rewardVideoAdDidClose";
        /// <summary>
        /// 视频广告被点击回调
        /// </summary>
        public static string Func_RewardVideoAdDidClicked = "valpub_rewardVideoAdDidClicked";
        /// <summary>
        /// 视频广告达到激励目标回调
        /// </summary>
        public static string Func_RewardVideoAdDidRewardEffective = "valpub_rewardVideoAdDidRewardEffective";
        /// <summary>
        /// 视频广告播放完成
        /// </summary>
        public static string Func_RewardVideoAdDidPlayFinish = "valpub_rewardVideoAdDidPlayFinish";
        /// <summary>
        /// 视频广告错误信息回调，收到该回 调需解析errCode
        /// </summary>
        public static string Func_RewardVideoAdLoadFailWithError = "valpub_rewardVideoAdLoadFailWithError";
    }
}