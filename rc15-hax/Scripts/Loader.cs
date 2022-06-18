using UnityEngine;

namespace RC15_HAX;
public class Loader : MonoBehaviour {
    static GameObject HaxGameObject { get; } = new GameObject();
    public static GameObject HaxModules { get; } = new GameObject();

    static void AddHaxModules<T>() where T : Component => Loader.HaxModules.AddComponent<T>();

    public static void Load() {
        DontDestroyOnLoad(Loader.HaxGameObject);

        Loader.HaxGameObject.AddComponent<CursorController>();
        Loader.HaxGameObject.AddComponent<DebugController>();
        Loader.HaxGameObject.AddComponent<InputListener>();
        Loader.HaxGameObject.AddComponent<Console>();
        Loader.HaxGameObject.AddComponent<ConsoleInputField>();
        Loader.HaxGameObject.AddComponent<Hax>();
        Loader.HaxGameObject.AddComponent<HaxObjects>();

        Loader.LoadHaxModules();
    }

    static void LoadHaxModules() {
        DontDestroyOnLoad(Loader.HaxModules);

        AddHaxModules<Aimbot>();
        AddHaxModules<PlayerESP>();
        AddHaxModules<NoClip>();
        AddHaxModules<Freecam>();
        AddHaxModules<Voodoo>();
        AddHaxModules<Player>();

        AddHaxModules<FakeCrosshair>();
        AddHaxModules<NoFog>();
        AddHaxModules<NoCameraShake>();
        AddHaxModules<UndergroundSpawn>();

        AddHaxModules<WeaponMod>();
        AddHaxModules<PlasmaMod>();
        AddHaxModules<RailMod>();
        AddHaxModules<SMGMod>();
        AddHaxModules<TeslaMod>();

        // AddHaxModules<AerofoilMod>();
        // AddHaxModules<JetMod>();
        // AddHaxModules<WheelMod>();
        // AddHaxModules<RotorMod>();
        // AddHaxModules<LegMod>();
    }

    public static void Unload() {
        Destroy(Loader.HaxModules);
        Destroy(Loader.HaxGameObject);
    }
}
