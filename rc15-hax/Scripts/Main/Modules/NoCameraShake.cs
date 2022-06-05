namespace RC15_HAX;
public class NoCameraShake : HaxComponents {
    void Update() {
        this.DisableCameraShake();
    }

    void DisableCameraShake() {
        if (!bool.Parse(HaxSettings.Params["NoCameraShake"])) return;
        HaxObjects.CameraShakeObject.Objects[0].enabled = false;
    }
}