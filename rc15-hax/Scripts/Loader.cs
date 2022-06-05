using UnityEngine;

namespace RC15_HAX;
public class Loader : MonoBehaviour {
    static GameObject HaxGameObject { get; } = new GameObject();
    public static GameObject HaxModules { get; } = new GameObject();

    public static void Load() {
        DontDestroyOnLoad(Loader.HaxGameObject);

        Loader.HaxGameObject.AddComponent<CursorController>();
        Loader.HaxGameObject.AddComponent<InputListener>();
        Loader.HaxGameObject.AddComponent<Console>();
        Loader.HaxGameObject.AddComponent<Hax>();
        Loader.HaxGameObject.AddComponent<HaxObjects>();

        Loader.LoadHaxModules();
    }

    static void LoadHaxModules() {
        Loader.HaxModules.AddComponent<NoCameraShake>();
        Loader.HaxModules.AddComponent<PlayerESP>();
        Loader.HaxModules.AddComponent<NoClip>();
        Loader.HaxModules.AddComponent<DimensionalRift>();
        Loader.HaxModules.AddComponent<Player>();
    }

    public static void Unload() {
        Destroy(Loader.HaxModules);
        Destroy(Loader.HaxGameObject);
    }
}
