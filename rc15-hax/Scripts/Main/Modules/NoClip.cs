using UnityEngine;

namespace RC15_HAX;
public class NoClip : HaxModules {
    bool IsNoClipping { get; set; } = false;
    bool InPhantom { get; set; } = false;

    public static event Global.Action<bool>? noClipped;

    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onAlpha1Press += this.DecreaseNoClipSpeed;
        InputListener.onAlpha3Press += this.IncreaseNoClipSpeed;
        InputListener.onF9Press += this.ToggleNoClip;
        Phantom.inPhantom += ListenForPhantom;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onAlpha1Press -= this.DecreaseNoClipSpeed;
        InputListener.onAlpha3Press -= this.IncreaseNoClipSpeed;
        InputListener.onF9Press -= this.ToggleNoClip;
        Phantom.inPhantom -= ListenForPhantom;

        this.IsNoClipping = false;
    }

    void Update() {
        this.PerformNoClip();
    }

    void PerformNoClip() {
        if (!this.IsNoClipping) return;

        Rigidbody playerRigidbody = HaxObjects.PlayerRigidbody.Object.rb;
        Player.Freeze(true);

        if (!Input.anyKey) return;
        Player.RectifyRoll();
        playerRigidbody.position += Global.GetNoClipInputVector();
    }

    void ListenForPhantom(bool inPhantom) => this.InPhantom = inPhantom;

    void DecreaseNoClipSpeed() => NoClipSettings.NoClipSpeedMultiplier -= 1;

    void IncreaseNoClipSpeed() => NoClipSettings.NoClipSpeedMultiplier += 1;

    void ToggleNoClip() {
        if (!Loader.HaxModules.activeSelf || this.InPhantom) return;

        this.IsNoClipping = !this.IsNoClipping;
        NoClip.noClipped?.Invoke(this.IsNoClipping);
        if (!this.IsNoClipping) Player.Freeze(false);
    }
}