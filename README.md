# Turntable

Turntable is a simple Unity Editor project for outputting videos and image sequences of assets rendered in real-time. It leverages the [Unity Recorder](https://docs.unity3d.com/Packages/com.unity.recorder@3.0/manual/index.html) to configure and output a wide range of file formats and resolutions.

![IMG](https://imgur.com/7noCVEs.jpg)

## Setup for rendering
The project works by rotating an object in a full circle, once the object has fully rotated the editor exits playmode. It uses [ExecuteInEditMode](https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html) attribute to update the camera position before rendering.

### Scene Setup


### Recorder setup

## Project Setup
The project can be imported into an existing unity project or assets can be added to the Turntable project. 
### Adding turntable to an existing project



### Adding assets to the turntable project


### Things to keep in mind
The project is using the latest LTS (2021.3) but the scripts are compatible with any version of Unity.

The project is using Universal Render Pipeline (URP) but is compatible with any render pipeline.
