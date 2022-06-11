namespace RC15_HAX;
public class NoCameraShake : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("NoCameraShake"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        HaxObjects.CameraShakeObject.Init(this);
    }

    protected override void OnDisable() {
        HaxObjects.CameraShakeObject.StopLog();
    }

    void Update() {
        this.DisableCameraShake();
    }

    void DisableCameraShake() {
        CameraShake cameraShake = HaxObjects.CameraShakeObject.Object;
        if (!ModEnabled || cameraShake == null) return;
        cameraShake.enabled = false;
    }
}