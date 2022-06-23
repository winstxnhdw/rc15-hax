using System;
using UnityEngine;

namespace RC15_HAX;
public class NoClip : HaxModules {
    bool IsNoClipping { get; set; } = false;
    bool InPhantom { get; set; } = false;
    float NoClipSpeedGranularity => HaxSettings.GetValue<float>("NoClipSpeedGranularity");

    public static event Action<bool> noClipped;

    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onAlpha1Press += this.DecreaseNoClipSpeed;
        InputListener.onAlpha3Press += this.IncreaseNoClipSpeed;
        InputListener.onF9Press += this.ToggleNoClip;
        UndergroundSpawn.spawnedUnderground += this.ToggleNoClip;
        Freecam.inPhantom += ListenForPhantom;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onAlpha1Press -= this.DecreaseNoClipSpeed;
        InputListener.onAlpha3Press -= this.IncreaseNoClipSpeed;
        InputListener.onF9Press -= this.ToggleNoClip;
        UndergroundSpawn.spawnedUnderground -= this.ToggleNoClip;
        Freecam.inPhantom -= ListenForPhantom;

        this.IsNoClipping = false;
    }

    void Update() {
        this.PerformNoClip();
    }

    void PerformNoClip() {
        if (!this.IsNoClipping) return;

        Player.EnableCollisions(false);
        Player.Freeze(true);

        if (!Input.anyKey) return;
        Player.RectifyRoll();
        HaxObjects.PlayerRigidbody.position += Global.GetNoClipInputVector();
    }

    void ToggleNoClip() {
        if (!Loader.HaxModules.activeSelf || this.InPhantom) return;

        this.IsNoClipping = !this.IsNoClipping;
        NoClip.noClipped?.Invoke(this.IsNoClipping);

        if (this.IsNoClipping) return;
        Player.EnableCollisions(true);
        Player.Freeze(false);
    }

    void DecreaseNoClipSpeed() => NoClipSettings.NoClipSpeedMultiplier -= this.NoClipSpeedGranularity;

    void IncreaseNoClipSpeed() => NoClipSettings.NoClipSpeedMultiplier += this.NoClipSpeedGranularity;

    void ListenForPhantom(bool inPhantom) => this.InPhantom = inPhantom;
}