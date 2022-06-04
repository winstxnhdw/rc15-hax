using UnityEngine;

namespace RC15_HAX;
public class CursorController : HaxComponents {
    bool CursorLocked { get; set; } = false;

    void Update() {
        this.UnlockCursor();
    }

    void UnlockCursor() {
        if (ConsoleSettings.ShowConsole) {
            Screen.lockCursor = false;
            this.CursorLocked = false;
        }

        else if (!CursorLocked) {
            Screen.lockCursor = true;
            this.CursorLocked = true;
        }
    }
}