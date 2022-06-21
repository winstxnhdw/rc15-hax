using UnityEngine;

namespace RC15_HAX;
public class Aimbot : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableAimbot"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        InputListener.onLeftControl += this.TriggerAimbot;
        InputListener.onLeftControlUp += this.StopAimbot;
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        InputListener.onLeftControl -= this.TriggerAimbot;
        InputListener.onLeftControlUp -= this.StopAimbot;
    }

    void TriggerAimbot() {
        if (!this.ModEnabled) return;

        float closestBodyOnScreen = float.MaxValue;
        Vector3 closestBodyPosition = Vector3.zero;

        foreach (Body body in Enemy.RigidbodyDict.Values) {
            if (body.ScreenPosition.z <= 0.0f) continue;
            float crosshairToBodyDistance = (body.ScreenPosition2D - ScreenInfo.GetScreenCentre()).sqrMagnitude;

            if (crosshairToBodyDistance >= closestBodyOnScreen) continue;

            closestBodyOnScreen = crosshairToBodyDistance;
            closestBodyPosition = body.Position;
        }

        if (closestBodyPosition != Vector3.zero) Global.Camera.transform.LookAt(closestBodyPosition);
    }

    void StopAimbot() {
        Global.Camera.transform.position = Global.SimulationCameraT.position;
        Global.Camera.transform.eulerAngles = Global.SimulationCameraT.eulerAngles;
    }
}
