
using UnityEngine;

namespace RC15_HAX;
public class ConsoleInputField : MonoBehaviour {
    void OnGUI() {
        this.RenderConsoleInput();
    }

    void RenderConsoleInput() {
        if (!ConsoleSettings.ShowConsole) return;

        GUI.Box(ConsoleSettings.FieldContainerRect, "");
        this.CreateTextField();
    }

    void CreateTextField() {
        GUI.backgroundColor = Color.clear;
        ConsoleSettings.FieldText = GUI.TextField(ConsoleSettings.FieldRect, ConsoleSettings.FieldText);
    }
}