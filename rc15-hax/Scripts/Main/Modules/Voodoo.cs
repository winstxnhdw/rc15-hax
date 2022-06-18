using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class Voodoo : HaxModules {
    List<Body> VoodooBodies { get; set; } = new List<Body>(PlayerESP.RigidbodyDict.Values);
    Vector3 SpawnPoint { get; set; } = Vector3.zero;
    Vector3 CameraForwardSpawnPoint { get; set; } = Vector3.zero;
    float VoodooForwardOffset { get => HaxSettings.GetValue<float>("VoodooForwardOffset"); }
    bool IsDoingBlackMagic { get; set; } = false;
    int CycleIndex { get; set; } = 0;

    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onF8Press += this.ToggleVoodoo;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onF8Press -= this.ToggleVoodoo;
        this.IsDoingBlackMagic = false;
        this.CycleIndex = 0;
    }

    void Update() {
        this.SummonVoodoo();
    }

    void FixedUpdate() {
        this.SummonVoodoo();
    }

    void SummonVoodoo() {
        if (!this.IsDoingBlackMagic) return;

        Rigidbody rigidbody = this.VoodooBodies[this.CycleIndex % this.VoodooBodies.Count].Rigidbody;
        Transform rigidbodyT = rigidbody.transform;
        Transform simulationBoardT = rigidbodyT.parent;
        Vector3 desiredPosition = this.SpawnPoint + this.CameraForwardSpawnPoint;

        rigidbodyT.position = desiredPosition;
        rigidbodyT.localRotation = Quaternion.identity;
        simulationBoardT.position = desiredPosition;
    }

    void ToggleVoodoo() {
        this.IsDoingBlackMagic = !this.IsDoingBlackMagic;
        this.VoodooBodies = new List<Body>(PlayerESP.RigidbodyDict.Values);
        this.SpawnPoint = HaxObjects.PlayerRigidbody.worldCenterOfMass;
        this.CameraForwardSpawnPoint = Global.Camera.transform.forward * this.VoodooForwardOffset;

        if (!this.IsDoingBlackMagic) this.CycleIndex++;
    }
}