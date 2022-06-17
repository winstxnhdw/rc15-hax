using UnityEngine;

namespace RC15_HAX;
public class TeslaMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableTeslaMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        base.OnEnable();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
    }

    void Update() {
        this.ModTesla();
    }

    void ModTesla() {
        if (!this.ModEnabled) return;

        foreach (Collider collider in HaxObjects.PlayerRigidbody.gameObject.GetComponentsInChildren<Collider>()) {
            string colliderName = collider.transform.name;
            if (colliderName != "blade1Collision" && !colliderName.StartsWith("CollisionArm")) continue;
            collider.enabled = false;
        }
    }
}