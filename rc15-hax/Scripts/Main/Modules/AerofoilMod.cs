namespace RC15_HAX;
public class AerofoilMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnableAerofoilMod");

    void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.AerofoilObjects.Init(this);
    }

    void OnDisable() {
        HaxObjects.AerofoilObjects.Stop();
    }

    void Update() {
        this.ModAerofoil();
    }

    void ModAerofoil() {
        if (!ModEnabled) return;

        foreach (CubeAerofoil cubeAerofoil in HaxObjects.AerofoilObjects.Objects) {
            cubeAerofoil.dragMinVelocity = HaxSettings.GetFloat("dragMinVelocity");
            cubeAerofoil.dragMaxVelocity = HaxSettings.GetFloat("dragMaxVelocity");
        }
    }
}