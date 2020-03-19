//
//  ValpubAdsUnityBridge.h
//  ValpubSample
//
//  Created by 骆超 on 2020/3/11.
//  Copyright © 2020 ll. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface ValpubAdsUnityBridge : NSObject

@end

#if defined (__cplusplus)
extern "C"
{
#endif
    ///设置debug，debug时使用,默认为关闭
    void CFSetDebugEnable(bool debugEnable);

    ///是否有可用广告，在调用展示之前需要查询是否有可用广告
    bool CFAdIsValid();

    ///拉取激励视频广告
    void CFPreloadRewardAd();
    
    /// 展示激励视频广告
     void CFShowRewardAd();
    
    
#if defined (__cplusplus)
}
#endif

NS_ASSUME_NONNULL_END
