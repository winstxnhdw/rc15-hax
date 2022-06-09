namespace RC15_HAX;
public class WheelMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableWheelMod"); }

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
            cubeWheel.maxRPM = HaxSettings.GetValue<float>("maxRPM");
            cubeWheel.friction.groundFrictionMultiplier = HaxSettings.GetValue<float>("groundFrictionMultiplier");
            cubeWheel.stoppingBrakeTorque = HaxSettings.GetValue<float>("stoppingBrakeTorque");
            cubeWheel.maxSteeringAngle = HaxSettings.GetValue<float>("maxSteeringAngle");
        }
    }
}