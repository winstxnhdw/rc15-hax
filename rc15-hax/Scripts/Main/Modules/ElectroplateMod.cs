// using System.Linq;
// using Simulation;

// namespace Hax;
// public class ElectroplateMod : HaxModules {
//     bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableRailMod"); }

//     protected override void OnEnable() {
//         if (!this.ModEnabled) return;

//         base.OnEnable();
//         this.ModRail();
//     }

//     protected override void OnDisable() {
//         if (!this.ModEnabled) return;

//         base.OnDisable();
//     }

//     void ModRail() {
//         FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
//         if (fireTimingData == null) return;

//         float[] railReloadDurations = new float[6];
//         railReloadDurations.Take(4).Select((x, i) => x = HaxSettings.GetValue<float>($"railReloadDuration{i}"));

//         float[] railFirePeriods = new float[6];
//         railFirePeriods.Skip(1).Select((x, i) => x = HaxSettings.GetValue<float>($"railFirePeriod{i}"));

//         Global.SetInternalFieldValue(fireTimingData, "railReloadDuration", railReloadDurations);
//         Global.SetInternalFieldValue(fireTimingData, "railFirePeriod", railFirePeriods);
//         Global.SetInternalFieldValue(fireTimingData, "railFireDelay", HaxSettings.GetValue<float>("railFireDelay"));
//         fireTimingData.Start();
//     }
// }