//
//  ValpubAdsUnityBridge.m
//  ValpubSample
//
//  Created by 骆超 on 2020/3/11.
//  Copyright © 2020 ll. All rights reserved.
//

#import "ValpubAdsUnityBridge.h"
#import <ValpubAds/ValpubRewardVideoAd.h>
#import <ValpubAds/ValpubAdsManager.h>

#define ValpubMakeStringCopy( _x_ ) ( _x_ != NULL && [_x_ isKindOfClass:[NSString class]] ) ? strdup( [_x_ UTF8String] ) : NULL
#define ValpubGetStringParam( _x_ ) ( _x_ != NULL ) ? [NSString stringWithUTF8String:_x_] : [NSString stringWithUTF8String:""]


@interface ValpubAdsUnityBridge ()<ValpubRewardedVideoAdDelegate>

@property (nonatomic, strong) ValpubRewardVideoAd *rewardAd;

@end

@implementation ValpubAdsUnityBridge

char *const ValpubUNITY_EVENT = "ValpubSDKEventPrefab";
char *const ValpubUNITY_RECEIVER= "ValpubUnityReceiver";


#pragma mark - init

+ (ValpubAdsUnityBridge *)sharedInstance
{
    static dispatch_once_t once;
    static ValpubAdsUnityBridge *sharedInstance = nil;
    dispatch_once(&once, ^{
        sharedInstance = [[super allocWithZone:NULL] init];
    });

    return sharedInstance;
}

+ (id)allocWithZone:(struct _NSZone *)zone
{
    return [ValpubAdsUnityBridge sharedInstance] ;
}

- (id)copyWithZone:(NSZone *)zone
{
    return [ValpubAdsUnityBridge sharedInstance];
}

- (id)mutableCopyWithZone:(NSZone *)zone
{
    return [ValpubAdsUnityBridge sharedInstance];
}


- (ValpubRewardVideoAd *)rewardAd
{
    if (!_rewardAd) {
        _rewardAd = [[ValpubRewardVideoAd alloc] init];
        _rewardAd.delegate = self;
    }
    return _rewardAd;
}

#pragma mark - ValpubRewardedVideoAdDelegate

///广告数据加载成功回调
- (void)valpub_rewardVideoAdDidLoad:(ValpubRewardVideoAd *)rewardedVideoAd
{
    NSDictionary *dic = @{
                          @"func":@"valpub_rewardVideoAdDidLoad"
                          };
    NSString *paramStr = [self jsonFromDic:dic];

    UnitySendMessage(ValpubUNITY_EVENT, ValpubUNITY_RECEIVER, ValpubMakeStringCopy(paramStr));
}

///视频数据下载成功回调，已经下载过的视频会直接回调
- (void)valpub_rewardVideoAdVideoDidLoad:(ValpubRewardVideoAd *)rewardedVideoAd
{
    NSDictionary *dic = @{
                          @"func":@"valpub_rewardVideoAdVideoDidLoad"
                          };
    NSString *paramStr = [self jsonFromDic:dic];

    UnitySendMessage(ValpubUNITY_EVENT, ValpubUNITY_RECEIVER, ValpubMakeStringCopy(paramStr));
}

///视频播放页即将展示回调
- (void)valpub_rewardVideoAdWillAppear:(ValpubRewardVideoAd *)rewardedVideoAd
{
    NSDictionary *dic = @{
                          @"func":@"valpub_rewardVideoAdWillAppear"
                          };
    NSString *paramStr = [self jsonFromDic:dic];

    UnitySendMessage(ValpubUNITY_EVENT, ValpubUNITY_RECEIVER, ValpubMakeStringCopy(paramStr));
}

///视频广告曝光回调
- (void)valpub_rewardVideoAdDidAppear:(ValpubRewardVideoAd *)rewardedVideoAd
{
    NSDictionary *dic = @{
                          @"func":@"valpub_rewardVideoAdDidAppear"
                          };
    NSString *paramStr = [self jsonFromDic:dic];

    UnitySendMessage(ValpubUNITY_EVENT, ValpubUNITY_RECEIVER, ValpubMakeStringCopy(paramStr));
}

