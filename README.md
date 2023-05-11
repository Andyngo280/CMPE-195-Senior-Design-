# CMPE-195-Senior-Design-Project
An AR indoor navigation app designed for SJSU Engineering building that showcases a path on their phone screen that guides users to reach their destination. 

# Install Instruction 
The tests were performed on our iOS mobile devices during the developing stage, but sometimes it can be frustrating to install the app onto iOS devices. However, Android devices would be more straight forward. Thus, I would recommend you to install it onto Android devices.
In order to install the software on mobile devices, you need to follow the following steps:

# Preparation:
## Install Unity Hub, Xcode, and the project zip file
Link for Unity Hub: 
    for mac: https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.dmg
    for windows: https://public-cdn.cloud.unity3d.com/hub/prod/UnityHubSetup.exe
Link for Xcode 14: https://developer.apple.com/xcode/

# For iOS System
You need a mac OS device with Xcode installed in order to install it onto iOS devices.

## 1. Launch Unity
Launch Unity

## 2. Change build setting
Navigate to File >> Build Settings...
On the leftside, platform menu, choose iOS, and on the bottom right click "Switch Platform" to switch the build mode to iOS

## 3. Build and Run
Click "Build And Run", and choose your build folder.

## 4. iOS device set up
Connect your iPhone/iPad to your mac device through USB cord. 
In settings, navigate to "Privacy & Security", at the bottom of the page, turn on "Developer Mode" 

## 5. Xcode settings
After the project is built, an Xcode project file is generated and should be opened automatically.
On the top menu, choose the build target to be the device you connected with so it will install the app to your connected device.
If there are any warnings or errors, you probably need to fix the signing settings under the team settings. (If you encounter any problems, please follow the instruction in the warning messages and look it up online)

## 6. Install
The app should be installed automatically

# For Android System
You can use both Windows system or Mac OS system, we are not sure about Linux systems.

## 1. Launch Unity
Launch Unity

## 2. Change build settings
Navigate to File >> Build Settings...
On the leftside, platform menu, choose Android, and on the bottom right click "Switch Platform" to switch the build mode to Android

## 3. Android device set up
Connect your Android device to your Computer through USB cord and turn on Developer mode. 
Different devices may have different ways to turn on developer mode, look up online for a tutorial for your own device.

## 4. Build and Run
Click Build And Run, and choose the build folder.
Follow the potential instructions in the Unity Console.

