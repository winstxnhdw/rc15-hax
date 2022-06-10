using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class DimensionalRift : HaxModules {
    bool IsDimensionalRifting { get; set; } = false;
    bool IsNoClipping { get; set; } = false;

    Vector3 SimulationCameraPosition { get; set; }
    Vector3 RiftEndPosition { get; set; }

    public static event Global.Action<bool>? inDimensionalRift;

    protected override void OnEnable() {
        HaxObjects.SimulationCameraObject.Init(this);
        InputListener.onF10Press += this.ToggleDimensionalRift;
        NoClip.noClipped += ListenForNoClip;
    }

    protected override void OnDisable() {
        HaxObjects.SimulationCameraObject.StopLog();
        InputListener.onF10Press -= this.ToggleDimensionalRift;
        NoClip.noClipped -= ListenForNoClip;
        this.IsDimensionalRifting = false;
    }

    void Update() {
        this.PerformDimensionalRift();
    }

    void PerformDimensionalRift() {
        SimulationCamera simulationCamera = HaxObjects.SimulationCameraObject.Object;

        if (!this.IsDimensionalRifting || simulationCamera == null) return;

        Player.Freeze(true);
        Transform cameraTransform = Global.Camera.transform;
        simulationCamera.transform.position = this.SimulationCameraPosition;

        // Forward-back
        if (Input.GetKey(KeyCode.W)) {
            this.SimulationCameraPosition += cameraTransform.forward;
        }

        else if (Input.GetKey(KeyCode.S)) {
            this.SimulationCameraPosition -= cameraTransform.forward;
        }

        // Right-left
        if (Input.GetKey(KeyCode.D)) {
            this.SimulationCameraPosition += cameraTransform.right;
        }

        else if (Input.GetKey(KeyCode.A)) {
            this.SimulationCameraPosition -= cameraTransform.right;
        }

        // Up-down
        if (Input.GetKey(KeyCode.Space)) {
            this.SimulationCameraPosition += cameraTransform.up;
        }

        else if (Input.GetKey(KeyCode.LeftShift)) {
            this.SimulationCameraPosition -= cameraTransform.up;
        }

        this.RiftEndPosition = this.SimulationCameraPosition;
    }

    void ListenForNoClip(bool isNoClipping) {
        this.IsNoClipping = isNoClipping;
    }

    void ToggleDimensionalRift() {
        if (this.IsNoClipping) return;

        this.SimulationCameraPosition = Global.Camera.transform.position;
        this.IsDimensionalRifting = !this.IsDimensionalRifting;
        DimensionalRift.inDimensionalRift?.Invoke(this.IsDimensionalRifting);

        if (!this.IsDimensionalRifting) {
            Player.Freeze(false);
            Player.RectifyRoll();
            HaxObjects.PlayerRigidbody.Object.rb.transform.position = this.RiftEndPosition;
        }
    }
}