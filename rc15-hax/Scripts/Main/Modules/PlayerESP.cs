using UnityEngine;

namespace RC15_HAX;
public class PlayerESP : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnablePlayerESP"); }
    float TextBottomPadding { get => HaxSettings.GetValue<float>("TextBottomPadding"); }
    float OutlineBoxSize { get => HaxSettings.GetValue<float>("OutlineBoxSize") * Settings.SizeRatio; }

    void OnGUI() {
        this.DrawESP();
    }

    void DrawESP() {
        if (!ModEnabled) return;
        foreach (Rigidbody rigidbody in HaxObjects.Rigidbodies.Objects) {
            if (!rigidbody.name.StartsWith("AIB") && rigidbody.name != "RigidBodyParent__") continue;

            Vector3 rigidbodyWorldPosition = rigidbody.worldCenterOfMass;
            Vector3 rigidbodyScreenPosition = Global.Camera.WorldToScreenPoint(rigidbodyWorldPosition);

            if (rigidbodyScreenPosition.z <= 0.0f) continue;

            float distanceFromRigidbody = Vector3.Distance(rigidbodyWorldPosition, Global.Camera.transform.position);
            rigidbodyScreenPosition.y = Screen.height - rigidbodyScreenPosition.y;

            Size size = new Size(this.OutlineBoxSize) / distanceFromRigidbody;
            GUIHelper.DrawOutlineBox(rigidbodyScreenPosition, size, Settings.BoxLineWidth);

            float halfWidth = 0.5f * size.Width;
            float halfHeight = 0.5f * size.Height;

            Vector2 nameTextPosition = new Vector2(rigidbodyScreenPosition.x - halfWidth, rigidbodyScreenPosition.y - halfHeight - this.TextBottomPadding);
            GUIHelper.DrawLabel(nameTextPosition, $"{rigidbody.name}: {Mathf.RoundToInt(distanceFromRigidbody).ToString()}m");

            int coordinateX = Mathf.RoundToInt(rigidbodyScreenPosition.x);
            int coordinateY = Mathf.RoundToInt(rigidbodyScreenPosition.y);
            int coordinateZ = Mathf.RoundToInt(rigidbodyScreenPosition.z);
            Vector2 coordinatesTextPosition = new Vector2(rigidbodyScreenPosition.x - halfWidth, rigidbodyScreenPosition.y + halfHeight);
            GUIHelper.DrawLabel(coordinatesTextPosition, $"{coordinateX}, {coordinateY}, {coordinateZ}");
        }
    }
}