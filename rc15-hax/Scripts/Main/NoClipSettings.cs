using System;
using UnityEngine;

namespace RC15_HAX;
public static class NoClipSettings {
    static Func<float, float> ClampNoClipSpeed = (float value) => Mathf.Clamp(value, 0.1f, float.MaxValue);

    static float noClipSpeedMultiplier = NoClipSettings.ClampNoClipSpeed(HaxSettings.GetValue<float>("NoClipSpeedMultiplier"));

    public static float NoClipSpeedMultiplier {
        get => NoClipSettings.noClipSpeedMultiplier;
        set => NoClipSettings.noClipSpeedMultiplier = NoClipSettings.ClampNoClipSpeed(value);
    }
}