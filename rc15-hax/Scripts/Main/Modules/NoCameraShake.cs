namespace RC15_HAX;
public class NoCameraShake : HaxModules {
    protected override bool ModEnabled { get => HaxSettings.GetValue<bool>("NoCameraShake"); }

    void Update() {
        this.DisableCameraShake();
    }

    void DisableCameraShake() {
        if (!this.ModEnabled) return;

        CameraShake cameraShake = Global.Camera.GetComponent<CameraShake>();
        new Reflector(cameraShake).SetInternalField("_shakeMag", 0.0f);
    }
}