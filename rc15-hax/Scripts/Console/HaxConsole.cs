using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class Console : MonoBehaviour {
    List<string> frozenLogs = new List<string>();
    Vector2 scroll;

    void Awake() {
        InputListener.onBackquotePress += this.ShowConsole;
    }

    void OnGUI() {
        this.RenderConsole();
    }

    void RenderConsole() {
        if (!ConsoleSettings.ShowConsole) return;
        List<string> logs = !ConsoleSettings.PauseConsole ? ConsoleSettings.Logs : this.frozenLogs;

        Rect console = new Rect(0.0f, 0.0f, ConsoleSettings.ConsoleWidth, ConsoleSettings.ConsoleHeight);
        GUI.Box(console, "");

        Rect viewport = new Rect(0.0f, 0.0f, Screen.width, logs.Count * ConsoleSettings.LabelHeight);
        Rect scrollRect = new Rect(0.0f, 0.0f, Screen.width, console.height - 5.0f);
        this.scroll = GUI.BeginScrollView(scrollRect, this.scroll, viewport);

        for (int i = 0; i < logs.Count; i++) {
            Rect labelRect = new Rect(ConsoleSettings.TextLeftPadding, (ConsoleSettings.TextSpacing * i), 0.0f, ConsoleSettings.LabelHeight);
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

    public static void Print(string log) => ConsoleSettings.Logs.Add(log);

    public static void Print(float log) => Print(log.ToString());

    public static void Print(int log) => Print(log.ToString());

    public static void Print(IList<string> logs) => ConsoleSettings.Logs.AddRange(logs);

    public static void Print(IList<float> logs) => Print(new List<float>(logs).ConvertAll(x => x.ToString()));

    public static void Print(IList<int> logs) => Print(new List<int>(logs).ConvertAll(x => x.ToString()));

    void OnDestroy() {
        InputListener.onBackquotePress -= this.ShowConsole;
    }
}
