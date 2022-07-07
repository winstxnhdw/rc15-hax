namespace RC15_HAX;
public class WheelMod : HaxModules {
    protected override bool ModEnabled => HaxSettings.GetValue<bool>("EnableWheelMod");

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        ModCoroutine.Create(this, this.ModWheel).Init(2.0f);
    }

    void ModWheel() {
        foreach (CubeWheel cubeWheel in HaxObjects.PlayerRigidbody.GetComponentsInChildren<CubeWheel>()) {
            Reflector.Target(cubeWheel)
                     .SetInternalField("wheelMass", 0.0f)
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