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
        for (int i = 0; i < 4; i++) {
            railReloadDurations[i] = HaxSettings.GetValue<float>($"railReloadDuration{i}");
        }

        float[] railFirePeriods = new float[6];
        for (int i = 1; i < 6; i++) {
            railFirePeriods[i] = HaxSettings.GetValue<float>($"railFirePeriod{i}");
        }

        Global.SetInternalFieldValue(fireTimingData, "railReloadDuration", railReloadDurations);
        Global.SetInternalFieldValue(fireTimingData, "railFirePeriod", railFirePeriods);
        Global.SetInternalFieldValue(fireTimingData, "railFireDelay", HaxSettings.GetValue<float>("railFireDelay"));
        fireTimingData.Start();
    }
}