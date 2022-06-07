using UnityEngine;

namespace RC15_HAX;
public class NoFog : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("NoFog");

    protected override void OnEnable() {
        base.OnEnable();
        this.EnableFog();
    }

    protected override void OnDisable() {
        base.OnDisable();
        this.DisableFog();
    }

    void EnableFog() {
        if (!ModEnabled) return;
        RenderSettings.fog = true;
    }

    void DisableFog() {
        RenderSettings.fog = false;
    }
}