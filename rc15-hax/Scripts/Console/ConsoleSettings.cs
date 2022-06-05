using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public static class ConsoleSettings {
    static float ConsoleHeight => 0.3f * Screen.height;

    static float ConsoleWidth => Screen.width;

    public static float TextLeftPadding => 15.0f * Settings.SizeRatio;

    public static float TextTopPadding => 15.0f * Settings.SizeRatio;

    public static float TextSpacing => 25.0f * Settings.SizeRatio;

    public static float LabelHeight => 25.0f * Settings.SizeRatio;

    public static bool ShowConsole { get; set; } = false;

    public static bool PauseConsole { get; set; } = false;

    public static List<string> Logs { get; } = new List<string>();

    public static GUIStyle guiStyle {
        get {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            style.fontSize = (int)(20.0f * Settings.SizeRatio);
            return style;
        }
    }

    public static Rect ConsoleRect => new Rect(0.0f, 0.0f, ConsoleSettings.ConsoleWidth, ConsoleSettings.ConsoleHeight);

    public static Rect ScrollRect => new Rect(0.0f, 0.0f, Screen.width, ConsoleSettings.ConsoleHeight - 5.0f);
}