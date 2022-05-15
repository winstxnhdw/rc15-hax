using UnityEngine;

namespace RC15_HAX;
public static class Main {
    static Camera camera;

    public static Camera Camera {
        get {
            return Main.camera ? Main.camera : Camera.main;
        }
    }
}