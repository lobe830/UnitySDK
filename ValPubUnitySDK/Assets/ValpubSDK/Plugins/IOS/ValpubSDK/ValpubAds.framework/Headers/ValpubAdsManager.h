//
//  ValpubAdsManager.h
//  ValpubAds
//
//  Created by 骆超 on 2020/3/18.
//  Copyright © 2020 ll. All rights reserved.
//

#import <Foundation/Foundation.h>

NS_ASSUME_NONNULL_BEGIN

@interface ValpubAdsManager : NSObject

@property (assign, nonatomic) BOOL debugEnable;

+ (instancetype)sharedInstance;

@end

NS_ASSUME_NONNULL_END
