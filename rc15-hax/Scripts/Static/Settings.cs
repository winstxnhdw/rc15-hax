using UnityEngine;
namespace RC15_HAX;
public static class Settings {
    public static float SizeRatio => Screen.height / 1080.0f;
    public static float BoxLineWidth => 1.0f * Settings.SizeRatio;
    public static float OutlineBoxSize => 4000.0f * Settings.SizeRatio;
    // public static bool MenuToggle { get; set; } = false;
    // public static bool cameraShakeToggle = true;
    // public static bool noClipToggle = false;
    // public static bool espToggle = false;
    // public static bool aimBotToggle = false;
}
