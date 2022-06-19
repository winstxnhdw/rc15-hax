using System.Linq;
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

        float[] groupFirePeriods = (from i in Enumerable.Range(0, 5) select HaxSettings.GetValue<float>($"groupFirePeriod{i}")).ToArray();
        Global.SetInternalFieldValue(fireTimingData, "groupFirePeriod", groupFirePeriods);
        fireTimingData.Start();
    }
}