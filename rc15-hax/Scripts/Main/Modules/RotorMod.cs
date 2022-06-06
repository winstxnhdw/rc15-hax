using Simulation;

namespace RC15_HAX;
public class RotorMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnableRotorMod");

    void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.RotorObjects.Init(this);
    }

    void OnDisable() {
        HaxObjects.RotorObjects.StopLog();
    }

    void Update() {
        this.ModRotor();
    }

    void ModRotor() {
        if (!ModEnabled) return;

        foreach (CubeRotor cubeRotor in HaxObjects.RotorObjects.Objects) {
            cubeRotor.maxCarryingMass = HaxSettings.GetFloat("rotorMaxCarryingMass");
            cubeRotor.driftAcceleration = HaxSettings.GetFloat("driftAcceleration");
        }
    }
}