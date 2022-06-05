using UnityEngine;

namespace RC15_HAX;
public class Loader : MonoBehaviour {
    static GameObject HaxGameObject { get; } = new GameObject();

    public static void Load() {
        DontDestroyOnLoad(Loader.HaxGameObject);

        Loader.HaxGameObject.AddComponent<CursorController>();
        Loader.HaxGameObject.AddComponent<InputListener>();
        Loader.HaxGameObject.AddComponent<Console>();
        Loader.HaxGameObject.AddComponent<Hax>();
        Loader.HaxGameObject.AddComponent<HaxGUI>();
        Loader.HaxGameObject.AddComponent<HaxObjects>();
    }

    public static void Unload() {
        Destroy(Loader.HaxGameObject);
    }
}
