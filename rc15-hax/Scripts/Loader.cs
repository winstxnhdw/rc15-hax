using UnityEngine;

namespace RC15_HAX;
public class Loader : MonoBehaviour {
    static GameObject HaxGameObject { get; } = new GameObject();
    public static GameObject HaxModules { get; } = new GameObject();

    static void AddHaxModules<T>() where T : Component => Loader.HaxModules.AddComponent<T>();
    static void AddHaxGameObject<T>() where T : Component => Loader.HaxGameObject.AddComponent<T>();

    public static void Load() {
        DontDestroyOnLoad(Loader.HaxGameObject);

        AddHaxGameObject<CursorController>();
        AddHaxGameObject<DebugController>();
        AddHaxGameObject<InputListener>();
        AddHaxGameObject<Console>();
        AddHaxGameObject<ConsoleInputField>();
        AddHaxGameObject<Menu>();
        AddHaxGameObject<Hax>();
        AddHaxGameObject<HaxObjects>();

        Loader.LoadHaxModules();
    }

    static void LoadHaxModules() {
        DontDestroyOnLoad(Loader.HaxModules);

        AddHaxModules<Aimbot>();
        AddHaxModules<PlayerESP>();
        AddHaxModules<NoClip>();
        AddHaxModules<Freecam>();
        AddHaxModules<Voodoo>();
        AddHaxModules<PingMod>();

        AddHaxModules<Enemy>();
        AddHaxModules<Player>();
        AddHaxModules<Teams>();

        AddHaxModules<FakeCrosshair>();
        AddHaxModules<NoFog>();
        AddHaxModules<NoCameraShake>();
        AddHaxModules<UndergroundSpawn>();

        AddHaxModules<WeaponMod>();
        AddHaxModules<PlasmaMod>();
        AddHaxModules<NanoMod>();
        AddHaxModules<RailMod>();
        AddHaxModules<SMGMod>();
        AddHaxModules<TeslaMod>();

        AddHaxModules<EnemyRadarMod>();
        AddHaxModules<WheelMod>();
        // AddHaxModules<AerofoilMod>();
        // AddHaxModules<JetMod>();
        // AddHaxModules<RotorMod>();
        // AddHaxModules<LegMod>();
    }

    public static void Unload() {
        Destroy(Loader.HaxModules);
        Destroy(Loader.HaxGameObject);
    }
}
