#if UNITY_ANDROID && !UNITY_EDITOR
using System.Buffers.Text;
using System.Runtime.Intrinsics.Arm.Arm64;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valpub
{
    public class ValpubAndriod : ValpubBase
    {
        AndroidJavaObject context;
        AndroidJavaObject bridge;
        public ValpubAndriod()
        {
            
        }

        public override void SetDebugEnable(bool debugEnable)
        {

        }

        public override bool IsAdValid()
        {
            return base.IsAdValid();
        }

        public override void PreloadRewardAd()
        {

        }

        public override void ShowRewardAd()
        {

        }
    }
}

#endif