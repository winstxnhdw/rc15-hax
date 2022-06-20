namespace RC15_HAX;
public class WheelMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableWheelMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        base.OnEnable();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
    }

    void Update() {
        this.ModWheel();
    }

    void ModWheel() {
        if (!this.ModEnabled) return;

        foreach (CubeWheel cubeWheel in HaxObjects.PlayerRigidbody.GetComponentsInChildren<CubeWheel>()) {
            new Reflector(cubeWheel).SetInternalField("wheelMass", 0.0f)
                                    .SetInternalField("massPerWheel", 0.0f)
                                    .SetInternalField("maxRPM", HaxSettings.GetValue<float>("maxRPM"))
                                    .SetInternalField("maxSteeringAngle", HaxSettings.GetValue<float>("maxSteeringAngle"))
                                    .SetInternalField("stoppingBrakeTorque", HaxSettings.GetValue<float>("stoppingBrakeTorque"))
                                    .SetInternalField("motorizedBrakeTorque", HaxSettings.GetValue<float>("motorizedBrakeTorque"))
                                    .SetInternalField("freeWheelBrakeTorque", HaxSettings.GetValue<float>("freeWheelBrakeTorque"))
                                    .GetInternalField<WheelFriction>("friction").groundFrictionMultiplier = HaxSettings.GetValue<float>("groundFrictionMultiplier");
        }
    }
}