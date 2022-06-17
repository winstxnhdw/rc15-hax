namespace RC15_HAX;
public class NoCameraShake : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("NoCameraShake"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        HaxObjects.CameraShakeObject.Init(this);
        this.DisableCameraShake();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        HaxObjects.CameraShakeObject.StopLog();
        this.EnableCameraShake();
    }

    void DisableCameraShake() {
        HaxObjects.CameraShakeObject.Object.enabled = false;
    }

    void EnableCameraShake() {
        HaxObjects.CameraShakeObject.Object.enabled = true;
    }
}