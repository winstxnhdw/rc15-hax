using System.Linq;
using Simulation;

namespace RC15_HAX;
public class RailMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableRailMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.ModRail();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
    }

    void ModRail() {
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