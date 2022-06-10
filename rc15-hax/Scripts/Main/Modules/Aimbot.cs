using UnityEngine;
using Simulation;
namespace RC15_HAX;
public class Aimbot : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableAimbot"); }

    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onLeftControl += this.TriggerAimbot;
        InputListener.onLeftControlUp += this.StopAimbot;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onLeftControl -= this.TriggerAimbot;
        InputListener.onLeftControlUp -= this.StopAimbot;
    }

    void TriggerAimbot() {
        if (!ModEnabled) return;

        float closestBodyOnScreen = float.MaxValue;
        Vector3 closestBodyPosition = Vector3.zero;

        foreach (Rigidbody rigidbody in HaxObjects.Rigidbodies.Objects) {
            if (!rigidbody.name.StartsWith("AIB") && rigidbody.name != "RigidBodyParent__") continue;

            Vector3 rigidbodyWorldPosition = rigidbody.worldCenterOfMass;
            Vector3 rigidbodyScreenPosition = Global.Camera.WorldToScreenPoint(rigidbodyWorldPosition);

            if (rigidbodyScreenPosition.z <= 0.0f) continue;

            rigidbodyScreenPosition.y = Screen.height - rigidbodyScreenPosition.y;
            Vector2 rigidbodyScreenPosition2D = rigidbodyScreenPosition;
            float crosshairToBodyDistance = (rigidbodyScreenPosition2D - ScreenInfo.GetScreenCentre()).sqrMagnitude;

            if (crosshairToBodyDistance < closestBodyOnScreen) {
                closestBodyOnScreen = crosshairToBodyDistance;
                closestBodyPosition = rigidbodyWorldPosition;
            }
        }

        if (closestBodyPosition != Vector3.zero) Global.Camera.transform.LookAt(closestBodyPosition);
    }

    void StopAimbot() {
        SimulationCamera simulationCamera = HaxObjects.SimulationCameraObject.Object;
        if (simulationCamera == null) {
            Console.Print("No simulation camera found.");
            return;
        }

        Global.Camera.transform.position = simulationCamera.transform.position;
        Global.Camera.transform.eulerAngles = simulationCamera.transform.eulerAngles;
    }
}
