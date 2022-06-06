using UnityEngine;
using Simulation;
using Mothership;

namespace RC15_HAX;
public class HaxObjects : HaxComponents {
    public static ObjectCache<LocalPlayerRigidbody> PlayerRigidbody { get; } = new ObjectCache<LocalPlayerRigidbody>();
    public static ObjectCache<Rigidbody> Rigidbodies { get; } = new ObjectCache<Rigidbody>(3);
    public static ObjectCache<CameraShake> CameraShakeObject { get; } = new ObjectCache<CameraShake>(10);
    public static ObjectCache<SimulationCamera> SimulationCameraObject { get; } = new ObjectCache<SimulationCamera>();
    public static ObjectCache<TopBar> TopBarObject { get; } = new ObjectCache<TopBar>(10);
    public static ObjectCache<BaseWeapon> BaseWeaponObjects { get; } = new ObjectCache<BaseWeapon>();
    public static ObjectCache<PlasmaCannon> PlasmaCannonObjects { get; } = new ObjectCache<PlasmaCannon>();
    public static ObjectCache<CubeAerofoil> AerofoilObjects { get; } = new ObjectCache<CubeAerofoil>();
    public static ObjectCache<CubeJet> CubeJetObjects { get; } = new ObjectCache<CubeJet>();
    public static ObjectCache<CubeWheel> WheelObjects { get; } = new ObjectCache<CubeWheel>();


    protected override void Start() {
        base.Start();
        HaxObjects.PlayerRigidbody.Init(this);
        HaxObjects.Rigidbodies.Init(this);
        HaxObjects.CameraShakeObject.Init(this);
        HaxObjects.SimulationCameraObject.Init(this);
        HaxObjects.TopBarObject.Init(this);
    }
}