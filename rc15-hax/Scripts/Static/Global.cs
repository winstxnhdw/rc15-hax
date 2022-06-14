using UnityEngine;

namespace RC15_HAX;
public static class Global {
    static Camera camera = Camera.main;

    public delegate void Action();
    public delegate void Action<in T>(T obj);

    public delegate TResult Func<out TResult>();
    public delegate TResult Func<in T, out TResult>(T arg);

    public static bool IsNullOrWhiteSpace(string value) {
        if (value == null) return true;
        return value.Contains(" ") || value.Length == 0 ? true : false;
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
}