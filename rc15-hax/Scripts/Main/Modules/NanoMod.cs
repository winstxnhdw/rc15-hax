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
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
    }

    void Update() {
        this.ModNano();
    }

    void ModNano() {
        if (!this.ModEnabled) return;

        foreach (Object nanoBeam in HaxObjects.PlayerRigidbody.GetComponentsInChildren(Global.GetRobocraftType("Simulation.NanoBeam"))) {
            object internalNano = new Reflector(nanoBeam).GetInternalField<object>("_internalWeapon");
            new Reflector(internalNano).SetInternalField("_damagePerSecond", HaxSettings.GetValue<int>("NanoDPS"))
                                       .SetInternalField("_healPerSecond", HaxSettings.GetValue<int>("NanoHPS"))
                                       .SetInternalField("_range", HaxSettings.GetValue<float>("NanoRange"));
        }
    }
}