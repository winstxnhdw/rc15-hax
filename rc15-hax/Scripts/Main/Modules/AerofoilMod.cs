// namespace Hax;
// public class AerofoilMod : HaxModules {
//     bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableAerofoilMod"); }

//     protected override void OnEnable() {
//         if (!this.ModEnabled) return;

//         base.OnEnable();
//         HaxObjects.AerofoilObjects.Init(this);
//     }

//     protected override void OnDisable() {
//         if (!this.ModEnabled) return;

//         base.OnDisable();
//         HaxObjects.AerofoilObjects.StopLog();
//     }

//     void Update() {
//         this.ModAerofoil();
//     }

//     void ModAerofoil() {
//         if (!this.ModEnabled) return;

//         foreach (CubeAerofoil cubeAerofoil in HaxObjects.AerofoilObjects.Objects) {
//             cubeAerofoil.maxCarryingMass = HaxSettings.GetValue<float>("aerofoilMaxCarryingMass");
//             cubeAerofoil.horizontalCarryingMassScale = HaxSettings.GetValue<float>("horizontalCarryingMassScale");
//         }
//     }
// }