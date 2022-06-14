using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class Phantom : HaxModules {
    bool IsPhantom { get; set; } = false;
    bool IsNoClipping { get; set; } = false;

    Vector3 SimulationCameraPosition { get; set; }
    Vector3 PhantomEndPosition { get; set; }

    public static event Global.Action<bool>? inPhantom;

    protected override void OnEnable() {
        InputListener.onF10Press += this.TogglePhantom;
        NoClip.noClipped += ListenForNoClip;
    }

    protected override void OnDisable() {
        InputListener.onF10Press -= this.TogglePhantom;
        NoClip.noClipped -= ListenForNoClip;
        this.IsPhantom = false;
    }

    void Update() {
        this.BecomePhantom();
    }

    void BecomePhantom() {
        SimulationCamera simulationCamera = HaxObjects.SimulationCameraObject.Object;

        if (!this.IsPhantom || simulationCamera == null) return;

        Player.Freeze(true);

        if (!Input.anyKey) return;
        simulationCamera.transform.position = this.SimulationCameraPosition;
        this.SimulationCameraPosition = Global.GetNoClipInputVector();
        this.PhantomEndPosition = this.SimulationCameraPosition;
    }

    void ListenForNoClip(bool isNoClipping) {
        this.IsNoClipping = isNoClipping;
    }

    void TogglePhantom() {
        if (this.IsNoClipping) return;

        this.SimulationCameraPosition = Global.Camera.transform.position;
        this.IsPhantom = !this.IsPhantom;
        Phantom.inPhantom?.Invoke(this.IsPhantom);

        if (!this.IsPhantom) {
            Player.Freeze(false);
            Player.RectifyRoll();
            HaxObjects.PlayerRigidbody.Object.rb.transform.position = this.PhantomEndPosition;
        }
    }
}