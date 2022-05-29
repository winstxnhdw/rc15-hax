using UnityEngine;

namespace RC15_HAX;
public class Loader : MonoBehaviour {
    static GameObject mainGameObject = new GameObject();

    public static void Load() {
        DontDestroyOnLoad(Loader.mainGameObject);

        Loader.mainGameObject.AddComponent<InputListener>();
        Loader.mainGameObject.AddComponent<Console>();
        Loader.mainGameObject.AddComponent<Hax>();

    }

    public static void Unload() {
        Destroy(Loader.mainGameObject);
    }
}
