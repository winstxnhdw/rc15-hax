using System;
using UnityEngine;

namespace Hax;
public static class GUIHelper {
    public static void DrawLabel(Vector2 position, string label) => GUI.Label(new Rect(position.x, position.y, 500.0f, 50.0f), label);

    // Draw a box outline with position as its centre
    public static void DrawOutlineBox(Vector2 centrePosition, Size size, float lineWidth) {
        float halfWidth = 0.5f * size.Width;
        float halfHeight = 0.5f * size.Height;
        float left = centrePosition.x - halfWidth;
        float right = centrePosition.x + halfWidth;
        float top = centrePosition.y - halfHeight;
        float bottom = centrePosition.y + halfHeight;

        // Top face
        Vector2 topLeft = new Vector2(left, top);
        GUIHelper.DrawBox(topLeft, new Size(size.Width, lineWidth));

        // Right face
        Vector2 topRight = new Vector2(right, top);
        GUIHelper.DrawBox(topRight - new Vector2(lineWidth, 0.0f), new Size(lineWidth, size.Height));

        // Bottom face
        Vector2 bottomLeft = new Vector2(left, bottom);
        GUIHelper.DrawBox(bottomLeft - new Vector2(0.0f, lineWidth), new Size(size.Width, lineWidth));

        // Left face
        GUIHelper.DrawBox(topLeft, new Size(lineWidth, size.Height));
    }

    public static void DrawBox(Vector2 position, Size size) {
        Rect rect = new Rect(position.x, position.y, size.Width, size.Height);
        GUI.DrawTexture(rect, Texture2D.whiteTexture, ScaleMode.StretchToFill);
    }

    public static void HorizontalGroup(Action action) {
        GUILayout.BeginHorizontal();
        action();
        GUILayout.EndHorizontal();
    }

    public static void VerticalGroup(Action action) {
        GUILayout.BeginVertical();
        action();
        GUILayout.EndVertical();
    }

    public static bool CreateToggle(string label, bool value) => GUILayout.Toggle(value, $" {label}");
}