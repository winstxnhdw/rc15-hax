using UnityEngine;

namespace RC15_HAX;
public static class Global {
    static Camera camera = Camera.main;

    public static Camera Camera {
        get {
            if (!Global.camera) Global.camera = Camera.main;
            return Global.camera;
        }
    }
}