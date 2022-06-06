using UnityEngine;

namespace RC15_HAX;
public class NoFog : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("NoFog");

    void OnEnable() {
        if (!ModEnabled) return;
        RenderSettings.fog = false;
    }

    void OnDisable() {
        RenderSettings.fog = true;
    }
}