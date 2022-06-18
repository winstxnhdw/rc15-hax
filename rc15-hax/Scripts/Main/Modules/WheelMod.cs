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
            Global.SetInternalFieldValue(cubeWheel, "wheelMass", 0.0f);
            Global.SetInternalFieldValue(cubeWheel, "massPerWheel", 0.0f);
            Global.SetInternalFieldValue(cubeWheel, "maxRPM", HaxSettings.GetValue<float>("maxRPM"));
            Global.SetInternalFieldValue(cubeWheel, "maxSteeringAngle", HaxSettings.GetValue<float>("maxSteeringAngle"));
            Global.SetInternalFieldValue(cubeWheel, "stoppingBrakeTorque", HaxSettings.GetValue<float>("stoppingBrakeTorque"));
            Global.SetInternalFieldValue(cubeWheel, "motorizedBrakeTorque", HaxSettings.GetValue<float>("motorizedBrakeTorque"));
            Global.SetInternalFieldValue(cubeWheel, "freeWheelBrakeTorque", HaxSettings.GetValue<float>("freeWheelBrakeTorque"));
            Global.GetInternalFieldValue<WheelFriction>(cubeWheel, "friction").groundFrictionMultiplier = HaxSettings.GetValue<float>("groundFrictionMultiplier");

        }
    }
}