using UnityEngine;
namespace RC15_HAX;
public static class Settings {
    public static float SizeRatio => Screen.height / 1080.0f;
    public static float BoxLineWidth => 1.0f * Settings.SizeRatio;
}
