namespace RC15_HAX;
public class AerofoilMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnableAerofoilMod");

    protected override void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.AerofoilObjects.Init(this);
    }

    protected override void OnDisable() {
        HaxObjects.AerofoilObjects.StopLog();
    }

    void Update() {
        this.ModAerofoil();
    }

    void ModAerofoil() {
        if (!ModEnabled) return;

        foreach (CubeAerofoil cubeAerofoil in HaxObjects.AerofoilObjects.Objects) {
            cubeAerofoil.maxCarryingMass = HaxSettings.GetFloat("aerofoilMaxCarryingMass");
            cubeAerofoil.horizontalCarryingMassScale = HaxSettings.GetFloat("horizontalCarryingMassScale");
        }
    }
}