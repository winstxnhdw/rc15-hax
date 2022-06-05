using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Simulation;

namespace RC15_HAX;
public class Hax : HaxComponents {
    bool HaxPaused { get; set; } = false;
    bool IsNoClipping { get; set; } = false;

    ObjectCache<LocalPlayerRigidbody> PlayerRigidbody { get; } = new ObjectCache<LocalPlayerRigidbody>();
    ObjectCache<Rigidbody> Rigidbodies { get; } = new ObjectCache<Rigidbody>();
    ObjectCache<CameraShake> CameraShakeObject { get; } = new ObjectCache<CameraShake>();

    void Awake() {
        InputListener.onPausePress += this.ToggleHaxPause;
        InputListener.onF9Press += this.ToggleNoClip;
        InputListener.onF10Press += this.GetNames;
        InputListener.onBackslashPress += this.RectifyOrientation;
    }

    protected override void Start() {
        base.Start();
        this.PlayerRigidbody.Init(this);
        this.Rigidbodies.Init(this);
        this.CameraShakeObject.Init(this);
    }

    void Update() {
        if (this.HaxPaused) {
            this.RevertHaxParams();
            return;
        }

        this.NoClip();
        this.NoCameraShake();
        this.GodMode();
    }

    void OnGUI() {
        if (this.HaxPaused) return;

        this.DrawESP();
    }

    void GetNames() {
        foreach (Rigidbody rigidbody in Rigidbodies.Objects) {
            Console.Print(rigidbody.name);
        }
    }

    void RevertHaxParams() {

    }

    void GodMode() {
        Rigidbody playerRigidbody = this.PlayerRigidbody.Objects[0].rb;
        playerRigidbody.GetComponent<PhysicsRaycaster>().enabled = false;
    }

    void NoClip() {
        if (!this.IsNoClipping) return;

        Rigidbody playerRigidbody = this.PlayerRigidbody.Objects[0].rb;
        playerRigidbody.isKinematic = true;

        if (Input.anyKey) {
            // Reset player's roll
            this.PlayerRigidbody.Objects[0].rb.rotation = Quaternion.Euler(
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

    void DrawESP() {
        if (!bool.Parse(HaxSettings.Params["EnableESP"])) return;

        foreach (Rigidbody rigidbody in Rigidbodies.Objects) {
            if (!rigidbody.name.StartsWith("AIB") && rigidbody.name != "RigidBodyParent__") continue;

            Vector3 rigidbodyWorldPosition = rigidbody.worldCenterOfMass;
            Vector3 rigidbodyScreenPosition = Global.Camera.WorldToScreenPoint(rigidbodyWorldPosition);

            if (rigidbodyScreenPosition.z <= 0.0f) continue;

            float flatDistanceFromRigidbody = Vector3.Distance(rigidbodyWorldPosition, Global.Camera.transform.position);
            rigidbodyScreenPosition.y = Screen.height - rigidbodyScreenPosition.y;
            Size size = new Size(Settings.OutlineBoxSize, Settings.OutlineBoxSize) / flatDistanceFromRigidbody;
            this.DrawOutlineBox(rigidbodyScreenPosition, size, Settings.BoxLineWidth);

            float halfWidth = 0.5f * size.Width;
            float halfHeight = 0.5f * size.Height;

            Vector2 nameTextPosition = new Vector2(rigidbodyScreenPosition.x - halfWidth, rigidbodyScreenPosition.y - halfHeight - 20.0f);
            this.DrawLabel(nameTextPosition, $"{rigidbody.name}: {Mathf.RoundToInt(flatDistanceFromRigidbody).ToString()}m");

            int coordinateX = Mathf.RoundToInt(rigidbodyScreenPosition.x);
            int coordinateY = Mathf.RoundToInt(rigidbodyScreenPosition.y);
            int coordinateZ = Mathf.RoundToInt(rigidbodyScreenPosition.z);
            Vector2 coordinatesTextPosition = new Vector2(rigidbodyScreenPosition.x - halfWidth, rigidbodyScreenPosition.y + halfHeight);
            this.DrawLabel(coordinatesTextPosition, $"{coordinateX}, {coordinateY}, {coordinateZ}");
        }
    }

    void NoCameraShake() {
        if (!bool.Parse(HaxSettings.Params["NoCameraShake"])) return;

        CameraShakeObject.Objects[0].enabled = false;
    }

    // Resets player's pitch and roll
    void RectifyOrientation() => this.PlayerRigidbody.Objects[0].rb.rotation = Quaternion.Euler(0.0f, Global.Camera.transform.eulerAngles.y, 0.0f);

    void DrawLabel(Vector2 position, string label) => GUI.Label(new Rect(position.x, position.y, 500.0f, 50.0f), label);

    // Draw a box outline with position as its centre
    void DrawOutlineBox(Vector2 centrePosition, Size size, float lineWidth) {
        float halfWidth = 0.5f * size.Width;
        float halfHeight = 0.5f * size.Height;
        float left = centrePosition.x - halfWidth;
        float right = centrePosition.x + halfWidth;
        float top = centrePosition.y - halfHeight;
        float bottom = centrePosition.y + halfHeight;

        // Top face
        Vector2 topLeft = new Vector2(left, top);
        this.DrawBox(topLeft, new Size(size.Width, lineWidth));

        // Right face
        Vector2 topRight = new Vector2(right, top);
        this.DrawBox(topRight - new Vector2(lineWidth, 0.0f), new Size(lineWidth, size.Height));

        // Bottom face
        Vector2 bottomLeft = new Vector2(left, bottom);
        this.DrawBox(bottomLeft - new Vector2(0.0f, lineWidth), new Size(size.Width, lineWidth));

        // Left face
        this.DrawBox(topLeft, new Size(lineWidth, size.Height));
    }

    void DrawBox(Vector2 position, Size size) {
        Rect rect = new Rect(position.x, position.y, size.Width, size.Height);
        GUI.DrawTexture(rect, Texture2D.whiteTexture, ScaleMode.StretchToFill);
    }

    void ToggleNoClip() {
        this.IsNoClipping = !this.IsNoClipping;
        if (!this.IsNoClipping) this.PlayerRigidbody.Objects[0].rb.isKinematic = false;
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
