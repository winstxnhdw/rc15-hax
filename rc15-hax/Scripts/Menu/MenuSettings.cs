using UnityEngine;

namespace Hax;
public static class MenuSettings {
    static float MenuHeight => 0.4f * Screen.height;

    static float MenuWidth => 0.2f * Screen.width;

    static Vector2 MenuPositionCentre => ScreenInfo.GetScreenCentre() - new Vector2(MenuSettings.MenuWidth, MenuSettings.MenuHeight) * 0.5f;

    public static bool ShowMenu { get; set; } = false;

    public static Rect MenuDragBounds => new Rect(0.0f, 0.0f, Screen.width, Screen.height);

    public static Rect MenuRect => new Rect(MenuSettings.MenuPositionCentre.x, MenuSettings.MenuPositionCentre.y, MenuSettings.MenuWidth, MenuSettings.MenuHeight);
}