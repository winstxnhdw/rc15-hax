using UnityEngine;

namespace RC15_HAX;
public class TeslaMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableTeslaMod"); }

    void Update() {
        this.ModTesla();
    }

    void ModTesla() {
        if (!this.ModEnabled) return;

        foreach (Collider collider in HaxObjects.PlayerRigidbody.Object.rb.gameObject.GetComponentsInChildren<Collider>()) {
            string colliderName = collider.transform.name;
            if (!(colliderName == "blade1Collision" || colliderName.StartsWith("CollisionArm"))) continue;
            collider.enabled = false;
        }
    }
}