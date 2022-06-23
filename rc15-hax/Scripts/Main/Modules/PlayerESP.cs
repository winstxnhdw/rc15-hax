using UnityEngine;

namespace RC15_HAX;
public class PlayerESP : HaxModules {
    float TextBottomPadding => HaxSettings.GetValue<float>("TextBottomPadding");
    float OutlineBoxSize => HaxSettings.GetValue<float>("OutlineBoxSize") * Settings.SizeRatio;

    void OnGUI() {
        this.DrawESP();
    }

    void DrawESP() {
        if (!MenuOptions.EnablePlayerESP) return;

        foreach (Body currentBody in Enemy.RigidbodyDict.Values) {
            if (currentBody.Rigidbody == null) continue;

            Vector3 bodyScreenPosition = currentBody.ScreenPosition;
            if (bodyScreenPosition.z <= 0.0f) continue;

            Size size = new Size(this.OutlineBoxSize) / currentBody.DistanceToCamera;
            GUIHelper.DrawOutlineBox(bodyScreenPosition, size, Settings.BoxLineWidth);

            float halfWidth = 0.5f * size.Width;
            float halfHeight = 0.5f * size.Height;

            Vector2 topTextPosition = new Vector2(bodyScreenPosition.x - halfWidth, bodyScreenPosition.y - halfHeight - this.TextBottomPadding);
            GUIHelper.DrawLabel(topTextPosition, $"#{currentBody.ID:00} {currentBody.Mass} [{currentBody.Health}]");

            Vector2 bottomTextPosition = new Vector2(bodyScreenPosition.x - halfWidth, bodyScreenPosition.y + halfHeight);
            GUIHelper.DrawLabel(bottomTextPosition, $"{currentBody.StrDistanceToCamera} [{currentBody.StrVelocity}]");
        }
    }
}