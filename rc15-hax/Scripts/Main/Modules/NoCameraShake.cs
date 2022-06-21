namespace RC15_HAX;
public class NoCameraShake : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("NoCameraShake"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.DisableCameraShake();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
    }

    void DisableCameraShake() {
        CameraShake cameraShake = Global.Camera.GetComponent<CameraShake>();
        new Reflector(cameraShake).SetInternalField("_shakeMag", 0.0f);
    }
}