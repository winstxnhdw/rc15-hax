using Simulation;

namespace RC15_HAX;
public class SMGMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableSMGMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.ModSMG();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
    }

    void ModSMG() {
        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
        if (fireTimingData == null) return;

        float[] groupFirePeriods = new float[5];
        for (int i = 0; i < 5; i++) {
            groupFirePeriods[i] = HaxSettings.GetValue<float>($"groupFirePeriod{i}");
        }

        fireTimingData.groupFirePeriod = groupFirePeriods;
        fireTimingData.Start();
    }
}