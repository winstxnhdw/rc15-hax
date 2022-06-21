using System.Collections;
using UnityEngine;

namespace RC15_HAX;
public class NoCameraShake : HaxModules {
    protected override bool ModEnabled { get => HaxSettings.GetValue<bool>("NoCameraShake"); }
    Reflector CameraShakeReflection { get; set; }
    Vector3 StoredCameraPosition { get; set; }
    Quaternion StoredCameraRotation { get; set; }
    bool IsStored { get; set; } = false;


    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        StartCoroutine(StoreCameraTransform());
        this.CameraShakeReflection = new Reflector(Global.Camera.GetComponent<CameraShake>());
    }

    void LateUpdate() {
        if (!this.IsStored) return;

        Global.Camera.transform.localPosition = this.StoredCameraPosition;
        Global.Camera.transform.localRotation = this.StoredCameraRotation;
    }

    IEnumerator StoreCameraTransform() {
        while (true) {
            yield return null;
            this.CameraShakeReflection.SetInternalField("_shakeMag", 0.0f);
            this.StoredCameraPosition = Global.Camera.transform.localPosition;
            this.StoredCameraRotation = Global.Camera.transform.localRotation;
            this.IsStored = true;
        }
    }
}