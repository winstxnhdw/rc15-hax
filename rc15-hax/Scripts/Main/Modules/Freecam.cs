using System;
using UnityEngine;

namespace RC15_HAX;
public class Freecam : HaxModules {
    bool IsPhantom { get; set; } = false;
    bool IsNoClipping { get; set; } = false;

    Vector3 SimulationCameraPosition { get; set; }
    Vector3 PhantomEndPosition { get; set; }

    public static event Action<bool> inPhantom;

    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onF10Press += this.TogglePhantom;
        NoClip.noClipped += ListenForNoClip;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onF10Press -= this.TogglePhantom;
        NoClip.noClipped -= ListenForNoClip;
        this.IsPhantom = false;
    }

    void Update() {
        this.BecomePhantom();
    }

    void BecomePhantom() {
        if (!this.IsPhantom) return;

        Global.SimulationCameraTransform.position = this.SimulationCameraPosition;
        this.SimulationCameraPosition += Global.GetNoClipInputVector();
    }

    void TogglePhantom() {
        if (this.IsNoClipping) return;

        this.IsPhantom = !this.IsPhantom;
        this.SimulationCameraPosition = Global.Camera.transform.position;
        Freecam.inPhantom?.Invoke(this.IsPhantom);
    }

    void ListenForNoClip(bool isNoClipping) => this.IsNoClipping = isNoClipping;
}