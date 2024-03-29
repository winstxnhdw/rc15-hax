using UnityEngine;

namespace Hax;
public static class Settings {
    public static float SizeRatio => Screen.height / 1080.0f;
    public static float BoxLineWidth => 1.0f * Settings.SizeRatio;
}
