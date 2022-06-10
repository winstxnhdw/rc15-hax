using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class HaxObjects : HaxComponents {
    public static ObjectCache<LocalPlayerRigidbody> PlayerRigidbody { get; } = new ObjectCache<LocalPlayerRigidbody>(1);
    public static ObjectCache<CameraShake> CameraShakeObject { get; } = new ObjectCache<CameraShake>();
    public static ObjectCache<FireTimingData> FireTimingDataObject { get; } = new ObjectCache<FireTimingData>();
    public static ObjectCache<SimulationCamera> SimulationCameraObject { get; } = new ObjectCache<SimulationCamera>();

    public static ObjectsCache<BaseWeapon> BaseWeaponObjects { get; } = new ObjectsCache<BaseWeapon>();
    public static ObjectsCache<PlasmaCannon> PlasmaCannonObjects { get; } = new ObjectsCache<PlasmaCannon>();

    public static ObjectsCache<Rigidbody> Rigidbodies { get; } = new ObjectsCache<Rigidbody>(3);
    public static ObjectsCache<CubeAerofoil> AerofoilObjects { get; } = new ObjectsCache<CubeAerofoil>();
    public static ObjectsCache<CubeJet> CubeJetObjects { get; } = new ObjectsCache<CubeJet>();
    public static ObjectsCache<CubeRotor> RotorObjects { get; } = new ObjectsCache<CubeRotor>();
    public static ObjectsCache<CubeWheel> WheelObjects { get; } = new ObjectsCache<CubeWheel>();
    public static ObjectsCache<CubeLeg> LegObjects { get; } = new ObjectsCache<CubeLeg>();

    protected override void Start() {
        base.Start();
        HaxObjects.PlayerRigidbody.Init(this);
        HaxObjects.Rigidbodies.Init(this);
        HaxObjects.SimulationCameraObject.Init(this);
        HaxObjects.FireTimingDataObject.Init(this);
    }
}