#if UNITY_IOS && !UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Valpub
{
    public class ValpubIOS : ValpubBase
    {
        [DllImport("__Internal")]
        private static extern void CFSetDebugEnable(bool debugEnable);

        [DllImport("__Internal")]
        private static extern bool CFAdIsValid();

        [DllImport("__Internal")]
        private static extern void CFPreloadRewardAd();

        [DllImport("__Internal")]
        private static extern void CFShowRewardAd();

        public override void SetDebugEnable(bool debugEnable)
        {
            CFSetDebugEnable(debugEnable);
        }

        public override bool IsAdValid()
        {
            return CFAdIsValid();
        }

        public override void PreloadRewardAd()
        {
            CFPreloadRewardAd();
        }

        public override void ShowRewardAd()
        {
            CFShowRewardAd();
        }
    }
}
#endif