namespace RC15_HAX;
public class WheelMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnableWheelMod");

    void OnEnable() {
        if (!this.ModEnabled) return;

        HaxObjects.WheelObjects.Init(this);
    }

    void OnDisable() {
        HaxObjects.WheelObjects.Stop();
    }

    void Update() {
        this.ModWheel();
    }

    void ModWheel() {
        if (!this.ModEnabled) return;

        foreach (CubeWheel cubeWheel in HaxObjects.WheelObjects.Objects) {
            cubeWheel.maxRPM = HaxSettings.GetFloat("maxRPM");
            cubeWheel.friction.groundFrictionMultiplier = HaxSettings.GetFloat("groundFrictionMultiplier");
        }
    }
}