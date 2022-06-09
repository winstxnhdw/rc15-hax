using Simulation;

namespace RC15_HAX;
public class SMGMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableSMGMod"); }

    protected override void OnEnable() {
        this.ModSMG();
    }

    void ModSMG() {
        if (!ModEnabled) return;

        float[] groupFirePeriods = new float[5];
        for (int i = 0; i < 5; i++) {
            groupFirePeriods[i] = HaxSettings.GetValue<float>($"groupFirePeriod{i}");
        }

        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
        if (fireTimingData == null) return;
        fireTimingData.groupFirePeriod = groupFirePeriods;
        fireTimingData.laserCannonZoomedFoV = HaxSettings.GetValue<float>("laserCannonZoomedFoV");
        fireTimingData.Start();
    }
}