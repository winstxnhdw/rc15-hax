using UnityEngine;

namespace RC15_HAX;
public class PlayerESP : HaxComponents {
    void OnGUI() {
        this.DrawESP();
    }

    void DrawESP() {
        if (!HaxSettings.GetBool("EnableESP")) return;

        foreach (Rigidbody rigidbody in HaxObjects.Rigidbodies.Objects) {
            if (!rigidbody.name.StartsWith("AIB") && rigidbody.name != "RigidBodyParent__") continue;

            Vector3 rigidbodyWorldPosition = rigidbody.worldCenterOfMass;
            Vector3 rigidbodyScreenPosition = Global.Camera.WorldToScreenPoint(rigidbodyWorldPosition);

            if (rigidbodyScreenPosition.z <= 0.0f) continue;

            float flatDistanceFromRigidbody = Vector3.Distance(rigidbodyWorldPosition, Global.Camera.transform.position);
            rigidbodyScreenPosition.y = Screen.height - rigidbodyScreenPosition.y;
            Size size = new Size(Settings.OutlineBoxSize, Settings.OutlineBoxSize) / flatDistanceFromRigidbody;
            GUIHelper.DrawOutlineBox(rigidbodyScreenPosition, size, Settings.BoxLineWidth);

            float halfWidth = 0.5f * size.Width;
            float halfHeight = 0.5f * size.Height;

            Vector2 nameTextPosition = new Vector2(rigidbodyScreenPosition.x - halfWidth, rigidbodyScreenPosition.y - halfHeight - 20.0f);
            GUIHelper.DrawLabel(nameTextPosition, $"{rigidbody.name}: {Mathf.RoundToInt(flatDistanceFromRigidbody).ToString()}m");

            int coordinateX = Mathf.RoundToInt(rigidbodyScreenPosition.x);
            int coordinateY = Mathf.RoundToInt(rigidbodyScreenPosition.y);
            int coordinateZ = Mathf.RoundToInt(rigidbodyScreenPosition.z);
            Vector2 coordinatesTextPosition = new Vector2(rigidbodyScreenPosition.x - halfWidth, rigidbodyScreenPosition.y + halfHeight);
            GUIHelper.DrawLabel(coordinatesTextPosition, $"{coordinateX}, {coordinateY}, {coordinateZ}");
        }
    }
}