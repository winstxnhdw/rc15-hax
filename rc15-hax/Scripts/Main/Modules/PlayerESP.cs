using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class PlayerESP : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnablePlayerESP"); }
    float TextBottomPadding { get => HaxSettings.GetValue<float>("TextBottomPadding"); }
    float OutlineBoxSize { get => HaxSettings.GetValue<float>("OutlineBoxSize") * Settings.SizeRatio; }
    int RigidBodyID { get; set; } = 0;
    readonly struct InitialBody {
        public string ID { get; }
        public float OriginalMass { get; }

        public InitialBody(string id, float originalMass) {
            this.ID = id;
            this.OriginalMass = originalMass;
        }
    }

    public static Dictionary<int, Body> RigidbodyDict { get; } = new Dictionary<int, Body>();
    Dictionary<int, Body> PreviousRigidbodyDict { get; set; } = new Dictionary<int, Body>();

    protected override void OnEnable() {
        base.OnEnable();
        HaxObjects.Rigidbodies.Init(this);
    }

    protected override void OnDisable() {
        base.OnDisable();
        HaxObjects.Rigidbodies.StopLog();
    }

    void OnGUI() {
        this.DrawESP();
    }

    void FixedUpdate() {
        this.CalculateESP();
    }

    void CalculateESP() {
        if (!this.ModEnabled) return;

        this.PreviousRigidbodyDict = new Dictionary<int, Body>(PlayerESP.RigidbodyDict);
        PlayerESP.RigidbodyDict.Clear();

        foreach (Rigidbody rigidbody in HaxObjects.Rigidbodies.Objects) {
            if (rigidbody.name != "RigidBodyParent__" && !rigidbody.name.StartsWith("AIB")) continue;

            int rigidbodyInstanceID = rigidbody.GetInstanceID();
            Body currentBody;

            if (this.PreviousRigidbodyDict.TryGetValue(rigidbodyInstanceID, out Body body)) {
                currentBody = new Body(body, rigidbody);
            }

            else {
                currentBody = new Body(this.RigidBodyID, rigidbody, Time.fixedDeltaTime);
                this.RigidBodyID++;
            }

            Console.Print(currentBody.Velocity);
            PlayerESP.RigidbodyDict.Add(rigidbodyInstanceID, currentBody);
        }
    }

    void DrawESP() {
        if (!this.ModEnabled) return;

        foreach (Body currentBody in PlayerESP.RigidbodyDict.Values) {
            Vector3 bodyScreenPosition = currentBody.ScreenPosition;
            if (bodyScreenPosition.z <= 0.0f) continue;

            Size size = new Size(this.OutlineBoxSize) / currentBody.DistanceToCamera;
            GUIHelper.DrawOutlineBox(bodyScreenPosition, size, Settings.BoxLineWidth);

            float halfWidth = 0.5f * size.Width;
            float halfHeight = 0.5f * size.Height;

            Vector2 topTextPosition = new Vector2(bodyScreenPosition.x - halfWidth, bodyScreenPosition.y - halfHeight - this.TextBottomPadding);
            GUIHelper.DrawLabel(topTextPosition, $"{currentBody.ID}# {currentBody.Mass} [{currentBody.Health}]");

            Vector2 bottomTextPosition = new Vector2(bodyScreenPosition.x - halfWidth, bodyScreenPosition.y + halfHeight);
            GUIHelper.DrawLabel(bottomTextPosition, $"{currentBody.StrDistanceToCamera} [{currentBody.StrVelocity}]");
        }
    }
}