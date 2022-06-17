using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class HaxObjects : HaxComponents {
    static ObjectCache<LocalPlayerRigidbody> playerRigidbody = new ObjectCache<LocalPlayerRigidbody>(1);
    public static Rigidbody PlayerRigidbody { get => playerRigidbody.Object.GetComponent<Rigidbody>(); }

    public static ObjectCache<CameraShake> CameraShakeObject { get; } = new ObjectCache<CameraShake>();
    public static ObjectCache<FireTimingData> FireTimingDataObject { get; } = new ObjectCache<FireTimingData>();
    public static ObjectCache<SimulationCamera> SimulationCameraObject { get; } = new ObjectCache<SimulationCamera>();

    public static ObjectsCache<BaseWeapon> BaseWeaponObjects { get; } = new ObjectsCache<BaseWeapon>();
    public static ObjectsCache<PlasmaCannon> PlasmaCannonObjects { get; } = new ObjectsCache<PlasmaCannon>();

    public static ObjectsCache<Rigidbody> Rigidbodies { get; } = new ObjectsCache<Rigidbody>(2);
    public static ObjectsCache<CubeAerofoil> AerofoilObjects { get; } = new ObjectsCache<CubeAerofoil>();
    public static ObjectsCache<CubeJet> CubeJetObjects { get; } = new ObjectsCache<CubeJet>();
    public static ObjectsCache<CubeRotor> RotorObjects { get; } = new ObjectsCache<CubeRotor>();
    public static ObjectsCache<CubeWheel> WheelObjects { get; } = new ObjectsCache<CubeWheel>();
    public static ObjectsCache<CubeLeg> LegObjects { get; } = new ObjectsCache<CubeLeg>();

    protected override void Start() {
        base.Start();
        HaxObjects.playerRigidbody.Init(this);
        HaxObjects.FireTimingDataObject.Init(this);
        HaxObjects.SimulationCameraObject.Init(this);
    }
}