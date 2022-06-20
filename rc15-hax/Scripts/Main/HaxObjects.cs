using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class HaxObjects : HaxComponents {
    static ObjectCache<LocalPlayerRigidbody> playerRigidbody = new ObjectCache<LocalPlayerRigidbody>(0.5f);

    public static Rigidbody PlayerRigidbody {
        get {
            if (playerRigidbody.Object == null) return null;
            return HaxObjects.playerRigidbody.Object.GetComponent<Rigidbody>();
        }
    }

    public static ObjectCache<FireTimingData> FireTimingDataObject { get; } = new ObjectCache<FireTimingData>();
    // public static ObjectsCache<PlasmaCannon> PlasmaCannonObjects { get; } = new ObjectsCache<PlasmaCannon>();

    public static ObjectsCache<Rigidbody> Rigidbodies { get; } = new ObjectsCache<Rigidbody>(1.0f);
    // public static ObjectsCache<CubeAerofoil> AerofoilObjects { get; } = new ObjectsCache<CubeAerofoil>();
    // public static ObjectsCache<CubeJet> CubeJetObjects { get; } = new ObjectsCache<CubeJet>();
    // public static ObjectsCache<CubeRotor> RotorObjects { get; } = new ObjectsCache<CubeRotor>();
    // public static ObjectsCache<CubeLeg> LegObjects { get; } = new ObjectsCache<CubeLeg>();

    protected override void Start() {
        base.Start();
        HaxObjects.playerRigidbody.Init(this);
        HaxObjects.FireTimingDataObject.Init(this);
    }
}