using UnityEngine;
using Simulation;
namespace RC15_HAX;

public class RoofSpawn : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("SpawnInRoof"); }
    float RoofPositionY { get => 280.0f; }

    protected override void OnEnable() {
        base.OnEnable();
        this.SpawnInRoof();
    }

    protected override void OnDisable() {
        base.OnDisable();
    }

    void SpawnInRoof() {
        if (!this.ModEnabled) return;

        Rigidbody playerRigidbody = HaxObjects.PlayerRigidbody.Object.rb;
        Vector3 currentPosition = playerRigidbody.worldCenterOfMass;
        currentPosition.y = this.RoofPositionY;
        playerRigidbody.position = currentPosition;
        Player.RectifyRoll();
    }
}
