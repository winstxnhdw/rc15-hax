using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public static class ConsoleSettings {
    static float ConsoleHeight => 0.4f * Screen.height;

    static float ConsoleWidth => Screen.width;

    static int MaxLogs => 1000;

    static List<string> logs = new List<string>();

    public static float FieldTextTopPadding => Mathf.Clamp(10.0f * Settings.SizeRatio, 0.0f, ConsoleSettings.FieldContainerRect.height);

    public static float TextLeftPadding => 15.0f * Settings.SizeRatio;

    public static float TextTopPadding => 15.0f * Settings.SizeRatio;

    public static float TextSpacing => 25.0f * Settings.SizeRatio;

    public static float LabelHeight => 25.5f * Settings.SizeRatio;

    public static bool ShowConsole { get; set; } = false;

    public static bool PauseConsole { get; set; } = false;

    public static List<string> Logs {
        get {
            if (ConsoleSettings.logs.Count > ConsoleSettings.MaxLogs) {
                ConsoleSettings.logs.RemoveRange(0, ConsoleSettings.logs.Count - ConsoleSettings.MaxLogs);
            }

            return ConsoleSettings.logs;
        }
    }

    public static string FieldText { get; set; } = "";

    public static GUIStyle guiStyle {
        get {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            style.fontSize = (int)(20.0f * Settings.SizeRatio);
            return style;
        }
    }

    public static Rect ConsoleRect => new Rect(0.0f, 0.0f, ConsoleSettings.ConsoleWidth, ConsoleSettings.ConsoleHeight);

    public static Rect ScrollRect => new Rect(0.0f, 2.0f, ConsoleSettings.ConsoleRect.width, ConsoleSettings.ConsoleRect.height - 2.0f);

    public static Rect FieldContainerRect = new Rect(0, ConsoleSettings.ConsoleHeight, Screen.width, ConsoleSettings.ConsoleHeight * 0.1f);

    public static Rect FieldRect = new Rect(ConsoleSettings.TextLeftPadding, ConsoleSettings.ConsoleHeight + ConsoleSettings.FieldTextTopPadding, FieldContainerRect.width - ConsoleSettings.TextLeftPadding, ConsoleSettings.FieldContainerRect.height);
}