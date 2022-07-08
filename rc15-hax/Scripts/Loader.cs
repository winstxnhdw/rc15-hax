using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using HarmonyLib;

namespace RC15_HAX;
public class Loader : MonoBehaviour {
    static GameObject HaxGameObject { get; } = new GameObject();
    public static GameObject HaxModules { get; } = new GameObject();
    public static GameObject HaxStealthModules { get; } = new GameObject();

    static void AddHaxModules<T>() where T : Component => Loader.HaxModules.AddComponent<T>();
    static void AddHaxGameObject<T>() where T : Component => Loader.HaxGameObject.AddComponent<T>();
    static void DontDisableOnStealth<T>() where T : Component => Loader.HaxStealthModules.AddComponent<T>();

    static Assembly OnResolveAssembly(object _, ResolveEventArgs args) {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        string resource = executingAssembly.GetManifestResourceNames().FirstOrDefault(s => s.EndsWith($"{new AssemblyName(args.Name).Name}.dll"));

        using (Stream stream = executingAssembly.GetManifestResourceStream(resource)) {
            if (stream == null) return null;

            byte[] block = new byte[stream.Length];
            stream.Read(block, 0, block.Length);
            return Assembly.Load(block);
        }
    }

    public static void Load() {
        AppDomain.CurrentDomain.AssemblyResolve += Loader.OnResolveAssembly;

        Loader.LoadHarmonyPatches();
        Loader.LoadHaxGameObjects();
        Loader.LoadHaxModules();

        AppDomain.CurrentDomain.AssemblyResolve -= Loader.OnResolveAssembly;
    }

    static void LoadHarmonyPatches() {
        new Harmony("winstxnhdw.rc15-hax").PatchAll();
    }

    static void LoadHaxGameObjects() {
        DontDestroyOnLoad(Loader.HaxGameObject);

        AddHaxGameObject<CursorController>();
        AddHaxGameObject<DebugController>();
        AddHaxGameObject<InputListener>();
        AddHaxGameObject<Console>();
        AddHaxGameObject<ConsoleInputField>();
        AddHaxGameObject<Menu>();
        AddHaxGameObject<Hax>();
        AddHaxGameObject<HaxObjects>();
    }

    static void LoadHaxModules() {
        DontDestroyOnLoad(Loader.HaxModules);
        DontDestroyOnLoad(Loader.HaxStealthModules);

        AddHaxModules<Aimbot>();
        AddHaxModules<PlayerESP>();
        AddHaxModules<NoClip>();
        AddHaxModules<Freecam>();
        AddHaxModules<Voodoo>();
        AddHaxModules<PingMod>();
        AddHaxModules<NetworkDesync>();
        AddHaxModules<SelfDestruct>();

        DontDisableOnStealth<Enemy>();
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
