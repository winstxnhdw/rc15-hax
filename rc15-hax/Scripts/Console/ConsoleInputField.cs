using System.Text.RegularExpressions;
using UnityEngine;

namespace RC15_HAX;
public class ConsoleInputField : HaxComponents {
    void OnGUI() {
        Event e = Event.current;
        if (e.type == EventType.keyDown) {
            if (e.keyCode == KeyCode.Return) {
                this.OnSubmit();
            }

            else if (e.keyCode == KeyCode.Escape) {
                GUI.FocusControl(null);
            }
        }

        this.RenderConsoleInput();
    }

    void OnSubmit() {
        if (!ConsoleSettings.ShowConsole) return;

        ConsoleSettings.FieldText = Regex.Replace(ConsoleSettings.FieldText, @"\s+", " ");
        Console.Print(ConsoleSettings.FieldText);
        string[] input = ConsoleSettings.FieldText.Split(' ');

        bool commandFound = false;

        foreach (object command in DebugController.CommandList) {
            DebugCommandBase commandBase = command as DebugCommandBase;
            if (commandBase!.Name != input[0]) continue;

            commandFound = true;

            if (command as DebugCommand != null) {
                (command as DebugCommand)?.Invoke();
            }

            if (input.Length <= 1) {
                Console.Print("Invalid argument.");
                continue;
            }

            else if (command as DebugCommand<string> != null) {
                (command as DebugCommand<string>)?.Invoke(input[1]);
            }
        }

        if (!commandFound && !Global.IsNullOrWhiteSpace(ConsoleSettings.FieldText)) {
            Console.Print($"Command '{input[0]}' not found.");
        }

        ConsoleInputField.ClearInputField();
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

    public static void ClearInputField() {
        ConsoleSettings.FieldText = string.Empty;
    }
}
