using UnityEngine;

namespace RC15_HAX;
public static class Global {
    static Camera camera = Camera.main;

    public delegate void Action();
    public delegate void Action<in T>(T obj);

    public delegate TResult Func<out TResult>();
    public delegate TResult Func<in T, out TResult>(T arg);

    public static Camera Camera {
        get {
            if (!Global.camera) Global.camera = Camera.main;
            return Global.camera;
        }
    }
}