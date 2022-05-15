using UnityEngine;

namespace RC15_HAX;
public class Loader : MonoBehaviour {
    static GameObject? mainGameObject;

    public static void Load() {
        Loader.mainGameObject = new GameObject();
        Loader.mainGameObject.AddComponent<Hax>();
        DontDestroyOnLoad(Loader.mainGameObject);
    }

    public static void Unload() {
        Destroy(Loader.mainGameObject);
    }
}
