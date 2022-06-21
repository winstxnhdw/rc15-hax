using System.Reflection;
using System.Linq;
using UnityEngine;
using Simulation;
namespace RC15_HAX;
public class NanoMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableNanoMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        new ModCoroutine(this, this.ModNano).Init(2.0f);
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
    }

    void ModNano() {
        foreach (Object nanoBeam in HaxObjects.PlayerRigidbody.GetComponentsInChildren(Global.GetRobocraftType("Simulation.NanoBeam"))) {
            object internalNano = new Reflector(nanoBeam).GetInternalField<object>("_internalWeapon");
            new Reflector(internalNano).SetInternalField("_damagePerSecond", HaxSettings.GetValue<int>("NanoDPS"))
                                       .SetInternalField("_healPerSecond", HaxSettings.GetValue<int>("NanoHPS"))
                                       .SetInternalField("_range", HaxSettings.GetValue<float>("NanoRange"));
        }
    }
}