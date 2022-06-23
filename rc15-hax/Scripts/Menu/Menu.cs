using UnityEngine;

namespace RC15_HAX;
public class Menu : HaxComponents {
    Rect WindowRect { get; set; } = MenuSettings.MenuRect;
    static Vector2 Scroll { get; set; } = Vector2.zero;

    void Awake() {
        InputListener.onF8Press += this.ToggleMenu;
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
            GUILayout.Button("Unload Hax");
        });

        GUILayout.EndScrollView();
        GUI.DragWindow();
    }

    void ToggleMenu() => MenuSettings.ShowMenu = !MenuSettings.ShowMenu;

    void OnDestroy() {
        InputListener.onF8Press -= this.ToggleMenu;
    }
}