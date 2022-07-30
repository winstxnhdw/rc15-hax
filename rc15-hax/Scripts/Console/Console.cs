using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hax;
public class Console : HaxComponents {
    static List<string> logs = new List<string>();
    static List<string> FrozenLogs { get; set; } = new List<string>();
    static Vector2 Scroll { get; set; } = Vector2.zero;
    static Rect Viewport { get; set; } = new Rect(0, 0, 0, 0);

    public static List<string> Logs {
        get {
            if (Console.logs.Count > ConsoleSettings.MaxLogs) {
                Console.logs.RemoveRange(0, Console.logs.Count - ConsoleSettings.MaxLogs);
            }

            return Console.logs;
        }
    }

    void Awake() {
        InputListener.onEscapePress += this.HideConsole;
    }

    void OnGUI() {
        this.RenderConsole();
    }

    void RenderConsole() {
        if (!ConsoleSettings.ShowConsole) return;

        List<string> logs = !ConsoleSettings.PauseConsole ? Console.Logs : Console.FrozenLogs;

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
        Console.FrozenLogs.Clear();
        Console.FrozenLogs.AddRange(Console.Logs);
        ConsoleSettings.PauseConsole = !ConsoleSettings.PauseConsole;
    }

    public static void ClearConsole() => Console.Logs.Clear();

    public static void ShowConsole() {
        Console.ScrollToBottom();
        ConsoleSettings.ShowConsole = !ConsoleSettings.ShowConsole;
    }

    void HideConsole() {
        ConsoleInputField.ClearInputField();
        ConsoleSettings.ShowConsole = false;
    }

    public static void ScrollToBottom() => Console.Scroll = new Vector2(0.0f, Console.Viewport.height);


    public static void Print(object log) {
        string strLog = log.ToString();

        if (strLog.Contains("\n")) {
            Print(strLog.Split(Environment.NewLine.ToCharArray()));
            return;
        }

        Console.Logs.Add(strLog);
    }

    public static void Print(IList<string> logs) => Console.Logs.AddRange(new List<string>(logs).ConvertAll(x => x.Trim(Environment.NewLine.ToCharArray())));

    public static void Print(IList<int> logs) => Print(new List<int>(logs).ConvertAll(x => x.ToString()));

    public static void Print(IList<float> logs) => Print(new List<float>(logs).ConvertAll(x => x.ToString()));

    public static void Print(IList<bool> logs) => Print(new List<bool>(logs).ConvertAll(x => x.ToString()));

    void OnDestroy() {
        InputListener.onEscapePress -= this.HideConsole;
    }
}