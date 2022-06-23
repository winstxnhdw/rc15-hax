using System;
using System.Reflection;
using UnityEngine;

namespace RC15_HAX;
public static class Global {
    public const float twoPi = Mathf.PI * 2.0f;
    static Camera camera = Camera.main;
    static Assembly RobocraftAssembly => Assembly.Load("Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");

    public static Type GetRobocraftType(string componentName) {
        Type component = Global.RobocraftAssembly.GetType(componentName);

        if (component == null) Console.Print($"Invalid RobocraftType: {componentName}");

        return component;
    }

    public static bool IsNullOrWhiteSpace(string value) {
        if (value == null) return true;

        foreach (char c in value) {
            if (!char.IsWhiteSpace(c)) return false;
        }

        return true;
    }

    public static Vector3 GetNoClipInputVector() {
        Transform cameraTransform = Global.Camera.transform;
        Vector3 directionVector = Vector3.zero;

        // Forward-back
        if (Input.GetKey(KeyCode.W)) {
            directionVector += cameraTransform.forward;
        }

        else if (Input.GetKey(KeyCode.S)) {
            directionVector -= cameraTransform.forward;
        }

        // Right-left
        if (Input.GetKey(KeyCode.D)) {
            directionVector += cameraTransform.right;
        }

        else if (Input.GetKey(KeyCode.A)) {
            directionVector -= cameraTransform.right;
        }

        // Up-down
        if (Input.GetKey(KeyCode.Space)) {
            directionVector += cameraTransform.up;
        }

        else if (Input.GetKey(KeyCode.LeftShift)) {
            directionVector -= cameraTransform.up;
        }

        return directionVector * NoClipSettings.NoClipSpeedMultiplier;
    }

    public static Camera Camera {
        get {
            if (!Global.camera) Global.camera = Camera.main;
            return Global.camera;
        }
    }

    public static Transform SimulationCameraTransform => Global.camera.transform.parent;
}