using System;
using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class HaxConsole : MonoBehaviour {
    public static List<string> logs = new List<string>();
    bool showConsole;
    Vector2 scroll;

    void Awake() {
        InputListener.onBackquotePress += this.OnToggleDebug;
    }

    void OnGUI() {
        this.RenderConsole();
    }

    void RenderConsole() {
        if (!this.showConsole) return;

        Rect console = new Rect(0.0f, 0.0f, Screen.width, 0.2f * Screen.height);
        GUI.Box(console, "");

        Rect viewport = new Rect(0.0f, 0.0f, 0.9f * Screen.width, HaxConsole.logs.Count * Console.LabelHeight);
        Rect scrollRect = new Rect(0.0f, 0.0f, Screen.width, console.height - 5.0f);
        this.scroll = GUI.BeginScrollView(scrollRect, this.scroll, viewport);

        foreach (var (i, log) in Utils.Enumerate(logs)) {
            Rect labelRect = new Rect(Console.TextLeftPadding, (Console.TextSpacing * i), 0.0f, Console.LabelHeight);
            GUI.Label(labelRect, log, Console.guiStyle);
        }

        GUI.EndScrollView();
    }

    void ConsolePrint(dynamic log) {
        try {
            if (Utils.IsEnumerableType(log)) {
                foreach (var item in log) {
                    HaxConsole.logs.Add(item.ToString());
                }
            }

            else if (log is not string) {
                log = log.ToString();
            }

            else {
                HaxConsole.logs.Add(log);
            }
        }

        catch (Exception exception) {
            HaxConsole.logs.Add(exception.ToString());
        }
    }

    void OnToggleDebug() => this.showConsole = !this.showConsole;

    void OnDestroy() {
        InputListener.onBackquotePress -= this.OnToggleDebug;
    }
}
