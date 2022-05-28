using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class HaxConsole : MonoBehaviour {
    public static List<string> logs = new List<string>();
    bool showConsole;
    Vector2 scroll;

    void Awake() {
        InputListener.onBackquotePress += this.OnToggleDebug;
        this.showConsole = false;
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

        for (int i = 0; i < HaxConsole.logs.Count; i++) {
            Rect labelRect = new Rect(Console.TextLeftPadding, (Console.TextSpacing * i), 0.0f, Console.LabelHeight);
            GUI.Label(labelRect, logs[i], Console.guiStyle);
        }

        GUI.EndScrollView();
    }

    void Test() => HaxConsole.logs.Add("Test");

    void ConsolePrint(string log) => HaxConsole.logs.Add(log);

    void ConsolePrint(float log) => ConsolePrint(log.ToString());

    void ConsolePrint(int log) => ConsolePrint(log.ToString());

    void ConsolePrint(IEnumerable<string> log) => log.ToList().ForEach(ConsolePrint);

    void ConsolePrint(IEnumerable<float> log) => log.ToList().ForEach(ConsolePrint);

    void ConsolePrint(IEnumerable<int> log) => log.ToList().ForEach(ConsolePrint);

    void OnToggleDebug() => this.showConsole = !this.showConsole;

    void OnDestroy() {
        InputListener.onBackquotePress -= this.OnToggleDebug;
    }
}
