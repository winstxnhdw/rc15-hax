namespace RC15_HAX;
public class NoCameraShake : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("NoCameraShake");

    protected override void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.CameraShakeObject.Init(this);
    }

    protected override void OnDisable() {
        HaxObjects.CameraShakeObject.StopLog();
    }

    void Update() {
        this.DisableCameraShake();
    }

    void DisableCameraShake() {
        if (!ModEnabled) return;
        HaxObjects.CameraShakeObject.Objects[0].enabled = false;
    }
}