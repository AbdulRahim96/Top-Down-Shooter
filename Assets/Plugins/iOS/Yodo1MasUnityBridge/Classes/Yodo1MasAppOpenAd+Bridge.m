//
//  Yodo1MasAppOpenAd+Bridge.m
//  UnityFramework
//
//  Created by 周玉震 on 2021/11/28.
//

#import "Yodo1MasAppOpenAd+Bridge.h"
#import <objc/runtime.h>

@implementation Yodo1MasBridgeAppOpenAdConfig

+ (Yodo1MasBridgeAppOpenAdConfig *)parse:(id)json {
    Yodo1MasBridgeAppOpenAdConfig *config = [[Yodo1MasBridgeAppOpenAdConfig alloc] init];
    
    if (json[@"adPlacement"]) {
        config.adPlacement = json[@"adPlacement"];
    } else {
        config.adPlacement = @"";
    }
    
    return config;
}

@end

@implementation Yodo1MasAppOpenAd(Bridge)

- (Yodo1MasBridgeAppOpenAdConfig *)yodo1_config {
    return objc_getAssociatedObject(self, _cmd);
}

- (void)setYodo1_config:(Yodo1MasBridgeAppOpenAdConfig *)yodo1_config {
    objc_setAssociatedObject(self, @selector(yodo1_config), yodo1_config, OBJC_ASSOCIATION_RETAIN_NONATOMIC);
}

@end
