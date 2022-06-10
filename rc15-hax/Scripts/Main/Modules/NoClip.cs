using UnityEngine;

namespace RC15_HAX;
public class NoClip : HaxModules {
    bool IsNoClipping { get; set; } = false;
    bool InDimensionalRift { get; set; } = false;
    float NoClipSpeedMultiplier { get => HaxSettings.GetValue<float>("NoClipSpeedMultiplier"); }

    public static event Global.Action<bool>? noClipped;

    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onF9Press += this.ToggleNoClip;
        DimensionalRift.inDimensionalRift += ListenForDimensionalRift;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onF9Press -= this.ToggleNoClip;
        DimensionalRift.inDimensionalRift -= ListenForDimensionalRift;
        this.IsNoClipping = false;
    }

    void Update() {
        this.PerformNoClip();
    }

    void PerformNoClip() {
        if (!this.IsNoClipping) return;

        Rigidbody playerRigidbody = HaxObjects.PlayerRigidbody.Object.rb;
        Player.Freeze(true);

        if (Input.anyKey) {
            Player.RectifyRoll();
            Transform cameraTransform = Global.Camera.transform;
            Vector3 directionVector = Vector3.zero;

            // Forward-back
            if (Input.GetKey(KeyCode.W)) {
                directionVector = cameraTransform.forward;
            }

            else if (Input.GetKey(KeyCode.S)) {
                directionVector = -cameraTransform.forward;
            }

            // Right-left
            if (Input.GetKey(KeyCode.D)) {
                directionVector = cameraTransform.right;
            }

            else if (Input.GetKey(KeyCode.A)) {
                directionVector = -cameraTransform.right;
            }

            // Up-down
            if (Input.GetKey(KeyCode.Space)) {
                directionVector = cameraTransform.up;
            }

            else if (Input.GetKey(KeyCode.LeftShift)) {
                directionVector = -cameraTransform.up;
            }

            playerRigidbody.position += directionVector * this.NoClipSpeedMultiplier;
        }
    }

    void ListenForDimensionalRift(bool inDimensionalRift) {
        this.InDimensionalRift = inDimensionalRift;
    }

    void ToggleNoClip() {
        if (!Loader.HaxModules.activeSelf || this.InDimensionalRift) return;

        this.IsNoClipping = !this.IsNoClipping;
        NoClip.noClipped?.Invoke(this.IsNoClipping);
        if (!this.IsNoClipping) Player.Freeze(false);
    }
}