
using System.Text.RegularExpressions;
using UnityEngine;

namespace RC15_HAX;
public class ConsoleInputField : HaxComponents {
    void OnGUI() {
        this.RenderConsoleInput();

        if (Event.current.keyCode == KeyCode.Return) {
            this.OnSubmit();
        }

        else if (Event.current.keyCode == KeyCode.Escape) {
            GUI.FocusControl(null);
        }
    }

    void OnSubmit() {
        if (!ConsoleSettings.ShowConsole) return;
        if (string.IsNullOrEmpty(ConsoleSettings.FieldText)) return;

        ConsoleSettings.FieldText = Regex.Replace(ConsoleSettings.FieldText, @"\s+", " ");
        Console.Print(ConsoleSettings.FieldText);
        string[] input = ConsoleSettings.FieldText.Split(' ');

        bool commandFound = false;

        for (int i = 0; i < DebugController.CommandList.Count; i++) {
            DebugCommandBase? commandBase = DebugController.CommandList[i] as DebugCommandBase;
            if (commandBase!.Name != input[0]) continue;
            commandFound = true;

            if (DebugController.CommandList[i] as DebugCommand != null) {
                (DebugController.CommandList[i] as DebugCommand)?.Invoke();
            }
        }

        if (!commandFound) {
            Console.Print($"Command '{input[0]}' not found.");
        }

        ConsoleSettings.FieldText = string.Empty;
        Console.ScrollToBottom();
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