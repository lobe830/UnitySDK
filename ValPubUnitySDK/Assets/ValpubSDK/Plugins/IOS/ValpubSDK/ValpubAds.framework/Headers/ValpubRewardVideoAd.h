//
//  ValpubRewardVideoAd.h
//  ValpubAds
//
//  Created by 骆超 on 2020/3/9.
//  Copyright © 2020 ll. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

#import "ValpubRewardedVideoAdDelegate.h"

NS_ASSUME_NONNULL_BEGIN

@interface ValpubRewardVideoAd : NSObject


@property (weak, nonatomic) id<ValpubRewardedVideoAdDelegate> delegate;

@property (nonatomic, getter=isAdValid, readonly) BOOL adValid;
@property (nonatomic) BOOL videoMuted;


/// 加载广告方法
- (void)loadAd;

/// 展示广告方法
/// @param rootViewController 用于 present 激励视频 VC
- (void)showAdFromRootViewController:(UIViewController *)rootViewController;



@end

NS_ASSUME_NONNULL_END
