using System.Linq;
using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class RailMod : HaxModules {
    protected override bool ModEnabled => HaxSettings.GetValue<bool>("EnableRailMod");

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        new ModCoroutine(this, this.ModRail).Init(5.0f);
    }

    void ModRail() {
        foreach (Object railGun in Robocraft.GetComponentsInChildren(HaxObjects.PlayerRigidbody, "RailGun")) {
            object internalRail = new Reflector(railGun).GetInternalField<object>("_internalWeapon");
            Reflector internalRailReflection = new Reflector(internalRail);
            internalRailReflection.SetInternalField("_currentDamageInflicted", HaxSettings.GetValue<int>("RailDamage"));
        }

        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
        if (fireTimingData == null) return;

        float[] railReloadDurations = new float[6];
        railReloadDurations.Take(4).Select((x, i) => x = HaxSettings.GetValue<float>($"railReloadDuration{i}"));

        float[] railFirePeriods = new float[6];
        railFirePeriods.Skip(1).Select((x, i) => x = HaxSettings.GetValue<float>($"railFirePeriod{i}"));

        new Reflector(fireTimingData).SetInternalField("railReloadDuration", railReloadDurations)
                                     .SetInternalField("railFirePeriod", railFirePeriods)
                                     .SetInternalField("railFireDelay", HaxSettings.GetValue<float>("railFireDelay"));
        fireTimingData.Start();
    }
}