using System.Collections;
using UnityEngine;

namespace RC15_HAX;
public class NoCameraShake : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("NoCameraShake"); }
    Vector3 StoredCameraPosition { get; set; }
    Quaternion StoredCameraRotation { get; set; }
    bool IsStored { get; set; } = false;


    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        this.DisableCameraShake();
        base.OnEnable();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
    }

    void LateUpdate() {
        if (!this.IsStored) return;

        Global.Camera.transform.localPosition = this.StoredCameraPosition;
        Global.Camera.transform.localRotation = this.StoredCameraRotation;
    }

    void DisableCameraShake() {
        StartCoroutine(this.IStoreCameraTransform());
    }

    IEnumerator IStoreCameraTransform() {
        while (true) {
            yield return null;
            this.StoredCameraPosition = Global.Camera.transform.localPosition;
            this.StoredCameraRotation = Global.Camera.transform.localRotation;
            this.IsStored = true;
        }
    }
}