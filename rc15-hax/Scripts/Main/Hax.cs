using UnityEngine;

namespace RC15_HAX;
public class Hax : HaxComponents {
    bool HaxPaused { get; set; } = false;

    void Awake() {
        InputListener.onPausePress += this.ToggleHaxPause;
    }

    void Update() {
        if (this.HaxPaused || HaxObjects.TopBarObject.Objects.Length > 0) {

            SetActiveGameObject(Loader.HaxModules, false);
            this.RevertHaxParams();
            return;
        }

        SetActiveGameObject(Loader.HaxModules, true);
    }

    void SetActiveGameObject(GameObject go, bool isActive) {
        if (go.activeSelf == isActive) return;
        go.SetActive(isActive);
    }

    void GetNames() {
        // foreach (Rigidbody rigidbody in Rigidbodies.Objects) {
        //     Console.Print(rigidbody.name);
        // }

        // System.Type t = System.Type.GetType("PlayerTeamsContainer");
        // System.Object obj = DoInvoke(t, "GetPlayersOnEnemyTeam", new System.Object[] { TargetType.Player });
        // IList<int> collection = (IList<int>)obj;

        // foreach (int id in collection) {
        //     Console.Print(id);
        // }
    }

    void RevertHaxParams() {

    }

    // void AimBot() {
    // float closestBodyOnScreen = float.MaxValue;
    // Vector2 closestBodyPosition = Vector2.zero;

    // foreach (Rigidbody rigidbody in Rigidbodies.Objects) {
    //     if (!rigidbody.name.StartsWith("AIB") && rigidbody.name != "RigidBodyParent__") continue;

    //     Vector3 rigidbodyWorldPosition = rigidbody.worldCenterOfMass;
    //     Vector3 rigidbodyScreenPosition = Global.Camera.WorldToScreenPoint(rigidbodyWorldPosition);

    //     if (rigidbodyScreenPosition.z <= 0.0f) continue;
    //     rigidbodyScreenPosition.y = Screen.height - rigidbodyScreenPosition.y;

    //     Vector2 rigidbodyScreenPosition2D = rigidbodyScreenPosition;
    //     float crosshairToBodyDistance = (rigidbodyScreenPosition2D - ScreenInfo.GetScreenCentre()).sqrMagnitude;
    //     if (crosshairToBodyDistance < closestBodyOnScreen) {
    //         closestBodyOnScreen = crosshairToBodyDistance;
    //         closestBodyPosition = rigidbodyScreenPosition2D;
    //     }
    // }

    // Global.Camera.transform.localEulerAngles = new Vector3(-closestBodyPosition.y, closestBodyPosition.x, 0.0f);
    // }

    void ToggleHaxPause() => this.HaxPaused = !this.HaxPaused;

    void OnDestroy() {
        InputListener.onPausePress -= this.ToggleHaxPause;
    }

    //     // if (Settings.aimBotToggle) {
    //     //     if (Input.GetMouseButton(0)) {
    //     //         Rigidbody closestRigidBody = FindObjectsOfType<Rigidbody>().OrderBy(rb => Vector3.Distance(Global.Camera.transform.position, rb.worldCenterOfMass)).First();
    //     //         Vector2 w2s = Camera.main.WorldToScreenPoint(closestRigidBody.worldCenterOfMass);
    //     //         Vector2 translatedCursorPosition = w2s - ScreenInfo.GetScreenCentre2D();
    //     //         Global.Camera.transform.localEulerAngles = new Vector3(-translatedCursorPosition.y, translatedCursorPosition.x, 0.0f);
    //     //     }
    //     // }


    // void ToggleUltimateNanoBeam() {
    //     foreach (NanoBeam nanoBeam in FindObjectsOfType<NanoBeam>()) {
    //         nanoBeam.beamStats.damagePerSecond = 1000000;
    //         nanoBeam.beamStats.healPerSecond = 1000000;
    //         nanoBeam.WeaponStats.ProjectileRange = float.MaxValue;
    //         nanoBeam.WeaponStats.ProjectileSpeed = 1000.0f;
    //         nanoBeam.WeaponStats.ProtoniumDamageScale = float.MaxValue;
    //         nanoBeam.WeaponStats.ProjectileImpactForce = float.MaxValue;
    //         nanoBeam.WeaponStats.DamageRatioConducted = float.MaxValue;
    //         nanoBeam.WeaponStats.DamageRatioPassedToChasis = float.MaxValue;
    //     }
    // }
}
