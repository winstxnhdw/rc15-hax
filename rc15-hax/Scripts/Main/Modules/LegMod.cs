// using Simulation;

// namespace Hax;
// public class LegMod : HaxModules {
//     bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableLegMod"); }

//     protected override void OnEnable() {
//         if (!this.ModEnabled) return;

//         base.OnEnable();
//         HaxObjects.LegObjects.Init(this);
//     }

//     protected override void OnDisable() {
//         if (!this.ModEnabled) return;

//         base.OnDisable();
//         HaxObjects.LegObjects.StopLog();
//     }

//     void Update() {
//         this.ModLeg();
//     }

//     void ModLeg() {
//         if (!this.ModEnabled) return;

//         foreach (CubeLeg cubeLeg in HaxObjects.LegObjects.Objects) {
//             cubeLeg.timeGroundedBeforeJump = HaxSettings.GetValue<float>("timeGroundedBeforeJump");

//             cubeLeg.lightLegMass = HaxSettings.GetValue<float>("lightLegMass");
//             cubeLeg.lightLegMovement.maxUpwardsForce = HaxSettings.GetValue<float>("maxUpwardsForce");
//             cubeLeg.lightLegMovement.jumpHeight = HaxSettings.GetValue<float>("jumpHeight");
//             cubeLeg.lightLegMovement.maxWorkingSpeed = HaxSettings.GetValue<float>("maxWorkingSpeed");
//             cubeLeg.lightLegMovement.maxLateralSpeed = HaxSettings.GetValue<float>("maxLateralSpeed");

//             cubeLeg.heavyLegMass = HaxSettings.GetValue<float>("heavyLegMass");
//             cubeLeg.heavyLegMovement.maxUpwardsForce = HaxSettings.GetValue<float>("maxUpwardsForce");
//             cubeLeg.heavyLegMovement.jumpHeight = HaxSettings.GetValue<float>("jumpHeight");
//             cubeLeg.heavyLegMovement.maxWorkingSpeed = HaxSettings.GetValue<float>("maxWorkingSpeed");
//             cubeLeg.heavyLegMovement.maxLateralSpeed = HaxSettings.GetValue<float>("maxLateralSpeed");
//         }
//     }
// }