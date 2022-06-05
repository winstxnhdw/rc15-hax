using UnityEngine;

namespace RC15_HAX;
public class Hax : HaxComponents {
    bool HaxPaused { get; set; } = false;
    bool IsNoClipping { get; set; } = false;
    bool IsDimensionalRifting { get; set; } = false;

    Vector3 RiftEndPosition { get; set; } = Vector3.zero;
    HaxGUI? haxGUI { get; set; }

    void Awake() {
        InputListener.onPausePress += this.ToggleHaxPause;
        InputListener.onF9Press += this.ToggleNoClip;
        InputListener.onF10Press += this.GetNames;
        InputListener.onBackslashPress += this.RectifyOrientation;
        InputListener.onLeftShiftPress += this.ToggleDimensionalRift;

        this.haxGUI = GetComponent<HaxGUI>();
    }

    void Update() {
        if (this.HaxPaused || HaxObjects.TopBarObject.Objects.Length > 0) {
            this.EnableHaxGUI(false);
            this.RevertHaxParams();
            return;
        }

        this.EnableHaxGUI(true);
        this.NoClip();
        this.NoCameraShake();
        this.GodMode();
        this.DimensionalRift();
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

    // public static System.Object DoInvoke(System.Type type, string methodName, System.Object[] parameters) {
    //     System.Type[] types = new System.Type[parameters.Length];

    //     for (int i = 0; i < parameters.Length; i++) {
    //         types[i] = parameters[i].GetType();
    //     }

    //     MethodInfo method = type.GetMethod(methodName, (BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public), null, types, null);
    //     return DoInvoke2(type, method, parameters);
    // }

    // public static System.Object DoInvoke2(System.Type type, MethodInfo method, System.Object[] parameters) {
    //     if (method.IsStatic) {
    //         return method.Invoke(null, parameters);
    //     }

    //     System.Object obj = type.InvokeMember(null,
    //     BindingFlags.DeclaredOnly |
    //     BindingFlags.Public | BindingFlags.NonPublic |
    //     BindingFlags.Instance | BindingFlags.CreateInstance, null, null, new System.Object[0]);

    //     return method.Invoke(obj, parameters);
    // }

    void RevertHaxParams() {

    }

    void DimensionalRift() {
        if (!this.IsDimensionalRifting || this.IsNoClipping) return;

        this.FreezePlayer(true);
        Transform simulationCameraTransform = HaxObjects.SimulationCameraObject.Objects[0].transform;
        Transform cameraTransform = Global.Camera.transform;

        // Forward-back
        if (Input.GetKey(KeyCode.W)) {
            HaxObjects.SimulationCameraObject.Objects[0].transform.position += cameraTransform.forward;
        }

        else if (Input.GetKey(KeyCode.S)) {
            HaxObjects.SimulationCameraObject.Objects[0].transform.position -= cameraTransform.forward;
        }

        // Right-left
        if (Input.GetKey(KeyCode.D)) {
            HaxObjects.SimulationCameraObject.Objects[0].transform.position += cameraTransform.right;
        }

        else if (Input.GetKey(KeyCode.A)) {
            HaxObjects.SimulationCameraObject.Objects[0].transform.position -= cameraTransform.right;
        }

        // Up-down
        if (Input.GetKey(KeyCode.Space)) {
            HaxObjects.SimulationCameraObject.Objects[0].transform.position += cameraTransform.up;
        }

        else if (Input.GetKey(KeyCode.LeftShift)) {
            HaxObjects.SimulationCameraObject.Objects[0].transform.position -= cameraTransform.up;
        }

        this.RiftEndPosition = HaxObjects.SimulationCameraObject.Objects[0].transform.position;


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
    }

    void GodMode() {
        Rigidbody playerRigidbody = HaxObjects.PlayerRigidbody.Objects[0].rb;
    }

    void NoClip() {
        if (!this.IsNoClipping || this.IsDimensionalRifting) return;

        Rigidbody playerRigidbody = HaxObjects.PlayerRigidbody.Objects[0].rb;
        playerRigidbody.isKinematic = true;

        if (Input.anyKey) {
            // Reset player's roll
            HaxObjects.PlayerRigidbody.Objects[0].rb.rotation = Quaternion.Euler(
                Global.Camera.transform.eulerAngles.x,
                Global.Camera.transform.eulerAngles.y,
                0.0f
            );

            Transform cameraTransform = Global.Camera.transform;

            // Forward-back
            if (Input.GetKey(KeyCode.W)) {
                playerRigidbody.position += cameraTransform.forward;
            }

            else if (Input.GetKey(KeyCode.S)) {
                playerRigidbody.position -= cameraTransform.forward;
            }

            // Right-left
            if (Input.GetKey(KeyCode.D)) {
                playerRigidbody.position += cameraTransform.right;
            }

            else if (Input.GetKey(KeyCode.A)) {
                playerRigidbody.position -= cameraTransform.right;
            }

            // Up-down
            if (Input.GetKey(KeyCode.Space)) {
                playerRigidbody.position += cameraTransform.up;
            }

            else if (Input.GetKey(KeyCode.LeftShift)) {
                playerRigidbody.position -= cameraTransform.up;
            }
        }
    }

    void NoCameraShake() {
        if (!bool.Parse(HaxSettings.Params["NoCameraShake"])) return;
        HaxObjects.CameraShakeObject.Objects[0].enabled = false;
    }

    // Resets player's pitch and roll
    void RectifyOrientation() => HaxObjects.PlayerRigidbody.Objects[0].rb.rotation = Quaternion.Euler(0.0f, Global.Camera.transform.eulerAngles.y, 0.0f);

    void FreezePlayer(bool isFrozen) => HaxObjects.PlayerRigidbody.Objects[0].rb.isKinematic = isFrozen;

    void EnableHaxGUI(bool enable) => this.haxGUI!.enabled = enable;

    void ToggleNoClip() {
        this.IsNoClipping = !this.IsNoClipping;
        if (!this.IsNoClipping) this.FreezePlayer(false);
    }

    void ToggleDimensionalRift() {
        this.IsDimensionalRifting = !this.IsDimensionalRifting;

        if (!this.IsDimensionalRifting) {
            HaxObjects.PlayerRigidbody.Objects[0].rb.transform.position = this.RiftEndPosition;
            this.RectifyOrientation();
            this.FreezePlayer(false);
        }
    }

    void ToggleHaxPause() => this.HaxPaused = !this.HaxPaused;

    // Rect windowRect;

    // void Awake() {
    //     InputListener.onF8Press += this.ShowMenu;
    //     InputListener.onEscapePress += this.HideMenu;
    //     this.windowRect = this.GetWindowRect(1000, 1000);
    // }

    // void Update() {
    //     if (Input.GetKeyUp(KeyCode.Pause)) Loader.Unload();

    //     if (Settings.noClipToggle) {
    //         this.PerformNoClip();
    //     }

    //     else {
    //         FindObjectOfType<LocalPlayerRigidbody>().rb.isKinematic = false;
    //     }

    //     if (Input.GetKeyUp(KeyCode.Backslash)) {
    //         FindObjectOfType<LocalPlayerRigidbody>().rb.rotation = Quaternion.Euler(0.0f, Global.Camera.transform.eulerAngles.y, 0.0f);
    //     }

    //     // if (Settings.aimBotToggle) {
    //     //     if (Input.GetMouseButton(0)) {
    //     //         Rigidbody closestRigidBody = FindObjectsOfType<Rigidbody>().OrderBy(rb => Vector3.Distance(Global.Camera.transform.position, rb.worldCenterOfMass)).First();
    //     //         Vector2 w2s = Camera.main.WorldToScreenPoint(closestRigidBody.worldCenterOfMass);
    //     //         Vector2 translatedCursorPosition = w2s - ScreenInfo.GetScreenCentre2D();
    //     //         Global.Camera.transform.localEulerAngles = new Vector3(-translatedCursorPosition.y, translatedCursorPosition.x, 0.0f);
    //     //     }
    //     // }
    // }

    // void ResetPlayerOrientation() {
    //     FindObjectOfType<LocalPlayerRigidbody>().rb.rotation = Quaternion.Euler(Global.Camera.transform.eulerAngles.x, Global.Camera.transform.eulerAngles.y, 0.0f);
    // }

    // void OnGUI() {
    //     if (Settings.espToggle) {
    //         foreach (Rigidbody body in FindObjectsOfType<Rigidbody>()) {
    //             Vector3 w2s = Camera.main.WorldToScreenPoint(body.worldCenterOfMass);
    //             if (w2s.z <= 0.0f) continue;
    //             DrawBox(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(20.0f, 20.0f), true);
    //         }
    //     }

    //     if (!Settings.MenuToggle) return;
    //     GUI.Window(0, this.windowRect, this.RenderWindow, "Hax Menu");
    // }

    // void HideMenu() => Settings.MenuToggle = false;

    // void ShowMenu() => Settings.MenuToggle = !Settings.MenuToggle;

    // void DrawBox(Vector2 position, Vector2 size, bool centered = true) {
    //     Vector2 upperLeft = centered ? position - size / 2f : position;
    //     GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 0.2f);
    //     GUI.DrawTexture(new Rect(position.x, position.y, size.x, size.y), Texture2D.whiteTexture, ScaleMode.StretchToFill);
    // }

    // void PerformNoClip() {
    //     Rigidbody playerRigidbody = FindObjectOfType<LocalPlayerRigidbody>().rb;

    //     playerRigidbody.isKinematic = true;

    //     if (Input.anyKey) {
    //         this.ResetPlayerOrientation();

    //         if (Input.GetKey(KeyCode.W)) {
    //             playerRigidbody.position = playerRigidbody.position + Global.Camera.transform.forward;
    //         }

    //         else if (Input.GetKey(KeyCode.A)) {
    //             playerRigidbody.position = playerRigidbody.position - Global.Camera.transform.right;
    //         }

    //         else if (Input.GetKey(KeyCode.S)) {
    //             playerRigidbody.position = playerRigidbody.position - Global.Camera.transform.forward;
    //         }

    //         else if (Input.GetKey(KeyCode.D)) {
    //             playerRigidbody.position = playerRigidbody.position + Global.Camera.transform.right;
    //         }

    //         if (Input.GetKey(KeyCode.Space)) {
    //             playerRigidbody.position = playerRigidbody.position + Global.Camera.transform.up;
    //         }

    //         else if (Input.GetKey(KeyCode.LeftShift)) {
    //             playerRigidbody.position = playerRigidbody.position - Global.Camera.transform.up;
    //         }
    //     }
    // }

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

    // void ToggleNoClip() {
    //     Settings.noClipToggle = !Settings.noClipToggle;
    // }

    // void ToggleAimBot() {
    //     Settings.aimBotToggle = !Settings.aimBotToggle;
    // }

    // void ToggleESP() {
    //     Settings.espToggle = !Settings.espToggle;
    // }

    // void ToggleCameraShake() {
    //     CameraShake cameraShakeObject = FindObjectOfType<CameraShake>();
    //     cameraShakeObject.enabled = !cameraShakeObject.enabled;
    // }

    // void RenderWindow(int windowIndex) {
    //     if (GUI.Button(this.CreateButtonRect(0), "Toggle CameraShake")) {
    //         this.ToggleCameraShake();
    //     }

    //     if (GUI.Button(this.CreateButtonRect(1), "No recoil")) {
    //         this.ToggleNoRecoil();
    //     }

    //     if (GUI.Button(this.CreateButtonRect(2), "100% Accuracy")) {
    //         this.ToggleMaxAccurancy();
    //     }

    //     if (GUI.Button(this.CreateButtonRect(3), "No ROM")) {
    //         this.ToggleMaxROM();
    //     }

    //     if (GUI.Button(this.CreateButtonRect(4), "Death Laser")) {
    //         this.ToggleDeathLaser();
    //     }

    //     if (GUI.Button(this.CreateButtonRect(5), "No Clip")) {
    //         this.ToggleNoClip();
    //     }

    //     if (GUI.Button(this.CreateButtonRectRow2(0), "Ultimate NanoBeam")) {
    //         this.ToggleUltimateNanoBeam();
    //     }

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

    // Rect CreateButtonRect(int index) {
    //     int padding = 60;
    //     int width = 150;
    //     int height = 30;
    //     int x = (int)this.windowRect.x - ((int)windowRect.width / 2) + padding + (index * width);
    //     int y = (int)this.windowRect.y;

    //     return new Rect(x, y, width, height);
    // }

    // Rect CreateButtonRectRow2(int index) {
    //     int padding = 60;
    //     int width = 150;
    //     int height = 30;
    //     int x = (int)this.windowRect.x - ((int)windowRect.width / 2) + padding + (index * width);
    //     int y = (int)this.windowRect.y + height * 2;

    //     return new Rect(x, y, width, height);
    // }

    // Rect GetWindowRect(int width, int height) {
    //     int x = (Screen.width - width) / 2;
    //     int y = (Screen.height - height) / 2;

    //     return new Rect(x, y, width, height);
    // }

    // void OnDestroy() {
    //     InputListener.onF8Press -= this.ShowMenu;
    //     InputListener.onEscapePress -= this.HideMenu;
    // }
}
