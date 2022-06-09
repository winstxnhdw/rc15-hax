using UnityEngine;

namespace RC15_HAX;
public class NoFog : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("NoFog"); }

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
    }

    void DisableNoFog() {
        RenderSettings.fog = true;
    }
}