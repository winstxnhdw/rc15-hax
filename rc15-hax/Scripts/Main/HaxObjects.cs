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

    protected override void Start() {
        base.Start();
        HaxObjects.PlayerRigidbody.Init(this);
        HaxObjects.Rigidbodies.Init(this);
        HaxObjects.CameraShakeObject.Init(this);
        HaxObjects.SimulationCameraObject.Init(this);
        HaxObjects.TopBarObject.Init(this);
    }
}