using UnityEngine;

namespace RC15_HAX;
public class NoFog : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("NoFog"); }
    float DefaultFarClipPlane { get; set; }

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
        float DefaultFarClipPlane = Global.Camera.farClipPlane;
        Global.Camera.farClipPlane = float.MaxValue;
    }

    void DisableNoFog() {
        RenderSettings.fog = true;
        Global.Camera.farClipPlane = this.DefaultFarClipPlane;
    }
}