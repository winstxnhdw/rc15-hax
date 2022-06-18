using System.Reflection;
using UnityEngine;

namespace RC15_HAX;
public static class Global {
    public const float twoPi = Mathf.PI * 2.0f;
    static Camera camera = Camera.main;

    public static bool IsNullOrWhiteSpace(string value) {
        if (value == null) return true;

        foreach (char c in value) {
            if (!char.IsWhiteSpace(c)) return false;
        }

        return true;
    }

    public static void SetInternalFieldValue(object type, string fieldName, object value) {
        type.GetType()
            .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(type, value);
    }

    public static void PrintAllAncestors(Transform transform) {
        Console.Print($"Layer {transform.gameObject.layer}: {transform.name}");

        if (transform.parent != null) {
            Global.PrintAllAncestors(transform.parent);
        }
    }

    public static void PrintAllDescendents(Transform transform) {
        Console.Print($"Layer {transform.gameObject.layer}: {transform.name}");

        foreach (Transform child in transform) {
            Global.PrintAllDescendents(child);
        }
    }

    public static Vector3 GetNoClipInputVector() {
        Transform cameraT = Global.Camera.transform;
        Vector3 directionVector = Vector3.zero;

        // Forward-back
        if (Input.GetKey(KeyCode.W)) {
            directionVector += cameraT.forward;
        }

        else if (Input.GetKey(KeyCode.S)) {
            directionVector -= cameraT.forward;
        }

        // Right-left
        if (Input.GetKey(KeyCode.D)) {
            directionVector += cameraT.right;
        }

        else if (Input.GetKey(KeyCode.A)) {
            directionVector -= cameraT.right;
        }

        // Up-down
        if (Input.GetKey(KeyCode.Space)) {
            directionVector += cameraT.up;
        }

        else if (Input.GetKey(KeyCode.LeftShift)) {
            directionVector -= cameraT.up;
        }

        return directionVector * NoClipSettings.NoClipSpeedMultiplier;
    }

    public static Camera Camera {
        get {
            if (!Global.camera) Global.camera = Camera.main;
            return Global.camera;
        }
    }

    public static Transform SimulationCameraT => Global.camera.transform.parent;
}