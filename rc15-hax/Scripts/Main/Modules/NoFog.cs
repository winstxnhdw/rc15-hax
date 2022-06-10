using UnityEngine;

namespace RC15_HAX;
public class NoFog : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("NoFog"); }
    float DefaultFarClipPlane { get => 650.0f; }

    protected override void OnEnable() {
        base.OnEnable();
        this.EnableNoFog();
    }

    protected override void OnDisable() {
        base.OnDisable();
        this.DisableNoFog();
    }

    void EnableNoFog() {
        if (!ModEnabled) return;

        RenderSettings.fog = false;
        Global.Camera.farClipPlane = HaxSettings.GetValue<float>("farClipPlane");
    }

    void DisableNoFog() {
        RenderSettings.fog = true;
        Global.Camera.farClipPlane = this.DefaultFarClipPlane;
    }
}