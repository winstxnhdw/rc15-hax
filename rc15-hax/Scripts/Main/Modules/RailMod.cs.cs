using Simulation;

namespace RC15_HAX;
public class RailMod : HaxModules {
    bool ModEnabled { get; } = HaxSettings.GetValue<bool>("EnableRailMod");

    protected override void OnEnable() {
        this.ModRail();
    }

    void ModRail() {
        if (!ModEnabled) return;

        float[] railReloadDurations = new float[6];
        for (int i = 0; i < 4; i++) {
            railReloadDurations[i] = HaxSettings.GetValue<float>($"railReloadDuration{i}");
        }

        float[] railFirePeriods = new float[6];
        for (int i = 1; i < 6; i++) {
            railFirePeriods[i] = HaxSettings.GetValue<float>($"railFirePeriod{i}");
        }

        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
        if (fireTimingData == null) return;
        fireTimingData.railReloadDuration = railReloadDurations;
        fireTimingData.railFirePeriod = railFirePeriods;
        fireTimingData.railFireDelay = HaxSettings.GetValue<float>("railFireDelay");
        fireTimingData.railGunZoomedFov = HaxSettings.GetValue<float>("railGunZoomedFov");
        fireTimingData.Start();
    }
}