///视频播放页关闭回调
- (void)valpub_rewardVideoAdDidClose:(ValpubRewardVideoAd *)rewardedVideoAd
{
    NSDictionary *dic = @{
                          @"func":@"valpub_rewardVideoAdDidClose"
                          };
    NSString *paramStr = [self jsonFromDic:dic];

    UnitySendMessage(ValpubUNITY_EVENT, ValpubUNITY_RECEIVER, ValpubMakeStringCopy(paramStr));
}

///视频广告信息点击回调
- (void)valpub_rewardVideoAdDidClicked:(ValpubRewardVideoAd *)rewardedVideoAd
{
    NSDictionary *dic = @{
                          @"func":@"valpub_rewardVideoAdDidClicked"
                          };
    NSString *paramStr = [self jsonFromDic:dic];

    UnitySendMessage(ValpubUNITY_EVENT, ValpubUNITY_RECEIVER, ValpubMakeStringCopy(paramStr));
}

///视频广告各种错误信息回调
- (void)valpub_rewardVideoAd:(ValpubRewardVideoAd *)rewardedVideoAd didFailWithError:(NSError *)error
{
    NSDictionary *dic = @{
                          @"func":@"valpub_rewardVideoAdLoadFailWithError",
                          @"errCode":@(error.code),
                          };

    NSString *paramStr = [self jsonFromDic:dic];

    UnitySendMessage(ValpubUNITY_EVENT, ValpubUNITY_RECEIVER, ValpubMakeStringCopy(paramStr));
}

///视频广告播放达到激励条件回调
- (void)valpub_rewardVideoAdDidRewardEffective:(ValpubRewardVideoAd *)rewardedVideoAd
{
    NSDictionary *dic = @{
                          @"func":@"valpub_rewardVideoAdDidRewardEffective"
                          };
    NSString *paramStr = [self jsonFromDic:dic];

    UnitySendMessage(ValpubUNITY_EVENT, ValpubUNITY_RECEIVER, ValpubMakeStringCopy(paramStr));
}

///视频广告视频播放完成
- (void)valpub_rewardVideoAdDidPlayFinish:(ValpubRewardVideoAd *)rewardedVideoAd
{
    NSDictionary *dic = @{
                          @"func":@"valpub_rewardVideoAdDidPlayFinish"
                          };
    NSString *paramStr = [self jsonFromDic:dic];

    UnitySendMessage(ValpubUNITY_EVENT, ValpubUNITY_RECEIVER, ValpubMakeStringCopy(paramStr));
}

#pragma mark - util

- (NSString *)jsonFromDic:(NSDictionary *)dic {
    NSError *error;
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:dic options:0 error:&error];

    if (!jsonData) {
        NSLog(@"Got an error: %@", error);
        return @"";
    } else {
        NSString *jsonString = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
        return jsonString;
    }
}

#pragma mark - reward

- (void)setDebugEnable:(BOOL)debugEnable {
    [[ValpubAdsManager sharedInstance] setDebugEnable:debugEnable];
}

- (void)loadReward
{
    [self.rewardAd loadAd];
}

- (void)presentRewardAd
{
    if (!self.rewardAd.isAdValid) {
        NSLog(@"无可用广告，请先拉取广告");
        return;
    }

    [self.rewardAd showAdFromRootViewController:[UIApplication sharedApplication].keyWindow.rootViewController];
}

- (BOOL)isAdValid
{
    return self.rewardAd.isAdValid;
}


#ifdef __cplusplus
extern "C" {
#endif
    
    void CFSetDebugEnable(bool debugEnable){
        [[ValpubAdsUnityBridge sharedInstance] setDebugEnable:debugEnable];
    }
    
    bool CFAdIsValid(){
        return [[ValpubAdsUnityBridge sharedInstance] isAdValid];
    }
    
    void CFPreloadRewardAd(){
        [[ValpubAdsUnityBridge sharedInstance] loadReward];
    }

    void CFShowRewardAd(){
        [[ValpubAdsUnityBridge sharedInstance] presentRewardAd];
    }

#ifdef __cplusplus
}
#endif

@end
