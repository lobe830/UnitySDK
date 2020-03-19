using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Valpub
{
    public class ValpubBase
    {
        public virtual void SetDebugEnable(bool debugEnable)
        {

        }

        public virtual bool IsAdValid()
        {
            return false;
        }

        public virtual void PreloadRewardAd()
        {

        }

        public virtual void ShowRewardAd()
        {

        }

    }
}