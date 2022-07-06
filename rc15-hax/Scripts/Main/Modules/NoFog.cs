using System.Reflection;
using UnityEngine;

namespace RC15_HAX;
public class NoFog : HaxModules {
    protected override bool ModEnabled => HaxSettings.GetValue<bool>("NoFog");
    const float DefaultFarClipPlane = 650.0f;
    Reflector HeadLightManagerReflection { get; set; }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.HeadLightManagerReflection = Robocraft.GetReflector("Simulation.HeadLightManager");
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        RenderSettings.fog = true;
    }

    void LateUpdate() {
        this.EnableNoFog();
    }

    void EnableNoFog() {
        this.HeadLightManagerReflection.SetInternalStaticField("_counter", 1);
        Global.Camera.farClipPlane = HaxSettings.GetValue<float>("farClipPlane");
        RenderSettings.fog = false;
    }
}