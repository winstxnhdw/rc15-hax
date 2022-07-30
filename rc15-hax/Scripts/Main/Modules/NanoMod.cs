using UnityEngine;
namespace Hax;
public class NanoMod : HaxModules {
    protected override bool ModEnabled => HaxSettings.GetValue<bool>("EnableNanoMod");

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        ModCoroutine.Create(this, this.ModNano).Init(2.0f);
    }

    void ModNano() {
        foreach (Object nanoBeam in Robocraft.GetComponentsInChildren(HaxObjects.PlayerRigidbody, "Simulation.NanoBeam")) {
            Reflector.Target(nanoBeam)
                     .GetInternalField("_internalWeapon")
                     .SetInternalField("_damagePerSecond", HaxSettings.GetValue<int>("NanoDPS"))
                     .SetInternalField("_healPerSecond", HaxSettings.GetValue<int>("NanoHPS"))
                     .SetInternalField("_range", HaxSettings.GetValue<float>("NanoRange"));
        }
    }
}
