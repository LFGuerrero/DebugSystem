/*
The MIT License (MIT)

Copyright (c) 2016 LFGuerrero

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using UnityEngine;
using UnityEditor.UI;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(DebugSystem))]
public class UIeditor : Editor
{
    GUISkin curSkin;

    bool showContent, showHotKey;

    void OnEnable()
    {
        if (!curSkin)
            curSkin = (GUISkin)Resources.Load("EditorSkin");
    }

    public override void OnInspectorGUI()
    {
        DebugSystem myTarget = (DebugSystem)target;

        EditorGUILayout.HelpBox("Hotkeys:\n " + myTarget._cursor + " - Enable/Disable mouse cursor \n " + myTarget._ui + " - Enable/Disable debug UI", MessageType.None);

        EditorGUILayout.Space();

        myTarget.ShowCursor = EditorGUILayout.Toggle("Display cursor:", myTarget.ShowCursor);
        
        showContent = EditorGUILayout.Foldout(showContent, "Show canvas objects:");
        if (showContent)
        {
            myTarget.debugCanvas = EditorGUILayout.ObjectField("Main canvas: ", myTarget.debugCanvas, typeof(UnityEngine.Object), true) as Canvas;
            myTarget.screenSize = EditorGUILayout.ObjectField("Screen Size: ", myTarget.screenSize, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.screenRatio = EditorGUILayout.ObjectField("Screen Ratio: ", myTarget.screenRatio, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.screenFPS = EditorGUILayout.ObjectField("Screen FPS", myTarget.screenFPS, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.appScene = EditorGUILayout.ObjectField("App Scene: ", myTarget.appScene, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.appName = EditorGUILayout.ObjectField("App Name: ", myTarget.appName, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.appMemory = EditorGUILayout.ObjectField("App Memory", myTarget.appMemory, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;

            myTarget.systemType = EditorGUILayout.ObjectField("System Type: ", myTarget.systemType, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.systemOS = EditorGUILayout.ObjectField("System OS: ", myTarget.systemOS, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.systemMemory = EditorGUILayout.ObjectField("System Memory: ", myTarget.systemMemory, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.systemGPUmemory = EditorGUILayout.ObjectField("System GPU:", myTarget.systemGPUmemory, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.systemProcess = EditorGUILayout.ObjectField("System Process: ", myTarget.systemProcess, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
            myTarget.systemAccGyro = EditorGUILayout.ObjectField("System Acc/Gyro: ", myTarget.systemAccGyro, typeof(UnityEngine.Object), true) as UnityEngine.UI.Text;
        }
    }
}