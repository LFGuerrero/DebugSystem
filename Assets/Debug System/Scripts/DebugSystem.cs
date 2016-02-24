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
using UnityEngine.UI;
using System.Collections;

public class DebugSystem : MonoBehaviour
{
    // Reference
    public static DebugSystem instance;

    // Timer used to calculate app FPS
    float deltaTime = 0.0f;

    // Main debugSystem canvas
    public Canvas debugCanvas;

    // Is the UI active
    bool helpUI = false;

    // Start state of cursor
    public bool ShowCursor = true;

    // UI Text box
    public Text screenSize;
    public Text screenRatio;
    public Text screenFPS;
    public Text appScene;
    public Text appName;
    public Text appMemory;
    public Text systemType;
    public Text systemOS;
    public Text systemMemory;
    public Text systemGPUmemory;
    public Text systemProcess;
    public Text systemAccGyro;

    // Hotkeys
    public KeyCode _cursor = KeyCode.C;
    public KeyCode _ui = KeyCode.H;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(this);
        }
    }

	// Use this for initialization
	void Start ()
    {
        debugCanvas.enabled = helpUI;
        Cursor.visible = ShowCursor;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (helpUI)
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            UpdateHelpUI();
        }

	    if(Input.GetKeyDown(_ui))
        {
            helpUI = !helpUI;
            debugCanvas.enabled = helpUI;
        }

        if (Input.GetKeyDown(_cursor)) Cursor.visible = !Cursor.visible;
	}

    /// <summary>
    /// Update all the Help UI Data
    /// </summary>
    public void UpdateHelpUI()
    {
        screenSize.text = "Screen Resolution: " + Screen.width + "x" + Screen.height;
        screenRatio.text = "Screen Aspect Ratio: " + Camera.main.aspect;
        screenFPS.text = "Screen FPS: " + GetFPS();
        appScene.text = "App Scene: " + Application.loadedLevelName;
        appName.text = "App Name: " + Application.productName + " - v" + Application.version;
        appMemory.text = "App Allocated Memory: " + ((Profiler.GetTotalAllocatedMemory() / 1000) / 1000) + " mb"; // convert bytes to megabytes

        systemType.text = "System type: " + SystemInfo.deviceType;
        systemOS.text = "System OS: " + SystemInfo.operatingSystem;
        systemMemory.text = "System Memory: " + SystemInfo.systemMemorySize + " mb";
        systemGPUmemory.text = "System GPU Name: " + SystemInfo.graphicsDeviceName + " | " + SystemInfo.graphicsMemorySize + " mb";
        systemProcess.text = "System Processor: " + SystemInfo.processorType;
        systemAccGyro.text = "Accelerometer: " + SystemInfo.supportsAccelerometer + " | Gyroscope: " + SystemInfo.supportsGyroscope;
    }

    /// <summary>
    /// Calculate the app FPS (Frame Per Seconds)
    /// </summary>
    /// <returns>Returns the app frame rate</returns>
    public string GetFPS()
    {
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        return text;
    }
}