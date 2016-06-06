//
//  ViewController.m
//  NativeProjectLib
//
//  Created by Sam Izzo on 30/05/14.
//  Copyright (c) 2014 Fancy Pants Games. All rights reserved.
//

#import "ViewController.h"
#import "Playbasis.h"

@interface ViewController ()

@end

@implementation ViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view.
    
    [[Playbasis sharedPB] authWithApiKeyAsync:@"1012718250" apiSecret:@"a52097fc5a17cb0d8631d20eacd2d9c2" bundleId:@"io.wasin." andBlock:^(PBAuth_Response *auth, NSURL *url, NSError *error) {
        if (error != nil)
        {
            NSLog(@"auth error");
        }
        else
        {
            NSLog(@"auth success: %@", auth);
        }
    }];
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/
- (IBAction)onSwitchToUnityPressed:(id)sender
{
    NSLog(@"Switching to Unity..");
    [[NSNotificationCenter defaultCenter] postNotificationName:@"SwitchToUnityRequested" object:nil];
}

@end
