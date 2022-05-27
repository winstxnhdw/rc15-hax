using UnityEngine;

namespace RC15_HAX;
public static class Console {
    static float SizeRatio => Screen.height / 1080.0f;
    public static float TextLeftPadding => 15.0f * SizeRatio;
    public static float TextTopPadding => 15.0f * SizeRatio;
    public static float TextSpacing => 25.0f * SizeRatio;
    public static float LabelHeight => 25.0f * SizeRatio;
    public static GUIStyle guiStyle {
        get {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            style.fontSize = (int)(20.0f * SizeRatio);
            return style;
        }
    }
}