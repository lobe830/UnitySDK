//
//  ValpubRewardedVideoAdDelegate.h
//  ValpubAds
//
//  Created by 骆超 on 2020/3/9.
//  Copyright © 2020 ll. All rights reserved.
//

#import <Foundation/Foundation.h>
@class ValpubRewardVideoAd;

NS_ASSUME_NONNULL_BEGIN

@protocol ValpubRewardedVideoAdDelegate <NSObject>

@optional

/**
 视频广告数据拉取成功

 @param rewardedVideoAd ValpubRewardVideoAd 实例
 */
- (void)valpub_rewardVideoAdDidLoad:(ValpubRewardVideoAd *)rewardedVideoAd;

/**
 视频下载成功，已经下载过的视频会直接回调 ⚠️请在视频下载完成后再调用展示⚠️

 @param rewardedVideoAd ValpubRewardVideoAd 实例
 */
- (void)valpub_rewardVideoAdVideoDidLoad:(ValpubRewardVideoAd *)rewardedVideoAd;

/**
 视频广告即将展示

 @param rewardedVideoAd ValpubRewardVideoAd 实例
 */
- (void)valpub_rewardVideoAdWillAppear:(ValpubRewardVideoAd *)rewardedVideoAd;

/**
 视频广告曝光

 @param rewardedVideoAd ValpubRewardVideoAd 实例
 */
- (void)valpub_rewardVideoAdDidAppear:(ValpubRewardVideoAd *)rewardedVideoAd;

/**
 视频广告关闭回调

 @param rewardedVideoAd ValpubRewardVideoAd 实例
 */
- (void)valpub_rewardVideoAdDidClose:(ValpubRewardVideoAd *)rewardedVideoAd;

/**
 视频广告被点击回调

 @param rewardedVideoAd ValpubRewardVideoAd 实例
 */
- (void)valpub_rewardVideoAdDidClicked:(ValpubRewardVideoAd *)rewardedVideoAd;

/**
 视频广告错误信息回调

 @param rewardedVideoAd ValpubRewardVideoAd 实例
 @param error 具体错误信息
 */
- (void)valpub_rewardVideoAd:(ValpubRewardVideoAd *)rewardedVideoAd didFailWithError:(NSError *)error;

/**
 视频广告达到激励目标回调

 @param rewardedVideoAd ValpubRewardVideoAd 实例
 */
- (void)valpub_rewardVideoAdDidRewardEffective:(ValpubRewardVideoAd *)rewardedVideoAd;

/**
 视频广告播放完成

 @param rewardedVideoAd ValpubRewardVideoAd 实例
 */
- (void)valpub_rewardVideoAdDidPlayFinish:(ValpubRewardVideoAd *)rewardedVideoAd;

@end

NS_ASSUME_NONNULL_END
