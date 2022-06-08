using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class Console : HaxComponents {
    static List<string> FrozenLogs { get; set; } = new List<string>();
    static Vector2 Scroll { get; set; } = Vector2.zero;
    static Rect Viewport { get; set; } = new Rect(0, 0, 0, 0);

    void Awake() {
        InputListener.onBackquotePress += this.ShowConsole;
        InputListener.onEscapePress += this.HideConsole;
    }

    void OnGUI() {
        this.RenderConsole();
    }

    void RenderConsole() {
        if (!ConsoleSettings.ShowConsole) return;

        List<string> logs = !ConsoleSettings.PauseConsole ? ConsoleSettings.Logs : Console.FrozenLogs;

        Rect console = ConsoleSettings.ConsoleRect;
        GUI.Box(console, "Console");

        Console.Viewport = new Rect(0.0f, 0.0f, 0.9f * console.width, logs.Count * ConsoleSettings.LabelHeight);
        Console.Scroll = GUI.BeginScrollView(ConsoleSettings.ScrollRect, Console.Scroll, Console.Viewport);

        for (int i = 0; i < logs.Count; i++) {
            Rect labelRect = new Rect(ConsoleSettings.TextLeftPadding, ConsoleSettings.TextTopPadding + (ConsoleSettings.TextSpacing * i), 0.0f, ConsoleSettings.LabelHeight);
            GUI.Label(labelRect, logs[i], ConsoleSettings.guiStyle);
        }

        GUI.EndScrollView();
    }

    public static void PauseConsole() {
        ConsoleSettings.PauseConsole = !ConsoleSettings.PauseConsole;
        Console.FrozenLogs.Clear();
        Console.FrozenLogs.AddRange(ConsoleSettings.Logs);
    }

    public static void ClearConsole() => ConsoleSettings.Logs.Clear();

    void ShowConsole() {
        Console.ScrollToBottom();
        ConsoleSettings.ShowConsole = !ConsoleSettings.ShowConsole;
    }

    void HideConsole() => ConsoleSettings.ShowConsole = false;

    static void ScrollToBottom() => Console.Scroll = new Vector2(0.0f, Console.Viewport.height);

    public static void Print(object log) {
        ConsoleSettings.Logs.Add(log.ToString());
        Console.ScrollToBottom();
    }

    public static void Print(IList<string> logs) {
        ConsoleSettings.Logs.AddRange(logs);
        Console.ScrollToBottom();
    }

    public static void Print(IList<bool> logs) => Print(new List<bool>(logs).ConvertAll(x => x.ToString()));

    public static void Print(IList<float> logs) => Print(new List<float>(logs).ConvertAll(x => x.ToString()));

    public static void Print(IList<int> logs) => Print(new List<int>(logs).ConvertAll(x => x.ToString()));

    void OnDestroy() {
        InputListener.onBackquotePress -= this.ShowConsole;
        InputListener.onEscapePress -= this.HideConsole;
    }
}