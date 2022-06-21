# Turntable

Turntable is a simple Unity Editor project for outputting videos and image sequences of assets rendered in real-time. It leverages the [Unity Recorder](https://docs.unity3d.com/Packages/com.unity.recorder@3.0/manual/index.html) to configure and output a wide range of file formats and resolutions.

![IMG](https://imgur.com/7noCVEs.jpg)

## Setup for rendering
The project works by rotating an object in a full circle, once the object has fully rotated the editor exits playmode. It uses [ExecuteInEditMode](https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html) attribute to update the camera position before rendering.

### Scene Setup
1. Import objects into Unity and open the CaptureScene
2. Drag object under the ObjectRoot game object and zero it out (position (0,0,0), rotation (0,0,0)) then adjust the height (y position) of the object to be roughly centered at ObjectRoot
3. Locate the Turntable game object Turntable Controller component. Adjust values for `Camera Height Y`, `Camera Distance From Object`, `Camera FOV` (field of view), `Camera Rotation` and `Object Rotation` values to determine the starting camera setup for the render.
4. Locate the CaptureController component on the Turntable game object. Adjust the speed modifcations based on how fast you want the object to rotate.
5.  Setup the Recorder window.

### Recorder setup
1. Open the Recorder Window (Window -> General -> Recorder -> Recorder Window)
2.  Add Recorder select either movie or image sequence.
3. Set Output Resolution to desired output quality.
4. Hit the **START RECORDING** button. The project will enter play mode and leave playmode after a full rotation of the object.

*Source:* Leave at the default setting of Game View  
*Include Audio*: Uncheck unless you have added audio to Unity and the scene  



## Project Setup
The project can be imported into an existing unity project or assets can be added to the Turntable project. 
### Adding turntable to an existing project
Download the latest [release](https://github.com/DanMillerDev/Turntable/releases) and import the .unitypackage into an existing Unity project. Open the CaptureScene and configure lighting settings and object.   

You may need to **import the recorder package** into your project by going to Package Manager -> Unity Registry -> Recorder -> Install.  

You can also drag the CaptureScene into an existing scene and transfer the game objects over using additive scenes.


### Adding assets to the turntable project
Import any objects you want to render into the project and follow the steps under Scene Setup.  

For built-in or HDRP you will need to adjust the Project Settings -> Graphics Settings.

### Things to keep in mind
The project is using the latest LTS (2021.3) but the scripts are compatible with any version of Unity.

The project is using Universal Render Pipeline (URP) but is compatible with any render pipeline.

## Known Issues
When rendering an image sequence there may be some dropped frames at the end of the render while the recorder is manually stopped. To compensate for this you can wait additional frames before stopping my increasing the value of  `Number Of Frames To Wait` on the CaptureController component.
