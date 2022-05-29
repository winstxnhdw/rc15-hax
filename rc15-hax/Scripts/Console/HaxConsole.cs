using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class Console : MonoBehaviour {
    Vector2 scroll;

    void Awake() {
        InputListener.onBackquotePress += this.OnToggleDebug;
    }

    void OnGUI() {
        this.RenderConsole();
    }

    void RenderConsole() {
        if (!ConsoleSettings.ShowConsole) return;

        Rect console = new Rect(0.0f, 0.0f, Screen.width, 0.2f * Screen.height);
        GUI.Box(console, "");

        Rect viewport = new Rect(0.0f, 0.0f, 0.9f * Screen.width, ConsoleSettings.Logs.Count * ConsoleSettings.LabelHeight);
        Rect scrollRect = new Rect(0.0f, 0.0f, Screen.width, console.height - 5.0f);
        this.scroll = GUI.BeginScrollView(scrollRect, this.scroll, viewport);

        for (int i = 0; i < ConsoleSettings.Logs.Count; i++) {
            Rect labelRect = new Rect(ConsoleSettings.TextLeftPadding, (ConsoleSettings.TextSpacing * i), 0.0f, ConsoleSettings.LabelHeight);
            GUI.Label(labelRect, ConsoleSettings.Logs[i], ConsoleSettings.guiStyle);
        }

        GUI.EndScrollView();
    }

    void ConsolePrint(string log) => ConsoleSettings.Logs.Add(log);

    void ConsolePrint(float log) => ConsolePrint(log.ToString());

    void ConsolePrint(int log) => ConsolePrint(log.ToString());

    void ConsolePrint(IList<string> logs) => ConsoleSettings.Logs.AddRange(logs);

    void ConsolePrint(IList<float> logs) => ConsolePrint(new List<float>(logs).ConvertAll(x => x.ToString()));

    void ConsolePrint(IList<int> logs) => ConsolePrint(new List<int>(logs).ConvertAll(x => x.ToString()));

    void OnToggleDebug() => ConsoleSettings.ShowConsole = !ConsoleSettings.ShowConsole;

    void OnDestroy() {
        InputListener.onBackquotePress -= this.OnToggleDebug;
    }
}
