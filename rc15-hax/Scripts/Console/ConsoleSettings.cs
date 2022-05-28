using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public static class ConsoleSettings {
    static float SizeRatio => Screen.height / 1080.0f;

    public static float TextLeftPadding => 15.0f * SizeRatio;

    public static float TextTopPadding => 15.0f * SizeRatio;

    public static float TextSpacing => 25.0f * SizeRatio;

    public static float LabelHeight => 25.0f * SizeRatio;

    public static bool ShowConsole { get; set; } = false;

    public static List<string> Logs { get; } = new List<string>();

    public static GUIStyle guiStyle {
        get {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            style.fontSize = (int)(20.0f * SizeRatio);
            return style;
        }
    }
}