namespace RC15_HAX;
public class Hax : HaxComponents {
    bool HaxPaused { get; set; } = false;

    void Awake() {
        InputListener.onPausePress += this.ToggleHaxPause;
    }

    void Update() {
        if (this.HaxPaused || HaxObjects.TopBarObject.Objects.Length > 0) {
            Loader.HaxModules.SetActive(false);
            this.RevertHaxParams();
            return;
        }

        Loader.HaxModules.SetActive(true);
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

    // void ToggleNoRecoil() {

    //     foreach (BaseWeapon weapon in FindObjectsOfType<BaseWeapon>()) {
    //         weapon.WeaponStats.RecoilForce = 0.0f;
    //     }
    // }

    // void ToggleMaxAccurancy() {
    //     foreach (BaseWeapon weapon in FindObjectsOfType<BaseWeapon>()) {
    //         weapon.Accuracy.BaseInAccuracyDegrees = 0.0f;
    //         weapon.Accuracy.MovementInAccuracyDegrees = 0.0f;
    //         weapon.Accuracy.RepeatFireInAccuracyTotalDegrees = 0.0f;
    //         weapon.Accuracy.FireInstantAccuracyDecayDegrees = 0.0f;
    //     }
    // }

    // void ToggleMaxROM() {
    //     foreach (BaseWeapon weapon in FindObjectsOfType<BaseWeapon>()) {
    //         weapon.MoveLimits.MaxHorizAngle = 180.0f;
    //         weapon.MoveLimits.MinHorizAngle = -180.0f;
    //         weapon.MoveLimits.MaxVerticalAngle = 180.0f;
    //         weapon.MoveLimits.MinVerticalAngle = -180.0f;
    //         weapon.WeaponStats.AimSpeed = float.MaxValue;
    //     }
    // }

    // void ToggleDeathLaser() {
    //     foreach (BaseWeapon weapon in FindObjectsOfType<BaseWeapon>()) {
    //         weapon.WeaponStats.ProjectileRange = float.MaxValue;
    //         weapon.WeaponStats.ProjectileSpeed = 1000.0f;
    //         weapon.WeaponStats.ProtoniumDamageScale = float.MaxValue;
    //         weapon.WeaponStats.ProjectileImpactForce = float.MaxValue;
    //         weapon.WeaponStats.DamageRatioConducted = float.MaxValue;
    //         weapon.WeaponStats.DamageRatioPassedToChasis = float.MaxValue;
    //     }
    // }

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

    //     if (GUI.Button(this.CreateButtonRectRow2(1), "Dejavu")) {
    //         foreach (CubeWheel cubeWheel in FindObjectsOfType<CubeWheel>()) {
    //             cubeWheel.maxRPM = 2000.0f;
    //             cubeWheel.friction.groundFrictionMultiplier = 3.0f;
    //         }
    //     }

    //     if (GUI.Button(this.CreateButtonRectRow2(2), "Boost")) {
    //         foreach (CubeAerofoil cubeAerofoil in FindObjectsOfType<CubeAerofoil>()) {
    //             cubeAerofoil.dragMinVelocity = float.MaxValue;
    //             cubeAerofoil.dragMaxVelocity = float.MaxValue;
    //         }

    //         foreach (CubeJet cubeJet in FindObjectsOfType<CubeJet>()) {
    //             cubeJet.ForceMagnitude = 15000.0f;
    //             cubeJet.MaxVelocity = float.MaxValue;
    //         }
    //     }

    //     if (GUI.Button(this.CreateButtonRectRow2(3), "ESP")) {
    //         this.ToggleESP();
    //     }

    //     if (GUI.Button(this.CreateButtonRectRow2(4), "AimBot")) {
    //         this.ToggleAimBot();
    //     }
    // }
}
