using Simulation;

namespace RC15_HAX;
public class RotorMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableRotorMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        HaxObjects.RotorObjects.Init(this);
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        HaxObjects.RotorObjects.StopLog();
    }

    void Update() {
        this.ModRotor();
    }

    void ModRotor() {
        if (!this.ModEnabled) return;

        foreach (CubeRotor cubeRotor in HaxObjects.RotorObjects.Objects) {
            cubeRotor.maxCarryingMass = HaxSettings.GetValue<float>("rotorMaxCarryingMass");
            cubeRotor.driftAcceleration = HaxSettings.GetValue<float>("driftAcceleration");
        }
    }
}