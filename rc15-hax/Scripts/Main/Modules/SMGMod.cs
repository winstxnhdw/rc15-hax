using System.Linq;
using Simulation;

namespace RC15_HAX;
public class SMGMod : HaxModules {
    protected override bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableSMGMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.ModSMG();
    }

    void ModSMG() {
        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
        if (fireTimingData == null) return;

        float[] groupFirePeriods = (from i in Enumerable.Range(0, 5) select HaxSettings.GetValue<float>($"groupFirePeriod{i}")).ToArray();
        new Reflector(fireTimingData).SetInternalField("groupFirePeriod", groupFirePeriods);
        fireTimingData.Start();
    }
}