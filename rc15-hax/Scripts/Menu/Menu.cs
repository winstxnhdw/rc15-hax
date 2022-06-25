using System;
using UnityEngine;

namespace RC15_HAX;
public class Menu : HaxComponents {
    Rect WindowRect { get; set; } = MenuSettings.MenuRect;
    static Vector2 Scroll { get; set; } = Vector2.zero;

    void Awake() {
        InputListener.onEscapePress += this.HideMenu;
    }

    void OnGUI() {
        this.RenderMenu();
    }

    void RenderMenu() {
        if (!MenuSettings.ShowMenu) return;
        this.WindowRect = GUILayout.Window(0, this.WindowRect, this.RenderMenuWindow, "Menu");
    }

    void RenderMenuWindow(int windowIndex) {
        Menu.Scroll = GUILayout.BeginScrollView(Menu.Scroll);

        GUIHelper.HorizontalGroup(() => {
            if (GUILayout.Button("Hide")) HideMenu();
        });

        GUIHelper.HorizontalGroup(() => {
            MenuOptions.EnableNetworkDesync = GUIHelper.CreateToggle("NetworkDesync", MenuOptions.EnableNetworkDesync);
            MenuOptions.EnablePlayerESP = GUIHelper.CreateToggle("PlayerESP", MenuOptions.EnablePlayerESP);
            MenuOptions.UseFakeCrosshair = GUIHelper.CreateToggle("FakeCrosshair", MenuOptions.UseFakeCrosshair);
        });

        GUIHelper.HorizontalGroup(() => {
            MenuOptions.EnableStealth = GUIHelper.CreateToggle("Stealth", MenuOptions.EnableStealth);
        });

        GUIHelper.HorizontalGroup(() => {
            if (GUILayout.Button("Unload Hax")) Loader.Unload();
        });

        GUILayout.EndScrollView();
        GUI.DragWindow(MenuSettings.MenuDragBounds);
    }

    public static void ShowMenu() => MenuSettings.ShowMenu = !MenuSettings.ShowMenu;

    void HideMenu() => MenuSettings.ShowMenu = false;

    void OnDestroy() {
        InputListener.onEscapePress -= this.HideMenu;
    }
}