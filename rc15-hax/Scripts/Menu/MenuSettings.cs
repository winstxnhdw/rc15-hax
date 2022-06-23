using UnityEngine;

public static class MenuSettings {
    static float MenuHeight => 0.4f * Screen.height;

    static float MenuWidth => 0.2f * Screen.width;

    public static bool ShowMenu { get; set; } = false;

    public static Rect MenuRect => new Rect(0.0f, 0.0f, MenuSettings.MenuWidth, MenuSettings.MenuHeight);
}