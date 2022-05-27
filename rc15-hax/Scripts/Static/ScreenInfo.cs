using UnityEngine;

namespace RC15_HAX;
public static class ScreenInfo {
    public static Vector3 GetScreenCentre3D(float z = 0.0f) {
        Vector3 screenCentre = new Vector3(Screen.width, Screen.height, z) * 0.5f;
        return Main.Camera!.ScreenToWorldPoint(screenCentre);
    }

    public static Vector2 GetScreenCentre2D() {
        return GetScreenCentre3D();
    }
}