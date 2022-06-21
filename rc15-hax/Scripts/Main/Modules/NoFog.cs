using UnityEngine;

namespace RC15_HAX;
public class NoFog : HaxModules {
    protected override bool ModEnabled { get => HaxSettings.GetValue<bool>("NoFog"); }
    const float DefaultFarClipPlane = 650.0f;

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.EnableNoFog();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        this.DisableNoFog();
    }

    void EnableNoFog() {
        RenderSettings.fog = false;
        Global.Camera.farClipPlane = HaxSettings.GetValue<float>("farClipPlane");
    }

    void DisableNoFog() {
        // RenderSettings.fog = true;
        // Global.Camera.farClipPlane = NoFog.DefaultFarClipPlane;
    }
}