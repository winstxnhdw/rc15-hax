using UnityEngine;

namespace RC15_HAX;
public class Loader : MonoBehaviour {
    static GameObject mainGameObject = new GameObject();

    public static void Load() {
        DontDestroyOnLoad(Loader.mainGameObject);

        Loader.mainGameObject.AddComponent<Hax>();
        Loader.mainGameObject.AddComponent<HaxConsole>();
        Loader.mainGameObject.AddComponent<InputListener>();
    }

    public static void Unload() {
        Destroy(Loader.mainGameObject);
    }
}
