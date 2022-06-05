using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class Console : HaxComponents {
    List<string> frozenLogs = new List<string>();
    Vector2 Scroll { get; set; } = Vector2.zero;

    void Awake() {
        InputListener.onBackquotePress += this.ShowConsole;
        InputListener.onEscapePress += this.HideConsole;
    }

    void OnGUI() {
        this.RenderConsole();
    }

    void RenderConsole() {
        if (!ConsoleSettings.ShowConsole) return;

        List<string> logs = !ConsoleSettings.PauseConsole ? ConsoleSettings.Logs : this.frozenLogs;

        Rect console = ConsoleSettings.ConsoleRect;
        GUI.Box(console, "Console");

        Rect viewport = new Rect(0.0f, 0.0f, 0.9f * console.width, logs.Count * ConsoleSettings.LabelHeight);
        this.Scroll = GUI.BeginScrollView(ConsoleSettings.ScrollRect, this.Scroll, viewport);

        for (int i = 0; i < logs.Count; i++) {
            Rect labelRect = new Rect(ConsoleSettings.TextLeftPadding, ConsoleSettings.TextTopPadding + (ConsoleSettings.TextSpacing * i), 0.0f, ConsoleSettings.LabelHeight);
            GUI.Label(labelRect, logs[i], ConsoleSettings.guiStyle);
        }

        GUI.EndScrollView();
    }

    void PauseConsole() {
        ConsoleSettings.PauseConsole = !ConsoleSettings.PauseConsole;
        this.frozenLogs.Clear();
        this.frozenLogs.AddRange(ConsoleSettings.Logs);
    }

    void ClearConsole() => ConsoleSettings.Logs.Clear();

    void ShowConsole() => ConsoleSettings.ShowConsole = !ConsoleSettings.ShowConsole;

    void HideConsole() => ConsoleSettings.ShowConsole = false;

    public static void Print(string log) => ConsoleSettings.Logs.Add(log);

    public static void Print(bool log) => Print(log.ToString());

    public static void Print(float log) => Print(log.ToString());

    public static void Print(int log) => Print(log.ToString());

    public static void Print(IList<string> logs) => ConsoleSettings.Logs.AddRange(logs);

    public static void Print(IList<bool> logs) => Print(new List<bool>(logs).ConvertAll(x => x.ToString()));

    public static void Print(IList<float> logs) => Print(new List<float>(logs).ConvertAll(x => x.ToString()));

    public static void Print(IList<int> logs) => Print(new List<int>(logs).ConvertAll(x => x.ToString()));

    void OnDestroy() {
        InputListener.onBackquotePress -= this.ShowConsole;
    }
}