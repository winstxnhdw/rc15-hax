using UnityEngine;

namespace RC15_HAX;
public static class NoClipSettings {
    static Global.Func<int, int> ClampNoClipSpeed = (int value) => Mathf.Clamp(value, 1, int.MaxValue);

    static int noClipSpeedMultiplier = NoClipSettings.ClampNoClipSpeed(HaxSettings.GetValue<int>("NoClipSpeedMultiplier"));

    public static int NoClipSpeedMultiplier {
        get => NoClipSettings.noClipSpeedMultiplier;
        set => NoClipSettings.noClipSpeedMultiplier = NoClipSettings.ClampNoClipSpeed(value);
    }
}