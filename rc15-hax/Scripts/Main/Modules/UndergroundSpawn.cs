using System;
using UnityEngine;

namespace RC15_HAX;

public class UndergroundSpawn : HaxModules {
    protected override bool ModEnabled { get => HaxSettings.GetValue<bool>("SpawnUnderground"); }
    float UndergroundPositionY { get => -HaxSettings.GetValue<float>("UndergroundPositionOffset"); }

    public static event Action spawnedUnderground;

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.SpawnUnderground();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
    }

    void SpawnUnderground() {
        if (!this.ModEnabled) return;

        Rigidbody playerRigidbody = HaxObjects.PlayerRigidbody;
        Vector3 currentPosition = playerRigidbody.worldCenterOfMass;
        currentPosition.y = this.UndergroundPositionY;
        playerRigidbody.position = currentPosition;
        UndergroundSpawn.spawnedUnderground?.Invoke();
    }
}
