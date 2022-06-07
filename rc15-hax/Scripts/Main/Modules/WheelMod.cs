namespace RC15_HAX;
public class WheelMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnableWheelMod");

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        HaxObjects.WheelObjects.Init(this);
    }

    protected override void OnDisable() {
        HaxObjects.WheelObjects.StopLog();
    }

    void Update() {
        this.ModWheel();
    }

    void ModWheel() {
        if (!this.ModEnabled) return;

        foreach (CubeWheel cubeWheel in HaxObjects.WheelObjects.Objects) {
            cubeWheel.maxRPM = HaxSettings.GetFloat("maxRPM");
            cubeWheel.friction.groundFrictionMultiplier = HaxSettings.GetFloat("groundFrictionMultiplier");
            cubeWheel.stoppingBrakeTorque = HaxSettings.GetFloat("stoppingBrakeTorque");
            cubeWheel.maxSteeringAngle = HaxSettings.GetFloat("maxSteeringAngle");
        }
    }
}