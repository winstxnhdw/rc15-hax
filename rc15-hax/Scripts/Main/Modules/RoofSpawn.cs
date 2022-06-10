using UnityEngine;
using Simulation;
namespace RC15_HAX;

public class RoofSpawn : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("SpawnInRoof"); }

    protected override void OnEnable() {
        base.OnEnable();
        this.SpawnInRoof();
    }

    protected override void OnDisable() {
        base.OnDisable();
    }

    void SpawnInRoof() {
        if (!ModEnabled) return;

        Rigidbody playerRigidbody = HaxObjects.PlayerRigidbody.Object.rb;
        Vector3 currentPosition = playerRigidbody.worldCenterOfMass;
        currentPosition.y = 280.0f;
        playerRigidbody.position = currentPosition;
        Player.RectifyRoll();
    }
}